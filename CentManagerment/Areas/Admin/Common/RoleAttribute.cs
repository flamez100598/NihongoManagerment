using CentManagerment.BU.Common;
using CentManagerment.BU.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CentManagerment.Areas.Admin.Common
{
    public class RoleAttribute : AuthorizeAttribute
    {
        public int RoleID { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var session = (UserManagerDTO)HttpContext.Current.Session[CommonUserLogin.USER_SESSION];
            if (session == null)
            {
                return true ;
            }
            List<int> listRole = this.GetRoleBySessionLogin(session.UserName);
            if (listRole.Contains(this.RoleID))
            {
                return true;
            }
            else
                return false;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { Controller = "FourZeroOne", action = "Index", Area = "Admin" }));
        }
        private List<int> GetRoleBySessionLogin(string userName)
        {
            var listRole = (List<int>)HttpContext.Current.Session[CommonUserLogin.USER_LISTROLE];
            return listRole;
        }
    }
}
