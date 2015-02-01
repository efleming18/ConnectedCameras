$('.small-feed').click(function () {
    $(this).parent().parent().find('.small-feed').css('border', 'solid 2px black');
    $(this).css('border', 'solid 2px darkred');
    ActivateCameraInput();
});
$('.small-feed').on('tap', function () {
    $(this).parent().parent().find('.small-feed').css('border', 'solid 3px black');
    $(this).css('border', 'solid 3px darkred');
    ActivateCameraInput();
});

$('.medium-feed').click(function () {
    $(this).parent().parent().find('.medium-feed').css('border', 'solid 2px black');
    $(this).css('border', 'solid 2px darkred');
    ActivateCameraInput();
    $('current-camera').html('')
});
$('.medium-feed').on('tap', function () {
    $(this).parent().parent().find('.medium-feed').css('border', 'solid 3px black');
    $(this).css('border', 'solid 3px darkred');
    ActivateCameraInput();
});

$('.large-feed').click(function () {
    $(this).parent().parent().find('.large-feed').css('border', 'solid 2px black');
    $(this).css('border', 'solid 2px darkred');
    ActivateCameraInput();
});
$('.large-feed').on('tap', function () {
    $(this).parent().parent().find('.large-feed').css('border', 'solid 3px black');
    $(this).css('border', 'solid 3px darkred');
    ActivateCameraInput();
});

function ActivateCameraInput() {
    if ($('.camerainput').height() < 200) {
        $('.camerainput').animate({ height: '+=250px' });
    }
}