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
            if(teacherDTO.Age > 0 && teacherDTO.PricePerHour >= 0 && teacherDTO.TimeToWork >= 0)
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
            if(teacherDTO.Age > 0 && teacherDTO.PricePerHour >= 0 && teacherDTO.TimeToWork >= 0)
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
        public JsonResult AddTimeWork(TimeWorkDTO dto)
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// QUản lý thời gian giảng dạy của giáo viên
        /// </summary>
        /// <returns></returns>
        public ActionResult TimeWork()
        {
            SelectList listTeacher = new SelectList(new TeacherManager().GetListTeacher(), "TeacherId", "TeacherName");
            ViewBag.listTeacher = listTeacher;

            return View();
        }

        [HttpPost]
        public JsonResult SelectTeacher(int teacherId)
        {
            var jsonResult = new TimeWorkManager().GetAllByIdTeacher(teacherId);
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetTimeWork(int id)
        {
            var json = new TimeWorkManager().GetTimeWork(id);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(double time, DateTime date, int id)
        {
            var check = new TimeWorkManager().Edit(time, date, id);
            var result = new List<TimeWorkDTO>();
            if (check)
            {
                var info = new TimeWorkManager().GetTimeWork(id);
                result = new TimeWorkManager().GetAllByIdTeacher((int)info.TeacherId);   
            }
            if (result.Count < 1)
            {
                result = null;
            }
            return Json(new { check, result }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(double time, DateTime date, int id)
        {
            var check = new TimeWorkManager().Create(time, date, id);
            var result = new List<TimeWorkDTO>();
            if (check)
            {
                result = new TimeWorkManager().GetAllByIdTeacher(id);
            }
            if (result.Count < 1)
            {
                result = null;
            }
            return Json(new { check, result }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var idTeacher = new TimeWorkManager().GetTimeWork(id).TeacherId;
            var check = new TimeWorkManager().Delete(id);
            var result = new List<TimeWorkDTO>();
            if (check)
            {
                result = new TimeWorkManager().GetAllByIdTeacher((int)idTeacher);
            }
            if (result.Count < 1)
            {
                result = null;
            }
            return Json(new { check, result }, JsonRequestBehavior.AllowGet);
        }
    }
}