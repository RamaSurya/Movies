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
    public class MovieUpdateController : Controller
    {
        Commoncls com = new Commoncls();
        public ActionResult Index()
        {
            string str = Session["s"].ToString();
            ViewBag.Message_For_Admin_Session = str;
            SqlCommand sda;
            SqlConnection con = new SqlConnection(com.connection);
            sda = new SqlCommand("show @sid", con);
            con.Open();
            SqlParameter showid = new SqlParameter("@sid",str);
            sda.Parameters.Add(showid);
            SqlDataReader sdr = sda.ExecuteReader();
            
            while (sdr.Read())
            {
                
                ViewBag.a = sdr[0];
                ViewBag.b = sdr[1];
                ViewBag.c = sdr[2];
                ViewBag.d = sdr[3];
                ViewBag.e = sdr[4];
            }
            con.Close();

            
            return View();
        }

        [HttpPost]
        public ActionResult Index(string a, string b, string c, string d, string e)
        {
            try
            {

               
                SqlCommand sda;
                SqlConnection con = new SqlConnection(com.connection);
                a = Request["showid"];
                b = Request["moviename"];
                c = Request["date"];
               
                d = Request["starttime"];
                e = Request["endtime"];
                DateTime dt1 = DateTime.Parse(d);
                DateTime dt2 = DateTime.Parse(e);
                DateTime dt3 = DateTime.Parse(c);
                if (dt1 > dt2)
                {
                    ViewBag.Message_For_Updating_Movies = " start time is beyond end time ";
                    return View();
                }
                if (dt3 < (DateTime.Now))
                {
                    ViewBag.Message_For_Updating_Movies = " date is less than current date ";
                    return View();
                }
                sda = new SqlCommand("updateproc @sid,@mname,@sdate,@stime,@etime", con);
                con.Open();
                SqlParameter Showid = new SqlParameter("@sid", a);
                SqlParameter MovieName = new SqlParameter("@mname", b);
                SqlParameter ShowDate = new SqlParameter("@sdate", c);
                SqlParameter ShowStartTime = new SqlParameter("@stime", d);
                SqlParameter ShowEndTime = new SqlParameter("@etime", e);
                sda.Parameters.Add(Showid);
                sda.Parameters.Add(MovieName);
                sda.Parameters.Add(ShowDate);
                sda.Parameters.Add(ShowStartTime);
                sda.Parameters.Add(ShowEndTime);
                sda.ExecuteNonQuery();
                con.Close();
                ViewBag.Message_For_Updating_Movies= " updated successfully";
                Session.Remove("s");
                return View();
            }
            catch
            {
                ViewBag.Message_For_Updating_Movies = "unable to update";
                Session.Remove("s");
                
                return View();
            }

        }
    }
}
