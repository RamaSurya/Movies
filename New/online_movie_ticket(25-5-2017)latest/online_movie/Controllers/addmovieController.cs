using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Bussiness_layer;
using System.Configuration;
namespace online_movie.Controllers
{
    public class addmovieController : Controller
    {
        //
        // GET: /addmovie/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string a, string b, string c, string d, string e)
        {
            try
            {

                string connstr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlCommand sda;
                SqlConnection con = new SqlConnection(connstr);
                a = Request["showid"];
                b = Request["moviename"];
                c = Request["date"];
                d = Request["starttime"];
                e = Request["endtime"];
                DateTime dt1 = DateTime.Parse(d);
                DateTime dt2 = DateTime.Parse(e);
                if (dt1 > dt2)
                {
                    ViewBag.a = " start time is beyond end time ";
                    return View();
                }
                sda = new SqlCommand("addproc @sid,@mname,@sdate,@stime,@etime", con);
                con.Open();
                SqlParameter p1 = new SqlParameter("@sid", a);
                SqlParameter p2 = new SqlParameter("@mname", b);
                SqlParameter p3 = new SqlParameter("@sdate", c);
                SqlParameter p4 = new SqlParameter("@stime", d);
                SqlParameter p5 = new SqlParameter("@etime", e);
                sda.Parameters.Add(p1);
                sda.Parameters.Add(p2);
                sda.Parameters.Add(p3);
                sda.Parameters.Add(p4);
                sda.Parameters.Add(p5);
                sda.ExecuteNonQuery();
                con.Close();
                ViewBag.a = " inserted the record";
                return View();
            }
            catch
            {
                ViewBag.a = "unable to insert";
                return View();
            }


        }

    }
}
