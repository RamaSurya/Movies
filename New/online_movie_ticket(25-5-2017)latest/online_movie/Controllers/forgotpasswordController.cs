using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussiness_layer;

namespace online_movie.Controllers
{
    public class forgotpasswordController : Controller
    {
        //
        // GET: /forgotpassword/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string userid, string answer)
        {
            userid = Request["userid"];
            answer = Request["answer"];
            layercls ob = new layercls();
            int result = ob.forget(userid, answer);
            if (result == 1)
            {
                
                return RedirectToAction("customerhome", "home");

            }
            else if (result == 4)
            {
                ViewBag.a = "unable to connect";
                return View();
            }

            else
            {

                ViewBag.a = "invalid userid or answer";
                return View();
            }
        }

    }
}
