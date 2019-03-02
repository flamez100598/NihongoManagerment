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
    [Role(RoleID = (int)CommonEnum.Role.Quanlylophoc)]
    public class ClassManagermentController : BaseController
    {
        // khai bao bien manager

        public static readonly ClassManager classManager = new ClassManager();
        public static readonly CourseManager courseManager = new CourseManager();
        public readonly SelectList CourseName = new SelectList(courseManager.GetListCourse(), "CourseId", "CourseName");

        // GET: Admin/ClassManagerment
        /// <summary>
        /// lay list danh sach lop hoc
        /// </summary>
        /// <returns></returns>
        /// #region Dungdz98
        public ActionResult Index(string searchString,int page=1, int pageSize=3)
        {
            var model = classManager.GetListClass(searchString,page,pageSize);
            ViewBag.searchString = searchString;
            //ViewBag.
            return View(model);
        }
        /// <summary>
        /// man hinh them lop hoc
        /// </summary>
        /// <returns></returns>
        /// #region Dungdz98
        public ActionResult InsertView()
        {
            ViewBag.CourseName = CourseName;
            return View();
        }
        /// <summary>
        /// action them lop hoc
        /// </summary>
        /// <param name="classDto"></param>
        /// <returns></returns>
        /// #region Dungdz98
        public ActionResult Insert(ClassDTO classDto)
        {
            var model = classManager.ClassManagerInsert(classDto);

            if(model != 0)
            {
                var GetClass = new ClassManager().GetClassById(model);
                //add list date to revenue month
                var GetDates = GetListDateBetweenTwoDates((DateTime)GetClass.CourseDTO.StartDate, (DateTime)GetClass.CourseDTO.EndDate);
                foreach (var date in GetDates)
                {
                    var RevenueMonthDTO = new RevenueMonthDTO()
                    {
                        Period = 0,
                        Time = date,
                        ClassId = model
                    };
                    new RevenueMonthManage().Insert(RevenueMonthDTO);
                }
            }
            return RedirectToAction("Index");
        }

        public List<DateTime> GetListDateBetweenTwoDates(DateTime DateStart, DateTime DateFinish)
        {
            List<DateTime> allDates = new List<DateTime>();
            for (DateTime date =  DateStart ; date <= DateFinish; date = date.AddMonths(1))
                allDates.Add(date);
            return allDates;
        }
        /// <summary>
        /// man hinh chinh sua
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public ActionResult UpdateView(int id)
        {
            ViewBag.CourseName = CourseName;
            var model = classManager.GetClassById(id);
            return View(model);
        }
        /// <summary>
        /// chinh sua lops hoc
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        /// 
        public ActionResult Update(ClassDTO classDto)
        {
            var updateClass = classManager.ClassManagerUpdate(classDto);
            return RedirectToAction("Index");
        }
        /// <summary>
        /// ajax delete class
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        /// #region dung
        public JsonResult Delete(int classId)
        {
            var deleteManager = classManager.ClassManagerDelete(classId);
            return Json(deleteManager, behavior: JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// get khoa hoc theo id
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public JsonResult CourseSelect(int courseId)
        {
            //var jsonResult = 0;
            var jsonResult = courseManager.GetCourseById(courseId);
            return Json(jsonResult, behavior: JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetStudentByClass(int idClass)
        {
            var jsonResult = new StudentManager().GetListStudentsByClass(idClass);
            return Json(jsonResult, behavior: JsonRequestBehavior.AllowGet);
        }
    }
}