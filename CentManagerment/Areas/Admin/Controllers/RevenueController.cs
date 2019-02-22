using CentManagerment.BU.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CentManagerment.Areas.Admin.Controllers
{
    public class RevenueController : Controller
    {
        public ActionResult RevenueClass(int page = 1)
        {
            var mngRevenue = new RevenueManager();
            var listRevenue = mngRevenue.ListRevenue();
            // Xử lý PageList
            int sizePage = 10;
            int numRevenueAll = listRevenue.Count();
            int numPage = 0;
            if (numRevenueAll % sizePage != 0)
            {
                numPage = (int)numRevenueAll / sizePage + 1;
            }
            else
            {
                numPage = numRevenueAll / sizePage;
            }
            if (page < 1) { page = 1; } else if (page > numPage) { page = numPage; } // Xủ lí prev and next page
            ViewBag.NumRevenueAll = numRevenueAll;
            ViewBag.NumPage = numPage;
            ViewBag.Page = page;
            // Chia dữ liệu
            listRevenue = listRevenue.Skip((page - 1) * sizePage).Take(sizePage).ToList();
            return View(listRevenue);
        }
    }
}