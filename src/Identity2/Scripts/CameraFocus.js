$('.live-feed').click(function () {
    $(this).parent().find('.live-feed').css('border', 'solid 2px black');
    $(this).css('border', 'solid 3px darkred');
    var cameraName = $(this).attr('id');
    $('#currentCamera').html(cameraName);
});
$('.live-feed').on('tap', function () {
    $(this).parent().parent().find('.small-feed').css('border', 'solid 3px black');
    $(this).css('border', 'solid 3px darkred');
});

$('.camera-input').mousedown(function () {
    $(this).css('background-color', '#4bacbd');
});
$('.camera-input').mouseup(function () {
    $(this).css('background-color', 'lightgray');
});