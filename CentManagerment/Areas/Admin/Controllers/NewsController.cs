using CentManagerment.Areas.Admin.Common;
using CentManagerment.BU.Common;
using CentManagerment.BU.DataManager;
using CentManagerment.BU.DTO;
using System;
using System.Web.Mvc;

namespace CentManagerment.Areas.Admin.Controllers
{
    [Role(RoleID = (int)CommonEnum.Role.Quanlytintuc)]
    public class NewsController : BaseController
    {
        public static readonly NewsManager newManager = new NewsManager();

        // GET: Admin/News
        public ActionResult Index(string searchString, int page = 1, int pageSize = 3)
        {
            var model = newManager.GetListNews(searchString, page, pageSize);
            ViewBag.searchString = searchString;
            return View(model);
        }
        public ActionResult AddMews()
        {
            return View();
        }
        public JsonResult DeleteNew(int idnew)
        {
            var resultCode = 0;
            var resultDelete = newManager.NewsManagerDelete(idnew);
            if (resultDelete)
                resultCode = 1;
            return Json(resultCode, JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        public JsonResult AddNews(NewsDTO newdto, int? type)
        {
            var resultCode = 0;
            var resultUpdate = true;
            var session = (UserManagerDTO)Session[CommonUserLogin.USER_SESSION];
            if (string.IsNullOrEmpty(newdto.NewsContent) || string.IsNullOrEmpty(newdto.NewsShortContent) || string.IsNullOrEmpty(newdto.NewsTitle))
            {
                //Hãy nhập đủ thông tin yêu cầu
                resultCode = 2;
            }
            else
            {
                if(type == null)
                {
                    newdto.NewsPostDate = DateTime.Now;
                    newdto.NewsUserID = session.UserId;
                    resultUpdate = newManager.NewsManagerInsert(newdto);
                }
                else
                {
                    newdto.NewsId = (int)type;
                    var getNew = newManager.getNewById((int)type);
                    newdto.NewsPostDate = getNew.NewsPostDate;
                    newdto.NewsUserID = getNew.NewsUserID;
                    resultUpdate = newManager.NewsManagerUpdate(newdto);

                }
                if (resultUpdate)
                    resultCode = 1;
            }

            return Json(resultCode, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateNew(int idNews)
        {
            var getTT =newManager.getNewById(idNews);
            return View(getTT);
        }
    }
}