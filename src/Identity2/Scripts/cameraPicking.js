var lightBlue = '#4BACBD';
var blue = '#16788A';
var darkBlue = '#0B3C45';

var lightGray = '#D1D7EB';
var gray = '#9EA4B8';
var darkGray = '#50525C';

var lightRed = '#ED8C8F';
var red = '#BA575B';
var darkRed = '#5C2B2B';

$('.row150px').mouseover(function () {
    $(this).css('background-color', 'aqua');
    $(this).find('.darker').css('background-color', darkBlue);
    $(this).find('.dark-row').css('background-color', blue);
    $(this).find('.light').css('background-color', lightBlue);
});
$('.row150px').mouseleave(function () {
    $(this).css('background-color', 'transparent');
    $(this).find('.darker').css('background-color', darkGray);
    $(this).find('.dark-row').css('background-color', gray);
    $(this).find('.light').css('background-color', lightGray);
})
$('.row150px').click(function () {
    if ($(this).find('.checkboxjquery').prop('checked')) {
        $(this).find('.checkboxjquery').prop('checked', false);
    }
    else {
        $(this).find('.checkboxjquery').prop('checked', true);
    }
    
});