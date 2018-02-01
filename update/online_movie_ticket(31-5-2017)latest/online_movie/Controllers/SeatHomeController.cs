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
    public class SeatHomeController : Controller
    {
        Common com = new Common();  
        public ActionResult Index()
        {
            int[] arr = new int[25];
            string showid = Session["s"].ToString();//to get the showid
           
            SqlCommand sda;

            SqlConnection con = new SqlConnection(com.Connection);

            string seatarray=null;
            for (int i = 1; i <= 25; i++)
            {
                string seatno = null;
                // arr[i] = Request["t" + i];

                seatno = "s" +  i; //to generate the seat number as s1,s2..seatnumber column cant be a number

                sda = new SqlCommand("colorproc1 @sno,@sid", con);
                con.Open();
                SqlParameter ShowId = new SqlParameter("@sid", showid);
                SqlParameter SeatNo = new SqlParameter("@sno", seatno);//procedure to change seat status
                sda.Parameters.Add(SeatNo);
                sda.Parameters.Add(ShowId);
                
                int res = (int)sda.ExecuteScalar();
                if (res == 1)
                {
                    seatarray = seatarray + i.ToString() ;//to generate the series of seat [12,3,4,...
                    seatarray = seatarray + ",";
                }
                con.Close();
            }
            if (seatarray != null)
            {
                string output = seatarray.Remove(seatarray.Length - 1, 1);//to remove the , at the last
                int[] arr1 = output.Split(',').Select(str => int.Parse(str)).ToArray();

                ViewBag.arraylength = arr1.Length;
                ViewBag.seats = arr1;
                Session["seats"] = arr1;
                
            }
            else
            {
                ViewBag.arraylength = null;
                ViewBag.seats = null;
                Session["seats"] = null;
            }
            //to take the seat array
            return View();
        }

        [HttpPost]
        public ActionResult Index(string countseat, string amount)
        {

            countseat = Request["tbb1"];//to get the number of seats
            string seats = Request["tbb"];//to get the seats
            // string[] arr = seats.Split(',');

            amount = Request["amm"];

            TempData["seat"] = countseat;
            TempData["amt"] = amount;
            return RedirectToAction("Index", "Amount", new { strArray = seats });

        }
        

    }
}
