$('.cameraframe').click(function () {
    $(this).parent().parent().find('.cameraframe').css('border', 'solid 3px black');
    $(this).css('border', 'solid 3px red');
})

$('.cameraframe').on('tap', function () {
    $(this).parent().parent().find('.cameraframe').css('border', 'solid 3px black');
    $(this).css('border', 'solid 3px red');
})