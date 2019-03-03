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
    [Role(RoleID = (int)CommonEnum.Role.Quanlykhoahoc)]

    public class CourseManagermentController : BaseController
    {

        public readonly CourseManager courseManager = new CourseManager();
        // GET: Admin/CourseManagerment
        /// <summary>
        /// Get all list course
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(string searchString,int page = 1,int pageSize = 3)
        {
            var model = courseManager.GetListCourseSearchAndPaging(searchString,page,pageSize);
            ViewBag.searchString = searchString;
            return View(model);
        }
        /// <summary>
        /// man hinh them khoa hoc
        /// </summary>
        /// <returns></returns>
        public ActionResult InsertView()
        {
            return View();
        }
        /// <summary>
        /// them khoa hoc
        /// </summary>
        /// <param name="classDto"></param>
        /// <returns></returns>
        public ActionResult Insert(CourseDTO courseDto)
        {       
            var model = courseManager.CourseManagerInsert(courseDto);

            return RedirectToAction("Index");
        }
        /// <summary>
        /// xoa khoa hoc
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public JsonResult Delete(int courseId)
        {
            var deleteManager = courseManager.CourseManagerDelete(courseId);
            return Json(deleteManager, behavior: JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// man hinh chinh sua khoa hoc
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult UpdateView(int id)
        {
            var model = courseManager.GetCourseById(id);
            return View(model);
        }
        /// <summary>
        /// action chỉnh sửa khóa học
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ActionResult Update(CourseDTO dto)
        {
            var updateClass = courseManager.CourseManagerUpdate(dto);
            return RedirectToAction("Index");
        }
    }
}