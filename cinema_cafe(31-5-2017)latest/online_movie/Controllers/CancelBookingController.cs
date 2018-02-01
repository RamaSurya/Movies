using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using BussinessLayer;
using System.Configuration;
using Common;
using BusinessEntities;

namespace OnlineMovie.Controllers
{
    public class CancelBookingController : Controller
    {
        //
        // GET: /CancelBooking/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Index(int bookid, string userid)
        {
            cancel cancelObj = new cancel();
            cancelObj.bookid = bookid;

            cancelObj.userid = userid;
            Layer layerObj = new Layer();
            string result=layerObj.Cancellation(cancelObj);

            
                ViewBag.error = "your booking have been cancelled";
                return View();
           

        }
    }
}
