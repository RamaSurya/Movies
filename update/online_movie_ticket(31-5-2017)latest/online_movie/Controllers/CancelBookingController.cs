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
    public class CancelBookingController : Controller
    {
        //
        // GET: /CancelBooking/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Index(int bookid,string showid,string userid)
        {

            try
            {

                Common com = new Common();
                SqlCommand sda1;
                SqlConnection con = new SqlConnection(com.Connection);
                sda1 = new SqlCommand("cancelproc @sid,@bkid,@user", con);//to change the status
                con.Open();
                SqlParameter ShowId = new SqlParameter("@sid", showid);
                SqlParameter bkid = new SqlParameter("@bkid", bookid);//procedure to change seat status
                SqlParameter user = new SqlParameter("@user", userid);
                sda1.Parameters.Add(ShowId);
                sda1.Parameters.Add(bkid);
                sda1.Parameters.Add(user);
                sda1.ExecuteNonQuery();
                con.Close();
                return View();
            }
            catch
            {
                ViewBag.error = "unable to cancell may you have entered the wrong booking id.you can enter only the show that you are booked";
                return View();

            }
        }
    }
}
