using CentManagerment.Areas.Admin.Common;
using CentManagerment.BU.DataManager;
using CentManagerment.BU.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CentManagerment.Areas.Admin.Controllers
{
    [Role(RoleID = (int)CommonEnum.Role.Quanlysinhvien)]
    public class StudentManagermentController : BaseController
    {

        readonly StudentManager studentMange = new StudentManager();
        // GET: Admin/StudentManagerment
        public ActionResult Index(string searchString, int page = 1, int pageSize = 3)
        {
            ViewBag.searchString = searchString;
            var listStudents = studentMange.GetListStudents(searchString, page, pageSize);
            return View(listStudents);
        }

        /// <summary>
        /// created by : Dat 26-11
        /// </summary>
        /// <returns></returns>
        public ActionResult AddStudent()
        {
            ViewBag.ClassName = new SelectList(new ClassManager().GetListSelectClass(), "ClassId", "ClassName");
            return View();
        }

        public JsonResult UpdateStudent(StudentDTO stdto)
        {
            var resultCode = 0;
            var getStudent = studentMange.GetInfoStudent(stdto.StudentId);
            if ((getStudent.StudentSchoolFeeDate == null && stdto.StudentSchoolFee > 0))
                stdto.StudentSchoolFeeDate = DateTime.Now;
            var resultUpdate = studentMange.StudentManagerUpdate(stdto);
            if (resultUpdate)
                resultCode = 1;
            return Json(resultCode, JsonRequestBehavior.AllowGet);
        }


        public JsonResult DeleteStudent(int idStudent)
        {
            var resultCode = 0;
            var resultDelete = studentMange.StudentManagerDeleteById(idStudent);
            if (resultDelete)
                resultCode = 1;
            return Json(resultCode, JsonRequestBehavior.AllowGet);
        }


        public JsonResult AddNewStudent(StudentDTO stdto)
        {

            var resultCode = 0;
            stdto.StudentSchoolFeeStatus = false;
            if (string.IsNullOrEmpty(stdto.StudentName) || string.IsNullOrEmpty(stdto.StudentEmail) || string.IsNullOrEmpty(stdto.StudentPhone))
            {
                //Hãy nhập đủ thông tin yêu cầu
                resultCode = 2;
            }
            else
            {
                if (stdto.StudentSchoolFee > 0)
                {
                    stdto.StudentSchoolFeeDate = DateTime.Now;
                }
                var resultUpdate = studentMange.StudentManagerInsert(stdto);
                if (resultUpdate)
                    resultCode = 1;
            }

            return Json(resultCode, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DetailStudent(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var st = studentMange.GetInfoStudent((int)id);
            if (st == null)
            {
                return HttpNotFound();
            }
            return View(st);
        }
        /// <summary>
        /// get list select class
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public JsonResult ClassSelect(int classId)
        {
            //var jsonResult = 0;
            var jsonResult = new ClassManager().GetClassById(classId);
            return Json(jsonResult, behavior: JsonRequestBehavior.AllowGet);
        }
    }
}