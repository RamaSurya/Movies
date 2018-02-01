using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLayer;

namespace OnlineMovie.Controllers
{
    public class ForgotPasswordController : Controller
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
            Session["suserid"] = userid;
            Layer ob = new Layer();
            string result = ob.forget(userid, answer);
            if (result == "Successfully Loged in")
            {
                
                return RedirectToAction("customerhome", "home");

            }
            else if (result == "Unable to Login")
            {
                ViewBag.Message_For_Forgot_Password = "unable to connect";
                return View();
            }

            else
            {

                ViewBag.Message_For_Forgot_Password = "invalid userid or answer";
                return View();
            }
        }

    }
}
