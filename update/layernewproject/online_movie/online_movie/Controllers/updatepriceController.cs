using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussiness_layer;

namespace online_movie.Controllers
{
    public class updatepriceController : Controller
    {
        //
        // GET: /updateprice/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string type,string priceval)
        {
            type = Request["type"];
            priceval = Request["price"];
            int price =int.Parse(priceval);
            layercls ob = new layercls();
            int result = ob.updateseatprice(type, price);
            if (result == 1)
            {

                ViewBag.a = "updated the price";
                return View();
                
            }
            else
            {
                ViewBag.a = "unable to update";
                return View();

            }

        }
            
        }

}    


