$(document).ready(function ($) {

    var nav = $('.top-bar');

    $(window).scroll(function () {
        if ($(this).scrollTop() > 600) {
            nav.show('slow', 'swing');
        } else {
            nav.hide('slow', 'swing');
        }
    });

});