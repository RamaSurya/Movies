using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using common;
using BusinessEntities;

namespace OnlineMovie.Controllers
{
    public class TicketController : Controller
    {
        Common com = new Common();

        public ActionResult Index()
        {
            string str1 = Session["suserid"].ToString();
           
            SqlCommand sda;
            SqlConnection con = new SqlConnection(com.Connection);
            sda = new SqlCommand("showticketproc @user", con);
            con.Open();
            SqlParameter User = new SqlParameter("@user", str1);
            sda.Parameters.Add(User);
            SqlDataReader sdr = sda.ExecuteReader();
            List<Ticket> li = new List<Ticket>();
            while (sdr.Read())
            {
                Ticket sd = new Ticket()
                {
                    userid = Convert.ToString(sdr[0]),
                    bookingid = Convert.ToString(sdr[1]),
                    showid = Convert.ToString(sdr[2]),
                    seatno = Convert.ToString(sdr[3]),
                   
                };
                li.Add(sd);
                
                
            }
            con.Close();

            return View(li);

        }
         
        }

    }

