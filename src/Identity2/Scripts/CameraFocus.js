$('.small-feed').click(function () {
    $(this).parent().parent().find('.small-feed').css('border', 'solid 2px black');
    $(this).css('border', 'solid 2px red');
    if ($('.camerainput').height() < 200) {
        $('.camerainput').animate({ height: '+=200px' });
    }
});
$('.small-feed').on('tap', function () {
    $(this).parent().parent().find('.small-feed').css('border', 'solid 3px black');
    $(this).css('border', 'solid 3px red');
});

$('.medium-feed').click(function () {
    $(this).parent().parent().find('.medium-feed').css('border', 'solid 2px black');
    $(this).css('border', 'solid 2px red');
    if ($('.camerainput').height() < 200) {
        $('.camerainput').animate({ height: '+=200px' });
    }
});
$('.medium-feed').on('tap', function () {
    $(this).parent().parent().find('.medium-feed').css('border', 'solid 3px black');
    $(this).css('border', 'solid 3px red');
});

$('.large-feed').click(function () {
    $(this).parent().parent().find('.large-feed').css('border', 'solid 2px black');
    $(this).css('border', 'solid 2px red');
    if ($('.camerainput').height() < 200) {
        $('.camerainput').animate({ height: '+=200px' });
    }
});
$('.large-feed').on('tap', function () {
    $(this).parent().parent().find('.large-feed').css('border', 'solid 3px black');
    $(this).css('border', 'solid 3px red');
});