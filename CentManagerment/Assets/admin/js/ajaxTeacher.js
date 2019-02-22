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
    var TimeWorkId = $('#teacherId').val();
    console.log(TimeWorkId);
    $.ajax({
        url: "/Admin/TeacherManagerment/SelectTeacher",
        type: 'POST',
        data: { TimeWorkId: TimeWorkId },
        success: function (result) {
            console.log(result);
        }
    })
})