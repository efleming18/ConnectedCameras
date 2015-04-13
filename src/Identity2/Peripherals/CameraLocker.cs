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
        private double _expirationInMinutes;
        #endregion

        #region Properties
        public IEnumerable<CameraLock> LockedCameras 
        {
            get { return _db.CameraLocks; }
        }
        #endregion

        #region Constructor
        public CameraLocker(int expirationInMinutes) 
        {
            _expirationInMinutes = expirationInMinutes;
        }
        #endregion

        #region Public Methods
        public bool AnyLockedCameras(IEnumerable<int> selectedCameraIds)
        {
            return _db.CameraLocks.Any(lc => selectedCameraIds.Any(sc => lc.CameraId == sc));
        }

        public void RemoveExpiredLocks() 
        {
            var expiredCameraLocks = _db.CameraLocks.Where(cl => DateTime.Compare(cl.TimeStamp.Value, DateTime.UtcNow) < _expirationInMinutes).ToList();
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