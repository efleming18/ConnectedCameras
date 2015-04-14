using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConnectedCamerasWeb.Infrastructure.Data;
using ConnectedCamerasWeb.Models;
using System.Threading.Tasks;

namespace ConnectedCamerasWeb.Peripherals
{
    public class CameraLocker : IDisposable
    {
        #region Private Fields
        private MainDbContext _db = new MainDbContext();
        private bool _disposed = false;
        private int _expirationInMinutes;
        #endregion

        #region Properties
        public IEnumerable<Camera> LockedCameras 
        {
            get 
            {
                return _db.Cameras.Where(dbc => _db.CameraLocks.Any(lc => dbc.Id == lc.CameraId));
            }
        }
        #endregion

        #region Constructor
        public CameraLocker(int expirationInMinutes) 
        {
            _expirationInMinutes = expirationInMinutes;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Indicates whether there are any locked cameras among the selected camera IDs
        /// </summary>
        public bool AnyLockedCameras(IEnumerable<int> selectedCameraIds)
        {
            RemoveExpiredLocks();
            return _db.CameraLocks.Any(lc => selectedCameraIds.Any(sc => lc.CameraId == sc));
        }
        /// <summary>
        /// Indicates whether there are any locked cameras among the selected camera IDs. Returns false if the current user locked the cameras selected.
        /// </summary>
        public bool AnyLockedCameras(IEnumerable<int> selectedCameraIds, string userId)
        {
            RemoveExpiredLocks();
            return _db.CameraLocks.Any(lc => selectedCameraIds.Any(scId => lc.CameraId == scId && lc.UserId != userId));
        }
        public DateTime? GetTimeStamp(IEnumerable<int> selectedCameraIds)
        {
            var lockedCamera = _db.CameraLocks.First(lc => selectedCameraIds.Any(scId => lc.CameraId == scId));
            if (lockedCamera == null)
                return DateTime.UtcNow;
            return lockedCamera.TimeStamp;
        }
        #endregion

        #region Private Methods
        private void RemoveExpiredLocks()
        {
            var aLongTimeAgo = DateTime.UtcNow.Subtract(new TimeSpan(0, _expirationInMinutes, 0));
            var expiredCameraLocks = _db.CameraLocks.Where(cl => DateTime.Compare(cl.TimeStamp.Value, aLongTimeAgo) <= 0).ToList();
            if (expiredCameraLocks.Count == 0)
                return;
            _db.CameraLocks.RemoveRange(expiredCameraLocks);
            _db.SaveChanges();
        }
        #endregion

        #region Asynchronous Methods
        public async Task LockAsync(IEnumerable<int> selectedCameraIds, string userId) 
        {
            foreach (var id in selectedCameraIds)
                _db.CameraLocks.Add(new CameraLock
                {
                    CameraId = id,
                    UserId = userId,
                    TimeStamp = DateTime.UtcNow
                });
            await _db.SaveChangesAsync();
        }
        #endregion

        #region Dispose
        public void Dispose() 
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _db.Dispose();
            }
            _disposed = true;
        }
        #endregion
    }
}