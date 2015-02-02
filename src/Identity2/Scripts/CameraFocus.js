$('.live-feed').click(function () {
    $(this).parent().find('.live-feed').css('border', 'solid 2px black');
    $(this).css('border', 'solid 3px darkred');
});
$('.live-feed').on('tap', function () {
    $(this).parent().parent().find('.small-feed').css('border', 'solid 3px black');
    $(this).css('border', 'solid 3px darkred');
});