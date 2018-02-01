using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLayer;
using BusinessEntities;

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
            CustomerRegistration custObj = new CustomerRegistration();
            custObj.name = Request["name"];
            custObj.mobile = Request["mobilenumber"];
            custObj.userid = Request["userid"];
            custObj.password = Request["password"];
            custObj.answer = Request["answer"];
            Layer ob = new Layer();
            string result = ob.Register(custObj);
            if (result == "Successfully Registered")
            {

                ViewBag.Message_For_Registration = "Successfully Registered";
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
