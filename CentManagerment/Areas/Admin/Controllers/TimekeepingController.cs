using CentManagerment.Areas.Admin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CentManagerment.Areas.Admin.Controllers
{
    [Role(RoleID = (int)CommonEnum.Role.Quanlychamconggiaovien)]
    public class TimekeepingController : BaseController
    {
        // GET: Admin/Timekeeping
        public ActionResult Index()
        {
            return View();
        }
    }
}