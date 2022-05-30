$(document).ready(function () {
    $('.carousel').carousel({
        interval: 6000
    });


    $(function () {
        $(".navbar-inverse .navbar-nav li").click(function () {
            if ($(".navbar-inverse .navbar-nav li").hasClass("active")) {
                $(".navbar-inverse .navbar-nav li").removeClass("active");
            }
            $(this).addClass("active");
        });
    });


});




