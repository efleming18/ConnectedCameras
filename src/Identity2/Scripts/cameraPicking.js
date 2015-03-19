(function ($) {
var hasCameras = $('*').hasClass('no-camera-groups');
if (hasCameras) {
    $('.btn-default').hide();
    $('.allow-others').hide();
}
})(jQuery);