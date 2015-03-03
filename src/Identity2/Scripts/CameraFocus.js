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

$('.camera-input').mouseover(function () {

});
$('.camera-input').mousedown(function () {

});
$('.camera-input').mouseup(function () {

});