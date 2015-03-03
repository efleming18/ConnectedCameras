var feed = $('.fill');

$(document).ready(function () {
    setCameraControllerHeight();
    setAttributesPanelHeight();
});
feed.click(function () {
    $(document).find('.fill').css('border', '');
    $(this).css('border', 'solid 2px red');
});
function setCameraControllerHeight() {
    var fixHeight = $('.camera-controller').css('height');
    var fixWidth = $('.camera-controller').css('width');
    $('.camera-controller').height(fixHeight);
    $('.camera-controller').width(fixWidth);
}
function setAttributesPanelHeight() {
    var totalHeight = $('.camera-controller').height();
    var controlsHeight = $('#controls').height();
    var attributeHeight = totalHeight - controlsHeight;
    $('#attributes').height(attributeHeight);
}

$('.camera-input').mouseover(function () {

});
$('.camera-input').mousedown(function () {

});
$('.camera-input').mouseup(function () {

});