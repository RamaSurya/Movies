using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLayer;
using BusinessEntities;

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
            
            Session["suserid"] = userid;
            ForgetPassword answerObject = new ForgetPassword();
            answerObject.userid = userid;
            answerObject.answer = answer;
            Layer ob = new Layer();
            string result = ob.Forget(answerObject);
            if (result == "Successfully Loged in")
            {
                
                return RedirectToAction("customerhome", "home");

            }
            else if (result == "Unable to Login")
            {
                ViewBag.Message_For_Forgot_Password = "invalid answer";
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
