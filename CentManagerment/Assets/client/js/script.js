﻿$(document).ready(function(){
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
//đăng ký khóa học
$('#registerCourse').click(function () {
    $('#bodymessage').after('<img src="/Assets/client/img/loading.gif" class="loader" alt="loading" style="width:100px;height:100px;">').fadeIn(); 
    var Course = {
        register_name: $('#register_name').val(),
        register_phone: $('#register_phone').val(),
        register_email: $('#register_email').val(),
        register_coursename: $('#register_course').children("option:selected").val(),
        register_message: $('#message-text').val()
    };
    console.log(Course);
    $.ajax({
        type: "POST",
        url: "/Home/SendEmail",
        data: { rgdto: Course },
        success: function (result) {
            $('.modal-content img.loader').fadeOut('fast', function () { $(this).remove(); });
            if (result) {
                $('#bodymessage').text("Gửi thông tin thành công! Hãy tham khảo các khóa học và đăng ký tiếp nhé!");
                $('#bodymessage').attr('style', 'display: block; color: green; text-align: center; padding: 50px;');
            }
            else {
                $('#bodymessage').text("Đã xảy ra lỗi! Bạn quay lại đăng ký sau nhé! Hãy thao khảo các khóa học tiếp đi nhé!");
                $('#bodymessage').attr('style', 'display: block; color: red; text-align: center; padding: 50px;');
            }
        }
    });
});