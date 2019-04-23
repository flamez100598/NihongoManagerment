$(document).ready(function () {
    var slider_single_image = $('.slider-single-image');
    if (slider_single_image.length) {
        //select box
        slider_single_image.slick({
            dots: true,
            infinite: true,
            speed: 300,
            slidesToShow: 1,
            autoplay: true,
            arrows: true,
            autoplaySpeed: 1000000,
            adaptiveHeight: true
        });
    }
    $('.owl-carousel').owlCarousel({
        margin: 10,
        autoplay: true,
        autoplayTimeout: 5000,
        rewind: true,
        responsive: {
            0: {
                items: 1
            },
            600: {
                items: 3
            },
            1000: {
                items: 4
            }
        }
    });
    // lazy load
    $(function () {
        $('.lazy').lazy({
            effect: "fadeIn",
            effectTime: 5000,
            threshold: 0
        });
    });
    setTimeout(function () {
        $("#exampleModal").modal('show');
    },500)
    //click modal img
    // Get the modal
    for (var i = 1; i < 4; i++) {
        var modal = document.getElementById('myModal'+i);

        // Get the image and insert it inside the modal - use its "alt" text as a caption
        var img = document.getElementById('myImg'+i);
        var modalImg = document.getElementById("img0"+i);
        var captionText = document.getElementById("caption"+i);
        img.onclick = function () {
            modal.style.display = "block";
            modalImg.src = this.src;
            captionText.innerHTML = this.alt;
        }
        var span = document.getElementsByClassName("close")[i-1];

        // When the user clicks on <span> (x), close the modal
        span.onclick = function () {
            modal.style.display = "none";
        }
        modal.onclick = function () {
            img.className += " out";
            setTimeout(function () {
                modal.style.display = "none";
                img.className = "modal-contentImg";
            }, 400);

        }
    }
    // slider slick
    var slider_single_image = $('.slider-single-image');
    if (slider_single_image.length) {
        //select box
        slider_single_image.slick({
            dots: true,
            infinite: true,
            speed: 300,
            slidesToShow: 1,
            autoplay: true,
            arrows: true,
            autoplaySpeed: 3000,
            adaptiveHeight: true
        });
    }
    // Get the <span> element that closes the modal

    //end click modal img
    // $('.owl-carousel').ready(function(){
    //     $('.owl-carousel').owlCarousel();
    // });
    var currentScroll;
    $(".menu-icon").click(function () {
        $(".navbar-wrap .menu").slideToggle();
        currentScroll = $(window).scrollTop();
    });

    $(window).scroll(function () {
        console.log(currentScroll);
        var afterscroll = $(window).scrollTop();
        if (afterscroll > currentScroll) {
            $(".navbar-wrap .menu").slideUp();
        }
    });

    $(".scroll-totop").click(function () {
        $('html,body').animate({ scrollTop: 0 }, 'slow');
    });

});
//đăng ký khóa học by id
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
                alert("Successfully!")
            }
            else {
                $('#bodymessage').text("Đã xảy ra lỗi! Bạn quay lại đăng ký sau nhé! Hãy thao khảo các khóa học tiếp đi nhé!");
                $('#bodymessage').attr('style', 'display: block; color: red; text-align: center; padding: 50px;');
                alert("fail!")
            }
        }
    });
});
//đăng ký khóa học by class
$('.registerCourse').click(function () {
    $('#bodymessage').after('<img src="/Assets/client/img/loading.gif" class="loader" alt="loading" style="width:100px;height:100px;">').fadeIn();
    var Course = {
        register_name: $('.register_name').val(),
        register_phone: $('.register_phone').val(),
        register_email: $('.register_email').val(),
        register_coursename: $('.register_course').children("option:selected").val(),
        register_message: $('.message-text').val()
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
                alert("Successfully!")
            }
            else {
                $('#bodymessage').text("Đã xảy ra lỗi! Bạn quay lại đăng ký sau nhé! Hãy thao khảo các khóa học tiếp đi nhé!");
                $('#bodymessage').attr('style', 'display: block; color: red; text-align: center; padding: 50px;');
                alert("fail!")
            }
        }
    });
});