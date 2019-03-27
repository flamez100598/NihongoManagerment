using CentManagerment.Areas.Admin.Common;
using CentManagerment.BU.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CentManagerment.Areas.Admin.Controllers
{
    [Role(RoleID = (int)CommonEnum.Role.Quanlydangky)]
    public class RegisterManagermentController : BaseController
    {
        RegisterManager _registerManager = new RegisterManager();
        // GET: Admin/RegisterManagerment
        public ActionResult Index(string searchString, int page = 1, int pageSize = 3)
        {
            ViewBag.searchString = searchString;
            var listRegisters = _registerManager.GetListRegistersAndPaging(searchString, page, pageSize);
            return View(listRegisters);
        }

        public JsonResult UpdateStatus(int id, int status)
        {
            return Json(_registerManager.StudentManagerUpdate(id, status), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteRegister(int id)
        {
            return Json(_registerManager.StudentManagerDelete(id), JsonRequestBehavior.AllowGet);
        }
    }
}