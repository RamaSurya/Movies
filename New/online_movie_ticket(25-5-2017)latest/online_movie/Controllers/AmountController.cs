using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace online_movie.Controllers
{
    public class AmountController : Controller
    {
        //
        // GET: /Amount/

        public ActionResult Index(string strArray)
        {
            string[] arr = strArray.Split(',');
            int arrlen = strArray.Length;
            ViewBag.len = arrlen;
            ViewBag.seats = arr;
            ViewBag.amt = TempData["amt"];
            ViewBag.seat = TempData["seat"];

            return View();
        }
        [HttpPost]

        public ActionResult Index()
        {
            return View();
        }

    }
}
