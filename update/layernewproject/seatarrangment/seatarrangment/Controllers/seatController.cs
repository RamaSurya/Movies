using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace seatarrangment.Controllers
{
    public class seatController : Controller
    {
        //
        // GET: /seat/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string checkbox1)
        {
            string str;
            checkbox1 = Request.Form["seat1"];
            if (checkbox1=="on")
            {
                str = "aleena";
            }
            var checkbox2= Request.Form["seat2"];
            if (checkbox2 == "on")
            {
                str = "aleena";
            }
            var checkbox3 = Request.Form["seat3"];
            if (checkbox3 == "on")
            {
                str = "aleena";
            }
            var checkbox4 = Request.Form["seat4"];
            if (checkbox4 == "on")
            {
                str = "aleena";
            }
           /*var names = f.AllKeys.Where(c => c.StartsWith("seat") &&
                        f.GetValue(c) != null &&
                        f.GetValue(c).AttemptedValue == "1");
            if (seat2)
            {
                i++;
            }
            if (seat3)
            {
                i++;
            }
            if (seat4)
            {
                i++;
            }*/
            ViewBag.a = str;
            return View();

        }
           // foreach (Control ctl in reservation.FindControl("myDiv").Controls)
           // {
            //    if (ctl is CheckBox)
             //   {
             //       if (((CheckBox)ctl).Checked)
             //           i++;
              //  }
           // }//
           
        }

    }

