using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using BussinessLayer;
using System.Configuration;
using common;
namespace OnlineMovie.Controllers
{
    public class AddMovieController : Controller
    {
       Common com= new Common();

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string a, string b, string c, string d, string e)
        {
            try
            {

                
                SqlCommand sda;
                SqlConnection con = new SqlConnection(com.Connection);
                a = Request["showid"];
                b = Request["moviename"];
                c = Request["date"];
                d = Request["starttime"];
                e = Request["endtime"];
                DateTime dt1 = DateTime.Parse(d);
                DateTime dt2 = DateTime.Parse(e);
                if (dt1 >= dt2)
                {
                    ViewBag.Message_For_Adding_Movies = " start time is beyond end time ";
                    return View();
                }
                sda = new SqlCommand("addproc @sid,@mname,@sdate,@stime,@etime", con);
                con.Open();
                SqlParameter ShowId = new SqlParameter("@sid", a);
                SqlParameter MovieName = new SqlParameter("@mname", b);
                SqlParameter MovieDate = new SqlParameter("@sdate", c);
                SqlParameter MovieStartTime = new SqlParameter("@stime", d);
                SqlParameter MovieEndTime = new SqlParameter("@etime", e);
                sda.Parameters.Add(ShowId);
                sda.Parameters.Add(MovieName);
                sda.Parameters.Add(MovieDate);
                sda.Parameters.Add(MovieStartTime);
                sda.Parameters.Add(MovieEndTime);
                sda.ExecuteNonQuery();
                con.Close();
                ViewBag.Message_For_Adding_Movies = " inserted the record";
                return View();
            }
            catch
            {
                ViewBag.Message_For_Adding_Movies = "unable to insert";
                return View();
            }


        }

    }
}
