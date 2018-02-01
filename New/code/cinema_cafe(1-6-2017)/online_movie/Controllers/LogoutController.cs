using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineMovie.Controllers
{
    public class LogoutController : Controller
    {
        //
        // GET: /logout/

        public ActionResult Index()
        {
            
            return RedirectToAction("logouthome","home");
        }

    }
}
