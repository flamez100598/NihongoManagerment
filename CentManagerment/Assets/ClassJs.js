// delete class by id ajax
function DeleteClass(classId) {
    var confirms = confirm("Do you want delete it!");
    if (confirms) {
        console.log(confirms)
        console.log(classId)
        $.ajax({
            type: 'POST',
            url: "/ClassManagerment/Delete",
            data: { classId },
            success: function (result) {
                console.log(result)
                alert("success!");
                location.reload();
            }
        })
    }
}
/// get course by id ajax
$('#courseId').change(function () {
    var courseId = $('#courseId option:selected').val();
    console.log(courseId);
    $.ajax({
        url: "/ClassManagerment/CourseSelect",
        type: 'POST',
        data: { courseId: courseId },
        success: function (result) {
            console.log(result);
            $('#courseStartDate').val(moment(result.StartDate).format('l'));
            $('#courseEndDate').val(moment(result.EndDate).format('l'));
            $('#courseName').val(result.CourseName);
            $('#coursePrice').val(result.Price);
            $('#Id').val(result.CourseId);
        }
    })
})
//get list student by class
function GetList(id) {
    var idClass = id;
    var str = "";
    console.log(idClass);
    $.ajax({
        url: "/ClassManagerment/GetStudentByClass",
        type: 'POST',
        data: { idClass: idClass },
        success: function (result) {
            if (result.length > 0) {
                for (var i = 0; i < result.length; i++) {
                    $('#tb_' + result[i].StudentClassID + ' tbody').empty();
                    str += "<tr><td>" + result[i].StudentId + "</td>" + "<td>" + result[i].StudentName + "</td>" +
                        "<td>" + result[i].StudentMark + "</td>" + "<td>" + result[i].StudentClassID + "</td>"
                        + "<td>" + result[i].StudentSchoolFee + "</td>" +  "<td>" + result[i].StudentSchoolFeeStatus + "</td></tr>"
                    $('#tb_' + result[i].StudentClassID + ' tbody').append(str)
                }
            }
        }
    })
}