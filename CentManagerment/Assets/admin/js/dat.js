$(document).ready(function () {

    $('.updateuser').click(function () {
        var getidhs = this.id;
        var idhs = getidhs.substring(11, this.id.length);
        var stdto = {
            StudentId: idhs,
            StudentPhone: $('#stphone-' + idhs).val(),
            StudentName: $('#stname-' + idhs).val(),
            StudentAdress: $('#staddress-' + idhs).val(),
            StudentEmail: $('#stmail-' + idhs).val(),
            StudentMark: $('#stmark-' + idhs).val(),
            StudentSchoolFee: $('#stschoolfee-' + idhs).val(),
            StudentSchoolFeeStatus: $('#ststatus-' + idhs).val(),
        };
        $.ajax({
            url: "/StudentManagerment/UpdateStudent",
            type: "POST",
            data: { stdto: stdto },
            success: function (resultCode) {
                if (resultCode === 1) {
                    alert("Sửa học viên thành công!");
                    window.location.reload();
                } else {
                    alert("Đã sảy ra lỗi khi sửa!");
                    return false;
                }
            }
        });
    });

    $('.deleteuser').click(function () {
        var getidhs = this.id;
        var idhs = getidhs.substring(11, this.id.length);
        $.ajax({
            url: "/StudentManagerment/DeleteStudent",
            type: "POST",
            data: { idStudent: idhs },
            success: function (resultCode) {
                if (resultCode === 1) {
                    alert("Xóa học viên thành công!");
                    window.location.reload();
                } else {
                    alert("Đã sảy ra lỗi khi xóa!");
                    return false;
                }
            }
        });
    });

    $('#addst').click(function () {
        var stdto = {
            StudentPhone: $('#stphone').val(),
            StudentName: $('#stname').val(),
            StudentAdress: $('#staddress').val(),
            StudentEmail: $('#stmail').val(),
            StudentMark: $('#stmark').val(),
            StudentSchoolFee: $('#stschoolfee').val(),
            StudentSchoolFeeStatus: $('#ststatus').val(),
            StudentClassID: $('#classId option:selected').val()
        };
        $.ajax({
            url: "/StudentManagerment/AddNewStudent",
            type: "POST",
            data: { stdto: stdto },
            success: function (resultCode) {
                console.log(stdto)
                if (resultCode === 1) {
                    alert("Thêm học viên thành công!");
                    window.location.reload();
                } else {
                    alert("Đã sảy ra lỗi khi thêm!");
                    return false;
                }
            }
        });
    });
    //Created by: Dung
    $('#classId').change(function () {
        var classId = $('#classId option:selected').val();
        $.ajax({
            url: "/StudentManagerment/ClassSelect",
            type: 'POST',
            data: { classId: classId },
            success: function (result) {
                console.log(result);
                $('#className').val(result.ClassName);
            }
        })
    })

    $('#sendrequest').click(function () {
        return false;
    });

    $('#btn--save-new').click(function () {
        var newdto = {
            NewsContent: /*$('#main-content').val(),*/ CKEDITOR.instances['main-content'].getData(),
            NewsShortContent: $('#short-content').val(),
            NewsTitle: $('#new-title').val(),
            NewsAvatar: $('#avatar-news').attr('src'),
        };
        var type = $('#IdTT').val();
        $.ajax({
            url: "/News/AddNews",
            type: "POST",
            data: { newdto: newdto, type: type },
            success: function (resultCode) {
                if (type !== null) {
                    if (resultCode === 1) {
                        alert("Sửa thành công!");
                        window.location.reload();
                    } else {
                        alert("Đã sảy ra lỗi khi sửa!");
                        return false;
                    }
                } else {
                    if (resultCode === 1) {
                        alert("Thêm tin tức thành công!");
                        window.location.reload();
                    } else {
                        alert("Đã sảy ra lỗi khi thêm!");
                        return false;
                    }
                }

            }
        });
    });


    $('.xoatt').click(function () {
        var getidnew = this.id;
        var idnew = getidnew.substring(4, this.id.length);

        $.ajax({
            url: "/News/DeleteNew",
            type: "POST",
            data: { idnew: idnew },
            success: function (resultCode) {
                if (resultCode === 1) {
                    alert("Xóa tin tức thành công!");
                    window.location.reload();
                } else {
                    alert("Đã sảy ra lỗi khi xóa!");
                    return false;
                }
            }
        });
    });
    //$('#addst').click(function () {
    //    var stdto = {
    //        StudentPhone: $('#stphone').val(),
    //        StudentName: $('#stname').val(),
    //        StudentAdress: $('#staddress').val(),
    //        StudentEmail: $('#stmail').val(),
    //        StudentMark: $('#stmark').val(),
    //        StudentSchoolFee: $('#stschoolfee').val(),
    //    };
    //    $.ajax({
    //        url: "/StudentManagerment/AddNewStudent",
    //        type: "POST",
    //        data: { stdto: stdto },
    //        success: function (resultCode) {
    //            if (resultCode === 1) {
    //                alert("Thêm học viên thành công!");
    //                window.location.reload();
    //            } else {
    //                alert("Đã sảy ra lỗi khi thêm!");
    //                return false;
    //            }
    //        }
    //    });
    //});
});

var avatarNews = "";
$('#avatar-button').on('change', function () {
    if ($(this)[0].files.length > 0) {
        var dungluong = (this.files[0].size / 1024 / 1024).toFixed(3);
        if (parseInt(dungluong) > 3) {
            alert("Ảnh có dụng lượng tối đa 3MB. Hãy chọn ảnh khác nhé bạn!");
        } else {
            if (ValidateImage($(this)[0].files[0].name)) {
                GetFileImage($(this));
            } else {
                $('.update-image').val("");
            }
        }
    }
});
//validate image upload
function ValidateImage(classdiv) {
    if (classdiv != '') {
        var checkimg = classdiv.toLowerCase();
        if (!checkimg.match(/(\.jpg|\.png|\.JPG|\.PNG|\.gif|\.GIF|\.jpeg|\.JPEG)$/)) {
            alert("Vui lòng chọn hình ảnh đúng định dạng .jpg,.png,.jpeg,.gif");
            return false;
        }
    }
    return true;
}
//upload image
function GetFileImage(btn) {
    //Lấy dữ liệu trên fileUpload
    var fileUpload = $("." + $(btn).attr('class')).get(0);
    var files = $(btn)[0].files;
    // Đối tượng formdata
    var formData = new FormData();
    var iddiv = $(btn).attr('id');
    var classdiv = $(btn).attr('class');
    formData.append('file', files[0]);
    $.ajax({
        type: 'POST',
        url: '/HomeAdmin/UploadFileImage',
        contentType: false,
        processData: false,
        data: formData,
        success: function (urlImage) {
            avatarNews = urlImage;
            $("#avatar-news").attr("src", avatarNews);
            //if (iddiv === "file-img-banner") {
            //    imageBanner = urlImage;
            //    if (classdiv !== "")
            //        $("#image-fix-banner").attr("src", imageBanner);
            //} else if (iddiv === "file-img-user") {
            //    imageUser = urlImage;
            //    $("#image-user").attr("src", imageUser);
            //} else if (iddiv === "uplogofile") {
            //    logoWebsite = urlImage;
            //    $("#logowebsite").attr("src", logoWebsite);
            //} else if (iddiv === "avatar-bt") {
            //    avatarNews = urlImage;
            //    $("#avatar-news").attr("src", avatarNews);
            //} else if (iddiv === "upfilelicense") {
            //    imageLicense = urlImage;
            //    $("#imagelicense").attr("src", imageLicense);
            //    //imagelicense
            //} else { }
        },
        error: function (err) {
            alert("Có lỗi!");
        }
    });
}