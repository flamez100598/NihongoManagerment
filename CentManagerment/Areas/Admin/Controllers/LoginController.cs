using CentManagerment.BU.Common;
using CentManagerment.BU.DataManager;
using CentManagerment.BU.DTO;
using System.Web.Mvc;

namespace CentManagerment.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModelDTO user)
        {
            if (ModelState.IsValid)
            {
                var userLogin = new UserManagerManager().LoginUserByLoginModel(user);
                if (userLogin != null)
                {
                    //Session[CommonUserLogin.USER_SESSION] = userSesstion;
                    Session.Add(CommonUserLogin.USER_SESSION, userLogin);
                    var listRole = new RoleManagerManager().GetListRoleIdByUserName(user.UserName);
                    Session.Add(CommonUserLogin.USER_LISTROLE, listRole);                    
                    return RedirectToAction("Index", "Admin/HomeAdmin");
                }
                else
                {
                    return Redirect("/Admin/Login");
                }
            }
            else
            {
                return Redirect("/Admin/Login");
            }
        }
        public ActionResult SignOut()
        {
            Session.Remove(CommonUserLogin.USER_SESSION);
            return Redirect("/Admin/Login");
        }
    }
}