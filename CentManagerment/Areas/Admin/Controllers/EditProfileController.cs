using CentManagerment.BU.Common;
using CentManagerment.BU.DataManager;
using CentManagerment.BU.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CentManagerment.Areas.Admin.Controllers
{
    public class EditProfileController : BaseController
    {
        // GET: Admin/EditProfile
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult EditUrProfile(UserManagerDTO user)
        {
            bool resultCode = false;
            if (new UserManagerManager().UserManagerManagerUpdate(user))
            {
                Session.Add(CommonUserLogin.USER_SESSION, user);
                resultCode = true;
            }
            return Json(resultCode, JsonRequestBehavior.AllowGet);
        }
    }
}