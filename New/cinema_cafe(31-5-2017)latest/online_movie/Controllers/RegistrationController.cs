using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLayer;

namespace OnlineMovie.Controllers
{
    public class RegistrationController : Controller
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
            Layer ob = new Layer();
            string result = ob.register(name, mobile, userid, password,answer);
            if (result == "Successfully Registered")
            {

                ViewBag.Message_For_Registration = "inserted the record";
                return View();
                
            }
            else
            {


                ViewBag.Message_For_Registration = "unable to insert may user already exist";
                return View();

            }

        }
    }
}
