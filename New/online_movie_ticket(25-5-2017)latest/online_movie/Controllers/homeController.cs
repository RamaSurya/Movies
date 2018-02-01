using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business_entities;
using Bussiness_layer;

namespace online_movie.Controllers
{
    public class homeController : Controller
    {
        //
        // GET: /home/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string userid,string password)
        {
            userid = Request["userid"];
            password = Request["password"];
            layercls ob = new layercls();
            int result = ob.validate(userid, password);
            if (result == 1)
            {
                string strid = Request["userid"];
                TempData["suserid"] = strid;
                return View("customerhome");

            }
            else if (result == 2)
            {
                return View("adminhome");

            }
            else if(result == 4)
            {

                ViewBag.a = "connection failed....test connection";
                return View();
            }
            else
            {

                
                ViewBag.a = "Invalid userid or password";
                return View();
            }
        }

        public ActionResult customerhome(string userid, string password)
        {
            userid = Request["userid"];
            password = Request["password"];
            layercls ob = new layercls();
            int result = ob.validate(userid, password);
            if (result == 1)
            {
                return View("customerhome");

            }
            else if (result == 2)
            {
                return View("adminhome");

            }
            else if (result == 4)
            {

                ViewBag.a = "connection failed....test connection";
                return View();
            }
            else
            {


                ViewBag.a = "invalid userid or password";
                return View();
            }
        }
        public ActionResult adminhome()
        {
            return View();
        }

    }
}
