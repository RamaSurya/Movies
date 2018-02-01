using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using BussinessLayer;
using common;
using System.Configuration;

namespace OnlineMovie.Controllers
{
    public class AmountController : Controller
    {
        Common com = new Common();
        int arrlen1,arrlen2;
        public ActionResult Index(string strArray)
        {
            string str1 = Session["suserid"].ToString();//to take userid
            ViewBag.user = str1;

            string str2 = Session["s"].ToString();//to take show id
            ViewBag.show = str2;
            string[] arr = strArray.Split(',');
            arrlen1 = strArray.Length;
            ViewBag.len = arrlen1;
            arrlen2 = arr.Length;//length of splited array
            ViewBag.seats = arr;
            ViewBag.amt = TempData["amt"];
            ViewBag.seat = TempData["seat"];

            return View();
        }
        [HttpPost]

        public ActionResult Index()
        {
           
            SqlCommand sda1,sda2;
            SqlConnection con = new SqlConnection(com.Connection);  
            int len=int.Parse(Request["tbb2"]);
            Session["count"] = len;
            string showid = Session["s"].ToString();
            string user= Session["suserid"].ToString();
            
          
          string[] arr = new string[len];//find the number of seats booked
          for (int i = 1; i <= len; i++)
          {
              string seatno = null;
              // arr[i] = Request["t" + i];

              seatno = "s" + Request["t" + i]; //to generate the seat number as s1,s2..seatnumber column cant be a number
              sda1 = new SqlCommand("bookproc @sid,@sno", con);//to change the status
              con.Open();
              SqlParameter ShowId = new SqlParameter("@sid", showid);
              SqlParameter SeatNo = new SqlParameter("@sno", seatno);//procedure to change seat status

              sda1.Parameters.Add(ShowId);
              sda1.Parameters.Add(SeatNo);
              sda1.ExecuteNonQuery();
              con.Close();

          }
            
          sda2 = new SqlCommand("bookingtbl @user,@sid,@sno", con);
          con.Open();
          SqlParameter users = new SqlParameter("@user", user);
          SqlParameter sid = new SqlParameter("@sid", showid);
          SqlParameter sno = new SqlParameter("@sno", len);//procedure to change seat status

          sda2.Parameters.Add(users);
          sda2.Parameters.Add(sid);
          sda2.Parameters.Add(sno);
          int bookid=(int)sda2.ExecuteScalar();
          Session["bookid"] = bookid;
          con.Close();
            return RedirectToAction("Index", "ticket");
        }

    }
}
