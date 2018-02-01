using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntities;
using BussinessLayer;

namespace OnlineMovie.Controllers
{
    public class HomeController : Controller
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
            
            Login loginObject = new Login();
            loginObject.userid = userid;
            loginObject.password = password;
            Layer ob = new Layer();
            string result = ob.Validate(loginObject);
            if (result == "loged in as customer")
            {
                string strid = Request["userid"];
                Session["suserid"] = strid;
                return View("customerhome");//customer login

            }
            else if (result == "loged in as admin")
            {
                Session["suserid"] = userid;
                return View("adminhome");//admin login

            }
            else 
            {

                ViewBag.Meassge_For_ConnectionFailure = "Invalid User Id or password";//invalid username or password
                return View();
            }
        }

        public ActionResult customerhome(string userid, string password)
        {
            userid = Request["userid"];
            password = Request["password"];
            Login loginObject = new Login();
            loginObject.userid = userid;
            loginObject.password = password;
            Layer ob = new Layer();
            string result = ob.Validate(loginObject);
            if (result == "loged in as customer")
            {
                return View("customerhome");//login as customer

            }
            else if (result == "loged in as admin")
            {
                return View("adminhome");//login as admin

            }
            else if (result == "login failed")
            {

                ViewBag.Message_For_ConnectionFailure = "connection failed....test connection";
                return View();
            }
            else
            {


                ViewBag.Message_For_ConnectionFailure = "invalid userid or password";
                return View();
            }
        }
        public ActionResult adminhome()
        {
            
            return View();//return view adminhome
        }
        public ActionResult logouthome()
        {
            Session.Abandon();//clear the session while logged out
            return RedirectToAction("Index");
        }

    }
}
