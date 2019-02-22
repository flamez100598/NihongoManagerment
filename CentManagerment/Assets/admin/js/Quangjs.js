function EditUserManager(i) {
    if ($($('.UserType').get(i)).val() === "" || $($('.UserPassword').get(i)).val() === ""
        || $($('.FullName').get(i)).val() === "" || $($('.UserPhoneNumber').get(i)).val() === "") {
        alert("Bạn phải chọn/điền thông tin trước khi sửa");
    }
    else if ($($('.UserPhoneNumber').get(i)).val().length > 16) {
        alert("Số điện thoại từ 16 ký tự trờ xuống");
    }
    else {
        var User = {
            FullName: $($('.FullName').get(i)).val(),
            UserId: $($('.UserId').get(i)).val(),
            UserType: $($('.UserType').get(i)).val(),
            UserPhoneNumber: $($('.UserPhoneNumber').get(i)).val(),
            UserPassword: $($('.UserPassword').get(i)).val()
        };
        $.ajax({
            type: "POST",
            url: "/Admin/Employee/UpdateUser",
            data: { userManager: User },
            success: function (resultCode) {
                if (resultCode) {
                    alert("Sửa Thành Công!");
                    window.location.reload();
                    return true;
                }
                else {
                    alert("Sửa Thất Bại");
                    return false;
                }
            }
        });
    }
}
$('.InsertEmployee').on('click', function () {
    if ($('.UserType').val() === "" || $('.UserPassword').val() === ""
        || $('.UserName').val() === "" || $('.FullName').val() === ""
        || $('.UserPhoneNumber').val() === "") {
        alert("Bạn phải chọn/điền thông tin trước khi thêm");
    }
    else if ($('.UserPassword').val() !== $('.RePassword').val())
        alert("Mật khẩu nhập lại phải giống mật khẩu");
    else if ($('.UserPhoneNumber').val().length > 16) {
        alert("Số điện thoại từ 16 ký tự trờ xuống");
    }
    else {
        var User = {
            UserType: $('.UserType').val(),
            FullName: $('.FullName').val(),
            UserName: $('.UserName').val(),
            UserPhoneNumber: $('.UserPhoneNumber').val(),
            UserPassword: $('.UserPassword').val()
        };
        $.ajax({
            type: "POST",
            url: "/Admin/Employee/AddUser",
            data: { userManager: User },
            success: function (resultCode) {
                if (resultCode === 1) {
                    alert("Thêm Thành Công!");
                    window.location.href = "/Admin/Employee";
                    return true;
                }
                else if (resultCode === 2) {
                    alert("Tên tài khoản đã tồn tại");
                    $('.UserName').val("");
                    $('.UserName').focus();
                    return false;
                }
                else {
                    alert("Có lỗi khi thêm tài khoản");
                    return false;
                }
            }
        });
    }
});
for (let i = 0; i < $('.UserPhoneNumber').length; i++) {
    $($('.UserPhoneNumber').get(i)).keypress(function (evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode;
        if ($($('.UserPhoneNumber').get(i)).val().length === 0) {
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                if (charCode === 43)
                    return true;
                else
                    return false;
            }
        } else {
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            else
                return true;
        }
    });
}
for (let i = 0; i < $('.cancelEditUser').length; i++) {
    $($('.cancelEditUser').get(i)).on('click', function () {
        $($('.editUserPanel').get(i)).removeClass('active');
    });
    $($('.deleteUser').get(i)).on('click', function () {
        var User = {
            UserId: $($('.UserId').get(i)).val()
        };
        $.ajax({
            type: "POST",
            url: "/Admin/Employee/DeleteUser",
            data: { userManager: User },
            success: function (resultCode) {
                if (resultCode) {
                    alert("Xóa Thành Công!");
                    window.location.reload();
                    return true;
                }
                else {
                    alert("Xóa Thất Bại");
                    return false;
                }
            }
        });
    });
}
$('#btn_EditProfile').on('click', function () {
    if ($('.UserType').val() === "" || $('.UserPassword').val() === ""
        || $('.UserName').val() === "" || $('.FullName').val() === ""
        || $('.UserPhoneNumber').val() === "") {
        alert("Bạn phải chọn/điền thông tin trước khi cập nhật");
    }
    else if ($('.UserPassword').val() !== $('.RePassword').val())
        alert("Mật khẩu nhập lại phải giống mật khẩu");
    else if ($('.UserPhoneNumber').val().length > 16) {
        alert("Số điện thoại từ 16 ký tự trờ xuống");
    }
    else {
        var User = {
            UserId: $('.UserId').val(),
            FullName: $('.FullName').val(),
            UserPhoneNumber: $('.UserPhoneNumber').val(),
            UserPassword: $('.UserPassword').val(),
            UserType: $('.UserType').val(),
            UserName: $('.UserName').val()
        };
        $.ajax({
            type: "POST",
            url: "/Admin/EditProfile/EditUrProfile",
            data: { user: User },
            success: function (resultCode) {
                if (resultCode) {
                    alert("Cập Nhật Thành Công!");
                    window.location.reload();
                    return true;
                }
                else {
                    alert("Có lỗi khi cập nhật");
                    return false;
                }
            }
        });
    }
});
var check = false;
var UserName = "";
function SelectEmployee(i) {
    if ($(".radioCheck").get(i).checked) {
        UserName = $($(".UserName").get(i)).val();
        check = true;
    }
    $.ajax({
        type: "post",
        url: "/Admin/Employee/Decentralization",
        data: { UserName: UserName },
        success: function (re) {
            if (re.resultCode) {
                if (re.listCheck.includes(1)) {
                    $("#StudentHandle").prop("checked", true);
                } else {
                    $("#StudentHandle").prop("checked", false);
                }
                if (re.listCheck.includes(2)) {
                    $("#CourseHandle").prop("checked", true);
                } else {
                    $("#CourseHandle").prop("checked", false);
                }
                if (re.listCheck.includes(3)) {
                    $("#NewsHandle").prop("checked", true);
                } else {
                    $("#NewsHandle").prop("checked", false);
                }
                if (re.listCheck.includes(4)) {
                    $("#TeacherHandle").prop("checked", true);
                } else {
                    $("#TeacherHandle").prop("checked", false);
                }
                if (re.listCheck.includes(5)) {
                    $("#SignupHandle").prop("checked", true);
                } else {
                    $("#SignupHandle").prop("checked", false);
                }
                if (re.listCheck.includes(6)) {
                    $("#RevenueHandle").prop("checked", true);
                } else {
                    $("#RevenueHandle").prop("checked", false);
                }
                if (re.listCheck.includes(7)) {
                    $("#EmployeeHandle").prop("checked", true);
                } else {
                    $("#EmployeeHandle").prop("checked", false);
                }
                if (re.listCheck.includes(8)) {
                    $("#CustomsHandle").prop("checked", true);
                } else {
                    $("#CustomsHandle").prop("checked", false);
                }
            }
        }
    });
}
var listType = new Array;
$("#submitHandle").click(function () {
    listType = [];
    for (var i = 0; i < $(".HandlerType").length; i++) {
        if ($(".HandlerType").get(i).checked) {
            listType.push(parseInt($($(".HandlerType").get(i)).val()));
        }
    }
    if (check) {
        console.log(listType);
        $.ajax({
            type: "POST",
            url: "/Admin/Employee/AddHandle",
            data: { UserName: UserName, listType: listType },
            success: function (resultCode) {
                if (resultCode) {
                    alert("Phân quyền thành công!");
                    window.location.reload();
                }
                else {
                    alert("Xảy ra lỗi khi phân quyền");
                }
            }
        });
    } else {
        alert("Bạn phải chọn nhân viên để phân quyền!");
    }
});