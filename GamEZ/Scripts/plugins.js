/* global $ , alert , console */


//$(document).ready(function () {


$(function () {

    //Links Add Active Class

    $(function () {
        $('.navigation ul.navig li a').click(function () {
            $(this).parent().addClass('active').siblings().removeClass('active')
        });
    });


    // Adjust BX Slider Center

    myslider.each(function () {
        $(this).css('paddingTop', ($(window).height() - $('.bxslider li').height()) / 2)
    });

    // Trigger The BX Slider

    myslider.bxSlider({
        pager: false
    });

    // Smoth Scroll to Div

    $('.links li a').click(function () {
        $('html , body').animate({
            scrollTop: $('#' + $(this).data('value')).offset().top
        }, 1000);
    });

    // Our Auto Slider Code

    (function autoslider() {

        $('.slider .active').each(function () {
            if (!$(this).is(':last-child')) {
                $(this).delay(3000).fadeOut(1000, function () {
                    $(this).removeClass('active').next().addClass('active').fadeIn();
                    autoslider();
                });
            }
            else {
                $(this).delay(3000).fadeOut(1000, function () {
                    $(this).removeClass('active');
                    $('.slider div').eq(0).addClass('active').fadeIn();
                    autoslider();
                });
            }
        });
    }());

    // Trigger mixitup

    $('#Container').mixItUp();

    // Adjust Shuffle Links

    $('.shuffle li').click(function () {
        $(this).addClass('selected').siblings().removeClass('selected');
    });

    // Trigger Nice Scroll

    $('html').niceScroll({
        cursorcolor: '#F8937E',
        cursorwidth: '10px',
        cursorborder: 'none',
        zindex: '6'
    });

});

/*});*/



