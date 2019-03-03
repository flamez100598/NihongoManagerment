'use strict'; var Services = function ($) {
    var _is = function _is(selecter) {
        return $(selecter).length != 0;
    };



    return {
        is: _is
    };


}(jQuery);

"use strict";
jQuery(document).ready(function ($) {

    $(window).on('load', function () {
        $('.icon__btn').click(function () {
            $('.sub__menu').toggleClass('active');
            $('#header').toggleClass('over');
        });
    });




});
