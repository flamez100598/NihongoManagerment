using CentManagerment.Areas.Admin.Common;
using CentManagerment.BU.DataManager;
using CentManagerment.BU.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CentManagerment.Areas.Admin.Controllers
{
    [Role(RoleID = (int)CommonEnum.Role.Quanlygiaovien)]
    public class TeacherManagermentController : BaseController
    {
        // GET: Admin/TeacherManagerment
        public ActionResult Index(int page = 1)
        {
            var mngTeacher = new TeacherManager();
            var listTeacher = mngTeacher.GetListTeacher();
            // Xử lý PageList
            int sizePage = 10;
            int numTeacherAll = listTeacher.Count();
            int numPage = 0;
            if (numTeacherAll % sizePage != 0)
            {
                numPage = (int)numTeacherAll / sizePage + 1;
            }
            else
            {
                numPage = numTeacherAll / sizePage;
            }
            if (page < 1) { page = 1; } else if (page > numPage) { page = numPage; } // Xủ lí prev and next page
            ViewBag.NumTeacherAll = numTeacherAll;
            ViewBag.NumPage = numPage;
            ViewBag.Page = page;
            // Chia dữ liệu
            listTeacher = listTeacher.Skip((page - 1) * sizePage).Take(sizePage).ToList();
            return View(listTeacher);
        }

        /// <summary>
        /// Sử dụng dữ liệu bên phía local để sửa thông tin
        /// </summary>
        /// <param name="teacherDTO">Đối tượng là giáo viên</param>
        /// <returns>Đúng hoặc sai</returns>
        [HttpPost]
        public JsonResult EditTeacher(TeacherDTO teacherDTO)
        {
            var checkEdit = false;
            if (teacherDTO.Age > 0 && teacherDTO.PricePerHour >= 0 && teacherDTO.TimeToWork >= 0)
            {
                checkEdit = new TeacherManager().TeacherManagerUpdate(teacherDTO);
            }
            return Json(checkEdit, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/TeacherManagerment/AddTeacher
        public ActionResult AddTeacher()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTeacher(TeacherDTO teacherDTO)
        {
            var checkAdd = false;
            if (teacherDTO.Age > 0 && teacherDTO.PricePerHour >= 0 && teacherDTO.TimeToWork >= 0)
            {
                checkAdd = new TeacherManager().TeacherManagerInsert(teacherDTO);
            }
            if (checkAdd)
            {
                return Redirect("/Admin/TeacherManagerment/Index");
            }
            else
            {
                return View();
            }
        }
        //insert time work
        public JsonResult AddTimeWork(TimekeepingDTO dto)
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TimeWork()
        {
            SelectList listTeacher = new SelectList(new TeacherManager().GetListTeacher(), "TeacherId", "TeacherName");
            ViewBag.listTeacher = listTeacher;
            return View();
        }
        public JsonResult SelectTeacher(int? teacherId)
        {
            if (teacherId == null)
                return Json(null, JsonRequestBehavior.AllowGet);
            var jsonResult = new TeacherManager().GetListTimekeepingByIdTeacher((int)teacherId);
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }


        public JsonResult CreateTimekeeping(TimekeepingDTO timekeepingDTO)
        {
            var resultCode = 0;
            var resultMessage = "";
            var status = "error";
            var result = false;
            var jsonresult = new List<TimekeepingDTO>();
            
            //split time in : yyyy-MM-ddTHH:mm
            string[] timeIn = timekeepingDTO.TimeInStr.Split('T');
            timekeepingDTO.TimeIn = DateTime.ParseExact(timeIn[0], "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture) + TimeSpan.Parse(timeIn[1]);

            var timeInDate = timekeepingDTO.TimeIn.Value.Date;
            //split time out : yyyy-MM-ddTHH:mm
            string[] timeOut = timekeepingDTO.TimeOutStr.Split('T');
            timekeepingDTO.TimeOut = DateTime.ParseExact(timeOut[0], "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) + TimeSpan.Parse(timeOut[1]);

            var timeOutDate = timekeepingDTO.TimeOut.Value.Date;

            if (timekeepingDTO.TimeIn > timekeepingDTO.TimeOut)
            {
                resultMessage = "Thời gian bắt đầu phải nhỏ hơn thời gian kết thúc";
            }else if(timeInDate != timeOutDate)
            {
                resultMessage = "Chỉ cho phép thời gian giáo viên làm việc trong 1 ngày";
            }
            else
            {
                result = new TimekeepingManager().Insert(timekeepingDTO);
                if (result)
                {
                    resultMessage = "Thêm thành công";
                    resultCode = 1;
                    status = "success";
                    jsonresult = new TeacherManager().GetListTimekeepingByIdTeacher((int)timekeepingDTO.TeacherID);
                }
                else
                {
                    resultMessage = "Thêm không thành công";
                }
            }
            //}else if(timekeepingDTO.TimeIn.Value.day)
            return Json(new { message = resultMessage, code = resultCode, json = jsonresult, status = status }, JsonRequestBehavior.AllowGet);
        }
    }
}