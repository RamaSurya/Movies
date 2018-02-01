using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineMovie.Controllers
{
    public class CustomerHomeController : Controller
    {
        //
        // GET: /customerhome/

        public ActionResult Index()
        {
            return RedirectToAction("customerhome", "home");
        }

    }
}
