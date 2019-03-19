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
        public ActionResult CourseOffline()
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        // Trang chi tiết
        public ActionResult DetailsNew(int? id)
        {
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


        //send mail

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendEmail(string name, string phone, string email, int course)
        {
            try
            {
                var fromEmail = "demoproject.3fgroup@gmail.com";
                var toEmail = "mrvvip10@gmail.com";
                var senderEmail = new MailAddress(fromEmail, "Jamil");
                var receiverEmail = new MailAddress(toEmail, "Receiver");
                var password = "3fk11997";
                var sub = "Register";
                var message = " A new register student: <br /> Mail: " + email + ",  Name: " + name + ",  Phone: " + phone + ", Cousre: N" + course;
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
                var registerDTO = new RegisterManagermentDTO()
                {
                    register_email = email,
                    register_course = course,
                    register_name = name,
                    register_phone = phone,
                    register_status = 0 //Chưa xác nhận thông tin
                };
                var insert = new RegisterManager().StudentManagerInsert(registerDTO);
                ViewBag.ShowInfo = "Gửi thành công! Hãy tham khảo các khóa học và đăng ký tiếp nhé ^.^";
            }
            catch (Exception)
            {
                ViewBag.ShowInfo = "Đã xảy ra lỗi! Bạn quay lại đăng ký sau nhé! Hãy thao khảo các khóa học tiếp đi nhé ^.^";
            }
            return RedirectToAction("Index");
        }
    }
}