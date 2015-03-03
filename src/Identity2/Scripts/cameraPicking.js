var lightBlue = '#4BACBD';
var blue = '#16788A';
var darkBlue = '#0B3C45';

var lightGray = '#D1D7EB';
var gray = '#9EA4B8';
var darkGray = '#50525C';

var lightRed = '#ED8C8F';
var red = '#BA575B';
var darkRed = '#5C2B2B';

$(document).ready(function () {
    if ($(this).find('.checkboxjquery').prop('checked')) {
        ToggleRed($(this));
        return;
    }
    ToggleGray($(this));
    var fixHeight = $('.pick-panel').css('height');
    $('.pick-panel').height(fixHeight);
});

$('.row150px').mouseover(function () {
    if ($(this).find('.checkboxjquery').prop('checked')) {
        ToggleRed($(this));
        return;
    }
    ToggleBlue($(this));
});
$('.row150px').mouseleave(function () {
    $(this).css('background-color', 'transparent');
    if ($(this).find('.checkboxjquery').prop('checked')) {
        ToggleRed($(this));
        return;
    }
    ToggleGray($(this));
})
$('.row150px').click(function () {
    if ($(this).find('.checkboxjquery').prop('checked')) {
        $(this).find('.checkboxjquery').prop('checked', false);
        ToggleBlue($(this));
        return;
    }
    $(this).find('.checkboxjquery').prop('checked', true);
    ToggleRed($(this));
    
});
function ToggleBlue(element)
{
    element.find('.darker').css('background-color', darkBlue);
    element.find('.dark-row').css('background-color', blue);
    element.find('.light').css('background-color', lightBlue);
}
function ToggleRed(element)
{
    element.find('.darker').css('background-color', darkRed);
    element.find('.dark-row').css('background-color', red);
    element.find('.light').css('background-color', lightRed);
}
function ToggleGray(element)
{
    element.find('.darker').css('background-color', darkGray);
    element.find('.dark-row').css('background-color', gray);
    element.find('.light').css('background-color', lightGray);
}