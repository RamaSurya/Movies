using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussiness_layer;

namespace online_movie.Controllers
{
    public class registerationController : Controller
    {
        //
        // GET: /registeration/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string name, string mobile, string userid, string password, string question, string answer)
        {
            name = Request["name"];
            mobile = Request["mobilenumber"];
            userid = Request["userid"];
            password = Request["password"];
            answer = Request["answer"];
            layercls ob = new layercls();
            int result = ob.register(name, mobile, userid, password,answer);
            if (result == 1)
            {

                ViewBag.a = "inserted the record";
                return View();
                
            }
            else
            {


                ViewBag.a = "unable to insert";
                return View();

            }

        }
    }
}
