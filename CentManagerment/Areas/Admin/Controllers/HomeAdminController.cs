using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CentManagerment.Areas.Admin.Controllers
{
    public class HomeAdminController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }


        // Upload Image
        [HttpPost]
        public string UploadFileImage(HttpPostedFileBase file)
        {
            var pic = System.Web.HttpContext.Current.Request.Files["file"];
            // Validate
            // Xử lý upload lưu vào sv
            file.SaveAs(Server.MapPath("~/Assets/content/images/" + file.FileName));
            // Trả về link ảnh
            return "/Assets/content/images/" + file.FileName;
        }
    }
}