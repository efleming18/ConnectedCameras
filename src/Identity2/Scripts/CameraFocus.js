var feed = $('.fill');

$(document).ready(function () {
    var fixHeight = $('.camera-controller').css('height');
    var fixWidth = $('.camera-controller').css('width');
    $('.camera-controller').height(fixHeight);
    $('.camera-controller').width(fixWidth);
});
feed.click(function () {
    $(document).find('.fill').css('border', '');
    $(this).css('border', 'solid 2px red');
});


$('.camera-input').mousedown(function () {
    $(this).css('background-color', '#4bacbd');
});
$('.camera-input').mouseup(function () {
    $(this).css('background-color', 'lightgray');
});

$('.arrow-up').mousedown(function () {
    $(this).parent().css('background-color', '#4bacbd')
});
$('.arrow-down').mousedown(function () {
    $(this).parent().css('background-color', '#4bacbd')
});
$('.arrow-left').mousedown(function () {
    $(this).parent().css('background-color', '#4bacbd')
});
$('.arrow-right').mousedown(function () {
    $(this).parent().css('background-color', '#4bacbd')
});