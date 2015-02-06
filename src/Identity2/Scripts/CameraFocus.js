$('.feed-content').click(function () {
    $(this).parent().parent().find('.feed-content').css('border', 'solid 2px black');
    $(this).css('border', 'solid 3px red');
    var cameraName = $(this).attr('id');
    $('#currentCamera').html(cameraName);
});
$('.feed-content').on('tap', function () {
    $(this).parent().parent().find('.feed-content').css('border', 'solid 3px black');
    $(this).css('border', 'solid 3px red');
});

//$('.camera-input').mousedown(function () {
//    $(this).css('background-color', '#4bacbd');
//});
//$('.camera-input').mouseup(function () {
//    $(this).css('background-color', 'lightgray');
//});

$('.arrow-up').mousedown(function () {
    $(this).css('background-color', '#4bacbd');
});
$('.arrow-down').mousedown(function () {
    $(this).css('background-color', '#4bacbd');
});
$('.arrow-left').mousedown(function () {
    $(this).css('background-color', '#4bacbd');
});
$('.arrow-right').mousedown(function () {
    $(this).css('background-color', '#4bacbd');
});