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
    var teacherId = $('#teacherId').val();
    $.ajax({
        url: "/Admin/TeacherManagerment/SelectTeacher",
        type: 'POST',
        data: { teacherId: teacherId },
        success: function (result) {
            var html = "";
            for (var i = 0; i < result.length; i++) {
                html += '<tr>';
                html += '<td>' + (i + 1) + '</td>';
                html += '<td id="idtimework" style="color:blue; cursor:pointer">' + result[i].Id + '</td>';
                html += '<td>' + result[i].Hours + '</td>';
                html += '<td><input type="date" value="' + result[i].DateStr + '" readonly style="border:none;background:transparent;padding-left: 70px;"/></td>';
                html += '<td>';
                html += '<i class="fa fa-trash" aria-hidden="true" id="deltimework" id-time="' + result[i].Id + '" style="cursor:pointer"></i>';
                html += '</td>';
                html += '</tr>';
            }
            $("#body-table").html(html);
        }
    })
})

var idTimeWork;
$(document).on('click', '#idtimework', function () {
    idTimeWork = this.innerText;
    $.ajax({
        type: 'post',
        url: '/Admin/TeacherManagerment/GetTimeWork',
        data: { id: idTimeWork },
        success: function (resp) {
            $("#idwork").val(idTimeWork);
            $("#timework").val(resp.Hours);
            $("#datework").val(resp.DateStr);
        }
    });
})

$("#edit-timework").click(function () {
    var time = $("#timework").val();
    var date = $("#datework").val();
    if (time != "") {
        try {
            $.ajax({
                type: 'post',
                url: '/Admin/TeacherManagerment/Edit',
                data: { time: time, date: date, id: idTimeWork },
                success: function (resp) {
                    if (resp.check) {
                        var html = "";
                        if (resp.result != null) {
                            for (var i = 0; i < resp.result.length; i++) {
                                html += '<tr>';
                                html += '<td>' + (i + 1) + '</td>';
                                html += '<td id="idtimework" style="color:blue; cursor:pointer">' + resp.result[i].Id + '</td>';
                                html += '<td>' + resp.result[i].Hours + '</td>';
                                html += '<td><input type="date" value="' + resp.result[i].DateStr + '" readonly style="border:none;background:transparent;padding-left: 70px;"/></td>';
                                html += '<td>';
                                html += '<i class="fa fa-trash" aria-hidden="true" id="deltimework" id-time="' + resp.result[i].Id + '" style="cursor:pointer"></i>';
                                html += '</td>';
                                html += '</tr>';
                            }
                        }
                        $("#body-table").html(html);
                        alert("Sửa thành công!");
                    }
                    else {
                        alert("Sửa thất bại!");
                    }
                },
                error: function () {
                    alert("Kiểm tra lại dữ liệu!");
                }
            })
        }
        catch (e) {
            alert("Kiểm tra lại dữ liệu!");
        }
    } else {
        alert("Kiểm tra lại dữ liệu!");
    }


})



$("#add-timework").click(function () {
    var time = $("#timework").val();
    var date = $("#datework").val();
    var idTeacher = $('#teacherId').val();
    if (time != "" && date != null && date != "") {
        $.ajax({
            type: 'post',
            url: '/Admin/TeacherManagerment/Create',
            data: { time: time, date: date, id: idTeacher },
            success: function (resp) {
                if (resp.check) {
                    var html = "";
                    if (resp.result != null) {
                        
                        for (var i = 0; i < resp.result.length; i++) {
                            html += '<tr>';
                            html += '<td>' + (i + 1) + '</td>';
                            html += '<td id="idtimework" style="color:blue; cursor:pointer">' + resp.result[i].Id + '</td>';
                            html += '<td>' + resp.result[i].Hours + '</td>';
                            html += '<td><input type="date" value="' + resp.result[i].DateStr + '" readonly style="border:none;background:transparent;padding-left: 70px;"/></td>';
                            html += '<td>';
                            html += '<i class="fa fa-trash" aria-hidden="true" id="deltimework" id-time="' + resp.result[i].Id + '" style="cursor:pointer"></i>';
                            html += '</td>';
                            html += '</tr>';
                        }
                        
                    }
                    $("#body-table").html(html);
                    $("#timework").val("");
                    $("#datework").val("");
                    alert("Thêm thành công!");
                }
                else {
                    alert("Thêm thất bại!");
                }
            }
        })
    }
})

$("#clear-timework").click(function () {
    $("#idwork").val("");
    $("#timework").val("");
    $("#datework").val("");
    idTimeWork = null;
})

$(document).on('click', '#deltimework', function () {
    var idTimeWork = this.getAttribute("id-time");
    var a = window.confirm("Bạn có muốn xóa bản ghi này không ?");
    if (a) {
        $.ajax({
            type: 'post',
            url: '/Admin/TeacherManagerment/Delete',
            data: { id: idTimeWork },
            success: function (resp) {
                if (resp.check) {
                    var html = "";
                    if (resp.result != null) {
                        
                        for (var i = 0; i < resp.result.length; i++) {
                            html += '<tr>';
                            html += '<td>' + (i + 1) + '</td>';
                            html += '<td id="idtimework" style="color:blue; cursor:pointer">' + resp.result[i].Id + '</td>';
                            html += '<td>' + resp.result[i].Hours + '</td>';
                            html += '<td><input type="date" value="' + resp.result[i].DateStr + '" readonly style="border:none;background:transparent;padding-left: 70px;"/></td>';
                            html += '<td>';
                            html += '<i class="fa fa-trash" aria-hidden="true" id="deltimework" id-time="' + resp.result[i].Id + '" style="cursor:pointer"></i>';
                            html += '</td>';
                            html += '</tr>';
                        }
                    }
                    $("#body-table").html(html);
                    $("#timework").val("");
                    $("#datework").val("");
                    alert("Xóa thành công!");

                }
                else {
                    alert("Xóa thất bại!");
                }
            }
        })
    }
})