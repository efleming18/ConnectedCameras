﻿$('.cameraframe').click(function () {
    $(this).parent().parent().find('.cameraframe').css('border', 'solid 3px black');
    $(this).css('border', 'solid 3px red');
    if ($('.camerainput').height() < 200) {
        $('.camerainput').animate({ height: '+=200px' });
    }
});
$('.small-feed').click(function () {
    $(this).parent().parent().find('.small-feed').css('border', 'solid 2px black');
    $(this).css('border', 'solid 2px red');
    if ($('.camerainput').height() < 200) {
        $('.camerainput').animate({ height: '+=200px' });
    }
})

$('.cameraframe').on('tap', function () {
    $(this).parent().parent().find('.cameraframe').css('border', 'solid 3px black');
    $(this).css('border', 'solid 3px red');
});