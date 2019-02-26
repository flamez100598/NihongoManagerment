// Sửa thông tin giáo viên
function EditTeacher(idTeacher) {
    var tcDTO = {
        TeacherId: idTeacher,
        TeacherName: $("#tcName_" + idTeacher).val(),
        Age: $("#tcAge_" + idTeacher).val(),
        PhoneNumber: $("#tcPhone_" + idTeacher).val(),
        Email: $("#tcEmail_" + idTeacher).val(),
        Address: $("#tcAddress_" + idTeacher).val(),
        TimeToWork: $("#tcTime_" + idTeacher).val(),
        PricePerHour: $("#tcPrice_" + idTeacher).val(),
        LevelEducation: $("#tcLevel_" + idTeacher).val(),
        Status: $("#tcStatus_" + idTeacher).val()
    };

    if (tcDTO !== null) {
        $.ajax({
            type: "POST",
            url: "/Admin/TeacherManagerment/EditTeacher",
            data: { teacherDTO: tcDTO },
            success: function (result) {
                if (result) {
                    alert("Sửa thông tin thành công!");
                    window.location.reload();
                }
                else {
                    alert("Sửa thông tin thất bại!");
                }
            }
        });
    }
}

// thêm thông tin thời gian làm việc
$('#teacherId').change(function () {
    var TM = true;
    var getteacherId = $('#teacherId').val();
    var teacherId;
    console.log(getteacherId);
    if (getteacherId == null || getteacherId == '') {
        TM = false;
        $('#tbodytimework').empty();
    } else {
        teacherId = parseInt(getteacherId);
    }
    if (TM) {
        $.ajax({
            type: 'POST',
            url: "/Admin/TeacherManagerment/SelectTeacher",
            data: {
                teacherId: teacherId
            },
            success: function (result) {
                var html = "";
                $('#tbodytimework').empty();
                var count = 0;
                $.each(result, function (key, value) {
                    count++;
                    html += '<tr><td>' + count + '</td><td>' + value.TimeHours + '</td><td>' + value.TimeInStr + '</td><td>' + value.TimeOutStr + '</td><td>' + value.Days + '</td><td><span class=icon-menu><i class="fa fa-plus-circle"></i><ul><li>Thêm</li></ul></span></td></tr><tr><td class="row-edit row-edit2 white disabled" id=tw' + value.ID + ' colspan="14"><div class="text-left"><div class="form__table--content"><div class="form__table-col-6"><label for="">Họ và tên:</label><input type="text" value="1" id="1" /></div><div class="form__table-col-6"><label for="">Tuổi:</label><input type="text" value="1" id="1" /></div><div class="form__table-col-6 inputtwo"><label></label><input type="button" value="Hủy" style="margin-right: 59px;"><input type="submit" value="Lưu chỉnh sửa" class="fixnv"></div></div></div></td></tr>';
                });
                $('#tbodytimework').append(html);
            }
        });
    }
});

$('#tbodytimework').on('click', '.icon-menu', function () {
    var idteacher = $(this).parent().prev().find('td:first-child');
    console.log(idteacher);
    jQuery('#testID2').find('#tw' + idteacher).removeClass('disable');
});

//validate
jQuery.extend(jQuery.validator.messages, {
    required: "Không được để trống",
    //remote: "Please fix this field.",
    //email: "Please enter a valid email address.",
    //url: "Please enter a valid URL.",
    //date: "Please enter a valid date.",
    //dateISO: "Please enter a valid date (ISO).",
    number: "Chỉ được nhập chữ số.",
    //digits: "Please enter only digits.",
    //creditcard: "Please enter a valid credit card number.",
    //equalTo: "Please enter the same value again.",
    //accept: "Please enter a value with a valid extension.",
    maxlength: jQuery.validator.format("Không nhập quá {0} kí tự."),
    minlength: jQuery.validator.format("Nhập tối tiểu {0} kí tự."),
    //rangelength: jQuery.validator.format("Please enter a value between {0} and {1} characters long."),
    //range: jQuery.validator.format("Please enter a value between {0} and {1}."),
    //max: jQuery.validator.format("Please enter a value less than or equal to {0}."),
    min: jQuery.validator.format("Không được nhập quá {0}.")
});
$('#CreateTimeWork').validate({
    rules: {
        TimeIn: {
            required: true
        },
        TimeOut: {
            required: true
        },
        TeacherAddTW: {
            required: true
        }
    },
    messages: {
    },
    submitHandler: function (form) {
        CreateTimeWork();
    }
});
function CreateTimeWork() {

    var timekeepingDTO = {
        TimeInStr: $('#datevalin').val(),
        TimeOutStr: $('#datevalout').val(),
        TeacherID: $('#tearcheridaddtw').val()
    };
    $.ajax({
        type: 'POST',
        url: "/Admin/TeacherManagerment/CreateTimekeeping",
        data: {
            timekeepingDTO: timekeepingDTO
        },
        success: function (result) {
            $.notify(result.message, result.status);
            if (result.code === 1) {
                $("#exampleModalCenter").css("display", "none");
                $(".modal-backdrop").css("display", "none");
                $('#CreateTimeWork')[0].reset();
                var html = "";
                $('#tbodytimework').empty();
                var count = 0;
                $.each(result.json, function (key, value) {
                    count++;
                    html += '<tr><td>' + count + '</td><td>' + value.TimeHours + '</td><td>' + value.TimeInStr + '</td><td>' + value.TimeOutStr + '</td><td>' + value.Days + '</td><td><span class=icon-menu><i class="fa fa-plus-circle"></i><ul><li>Thêm</li></ul></span></td></tr><tr><td class="row-edit row-edit2 white disabled" id=tw' + value.ID + ' colspan="14"><div class="text-left"><div class="form__table--content"><div class="form__table-col-6"><label for="">Họ và tên:</label><input type="text" value="1" id="1" /></div><div class="form__table-col-6"><label for="">Tuổi:</label><input type="text" value="1" id="1" /></div><div class="form__table-col-6 inputtwo"><label></label><input type="button" value="Hủy" style="margin-right: 59px;"><input type="submit" value="Lưu chỉnh sửa" class="fixnv"></div></div></div></td></tr>';
                });
                $('#tbodytimework').append(html);
                $("div.teacherchoose select").val(timekeepingDTO.TeacherID);
            }

        }
    });
}