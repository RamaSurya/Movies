using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace online_movie.Controllers
{
    public class customerhomeController : Controller
    {
        //
        // GET: /customerhome/

        public ActionResult Index()
        {
            return RedirectToAction("customerhome", "home");
        }

    }
}
