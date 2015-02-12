$('.row90percent').mouseover(function () {
    $(this).css('background-color', 'aqua');
});
$('.row90percent').mouseleave(function () {
    $(this).css('background-color', 'transparent');
})
$('.row90percent').click(function () {
    if ($(this).find('.checkboxjquery').prop('checked')) {
        $(this).find('.checkboxjquery').prop('checked', false);
    }
    else {
        $(this).find('.checkboxjquery').prop('checked', true);
    }
    
});