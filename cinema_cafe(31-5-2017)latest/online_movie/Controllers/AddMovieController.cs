using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using BussinessLayer;
using System.Configuration;
using Common;
using BusinessEntities;

namespace OnlineMovie.Controllers
{
    public class AddMovieController : Controller
    {
       Commoncls com= new Commoncls();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AddMovie movieObject)
        {
            //AddMovie movieObject = new AddMovie();
                movieObject.showid=Request["showid"];
                movieObject.moviename = Request["moviename"];
                movieObject.date = Convert.ToDateTime(Request["date"]);
                movieObject.starttime =Convert.ToDateTime(Request["starttime"]);
                movieObject.endtime =Convert.ToDateTime(Request["endtime"]);
                DateTime dt1 = movieObject.starttime;
                DateTime dt2 = movieObject.endtime;
                if (dt1 >= dt2)
                {
                    ViewBag.Message_For_Adding_Movies = " start time is beyond end time ";
                    return View();
                }
                Layer layerObj = new Layer();
                string result=layerObj.AddMovie(movieObject);
                if (result == "Movie Added Successfully")
                {
                    ViewBag.Message_For_Adding_Movies = " Show Added Successfully ";
                    return View();
                }
                else 
                {
                    ViewBag.Message_For_Adding_Movies = result;
                    return View();
                }


        }

}
}



