using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace online_movie.Controllers
{
    public class seathomeController : Controller
    {
        //
        // GET: /seathome/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string countseat, string amount)
        {

            countseat = Request["tbb1"];
            string seats = Request["tbb"];
            // string[] arr = seats.Split(',');

            amount = Request["amm"];

            TempData["seat"] = countseat;
            TempData["amt"] = amount;
            return RedirectToAction("Index", "Amount", new { strArray = seats });

        }
        

    }
}
