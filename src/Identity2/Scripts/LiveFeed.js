﻿var feed = $('.fill');
var browserWindow = $(window);
var cameraInput = $('.camera-input');
var currentCamera;
var camerasInFeed;

var arrowMouseLeave = "../../Content/Images/Arrow.png";
var arrowMouseOver = "../../Content/Images/Arrow-mouse-over.png";
var arrowMouseDown = "../../Content/Images/Arrow-mouse-down.png";

$(document).ready(function () {
    setCameraControllerHeight();
    setAttributesPanelHeight();

    feed.click(function () {
        $(document).find('.fill').css('border', '');
        $(this).css('border', 'solid 2px red');
        currentCamera = $(this).attr('id');
        $('#currentFocus').html(currentCamera);
    });
    cameraInput.mouseover(function () {
        $(this).attr("src", arrowMouseOver);
    });
    cameraInput.mouseleave(function () {
        $(this).attr("src", arrowMouseLeave);
    });
    cameraInput.mousedown(function () {
        $(this).attr("src", arrowMouseDown);
    });
    cameraInput.mouseup(function () {
        $(this).attr("src", arrowMouseOver);
    });
    var fifteenMinutes = 60 * 15;
    startTimer(fifteenMinutes);
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

function startTimer(duration) {
    var display = $('#timeRemaining');
    var timer = duration, minutes, seconds;
    setInterval(function () {
        minutes = parseInt(timer / 60, 10)
        seconds = parseInt(timer % 60, 10);

        minutes = minutes < 10 ? "0" + minutes : minutes;
        seconds = seconds < 10 ? "0" + seconds : seconds;

        display.text(minutes + ":" + seconds);

        if (--timer < 0) {
            bootUser();
        }
    }, 1000);
}
function bootUser() {
    var url = "/Cameras/Pick";
    window.location.href = url;
}
function getRemainingTime()
{
    $.ajax({
        type: 'get',
        dataType: 'json',
        cache: false,
        url: '/Cameras/GetRemainingTime',
        data: { keyid: 1, newval: 10 },
        success: function (timeLeft) {
            startTimer(timeLeft * 60);
        },
        error: bootUser()
    });
}