$(document).ready(function(){
    $('.owl-carousel').owlCarousel({
        margin:10,
        autoplay: true,
        autoplayTimeout: 5000,
        rewind: true,
        responsive:{
            0:{
                items:1
            },
            600:{
                items:3
            },
            1000:{
                items:4
            }
        }
    });

    // $('.owl-carousel').ready(function(){
    //     $('.owl-carousel').owlCarousel();
    // });
    var currentScroll;
    $(".menu-icon").click(function(){
        $(".navbar-wrap .menu").slideToggle();
        currentScroll=$(window).scrollTop();
    });

    $(window).scroll(function(){
        console.log(currentScroll);
        var afterscroll=$(window).scrollTop();
        if(afterscroll>currentScroll){
            $(".navbar-wrap .menu").slideUp();
        }
    });
    
    $(".scroll-totop").click(function(){
         $('html,body').animate({ scrollTop: 0 }, 'slow');
    });

});