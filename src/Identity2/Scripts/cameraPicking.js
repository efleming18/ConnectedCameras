$('.row150px').mouseover(function () {
    $(this).css('background-color', 'aqua');
});
$('.row150px').mouseleave(function () {
    $(this).css('background-color', 'transparent');
})
$('.row150px').click(function () {
    if ($(this).find('.checkboxjquery').prop('checked')) {
        $(this).find('.checkboxjquery').prop('checked', false);
    }
    else {
        $(this).find('.checkboxjquery').prop('checked', true);
    }
    
});