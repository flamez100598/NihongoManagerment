using CentManagerment.BU.DataManager;
using CentManagerment.BU.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CentManagerment.Controllers
{
    public class HomeController : Controller
    {
        public static readonly NewsManager newManager = new NewsManager();

        public ActionResult Index()
        {
            ViewBag.ListNews = newManager.GetListNews();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult CourseOffline(int id)
        {
            var model = new CourseManager().GetCourseById(id);
            return View(model);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
        public ActionResult AnhHoatDong()
        {
            return View();
        }
        public ActionResult Knowledge()
        {
            return View();
        }
        public ActionResult News()
        {
            ViewBag.ListNews = newManager.GetListNews();
            return View();
        }
        public ActionResult NhacNhat()
        {
            return View();
        }
        public ActionResult KinhNghiem()
        {
            return View();
        }
        public ActionResult DanhSachTruong()
        {
            return View();
        }
        public ActionResult Courses()
        {
            return View();
        }
        // Trang chi tiết
        public ActionResult DetailsNew(int? id)
        {
            ViewBag.ListNews = newManager.GetListNews();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var getTinTuc = newManager.getNewById((int)id);
            if (getTinTuc == null)
            {
                return HttpNotFound();
            }

            return View(getTinTuc);
        }
        public ActionResult KienThuc()
        {
            return View();
        }
        public ActionResult TuyenKySu()
        {
            return View();
        }

        //send mail

        [HttpPost]
        public JsonResult SendEmail(RegisterManagermentDTO rgdto)
        {
            var resultCode = false;
            try
            {
                var fromEmail = "demoproject.3fgroup@gmail.com";
                var toEmail = "3changngoc678@gmail.com.com";
                var senderEmail = new MailAddress(fromEmail, "Jamil");
                var receiverEmail = new MailAddress(toEmail, "Receiver");
                var password = "3fk11997";
                var sub = "Register";
                rgdto.register_course = int.Parse(rgdto.register_coursename.Substring(1));
                var message = " A new register student: <br /> Mail: " + rgdto.register_email + ",  Name: " + rgdto.register_name + ",  Phone: " + rgdto.register_phone + ", Cousre: " + rgdto.register_coursename;
                var body = message;
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password)
                };
                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = sub,
                    Body = message,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(mess);
                }
                //Chưa xác nhận
                rgdto.register_status = (int)BU.Common.Enum.StatusRegister.Unconfirmed;
                resultCode = new RegisterManager().StudentManagerInsert(rgdto);
            }
            catch (Exception)
            {
                resultCode = false;
            }
            return Json(resultCode, JsonRequestBehavior.AllowGet);
        }
    }
}