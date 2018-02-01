using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using BusinessEntities;
using common;

namespace OnlineMovie.Controllers
{
    public class MovieBookingController : Controller
    {
        Common com = new Common();

        public ActionResult Index()
        {
            
            SqlCommand sda;
            SqlConnection con = new SqlConnection(com.Connection);
            sda = new SqlCommand("currentproc", con);
            con.Open();
            SqlDataReader sdr = sda.ExecuteReader();
            List<AddMovie> li = new List<AddMovie>();
            while (sdr.Read())
            {
                AddMovie sd = new AddMovie()
                {
                    showid = Convert.ToString(sdr[0]),
                    moviename = Convert.ToString(sdr[1]),
                    date = Convert.ToDateTime(sdr[2].ToString()),
                    starttime = Convert.ToDateTime(sdr[3].ToString()),
                    endtime = Convert.ToDateTime(sdr[4].ToString())
                };
                li.Add(sd);
                ViewBag.a = sdr[0];
                ViewBag.b = sdr[1];
                ViewBag.c = sdr[2];
                ViewBag.d = sdr[3];
                ViewBag.e = sdr[4];
            }
            con.Close();

            return View(li);

        }
        [HttpPost]
        public ActionResult Index(string str)
        {
            str = Request["showid"];
           Session["s"] = str;

          
               
                SqlCommand sda;
                SqlConnection con = new SqlConnection(com.Connection);
                SqlConnection con1 = new SqlConnection(com.Connection);
                sda = new SqlCommand("existsproc @sid", con);
                con.Open();
                SqlParameter p1 = new SqlParameter("@sid", str);
                sda.Parameters.Add(p1);
                int result = (int)sda.ExecuteScalar();
                if (result == 1)
                {
                    return RedirectToAction("Index", "seathome");

                }
                else
                {
                    SqlCommand sda1;
                    sda1 = new SqlCommand("currentproc", con);
                    con1.Open();
                    SqlDataReader sdr = sda1.ExecuteReader();
                    List<AddMovie> li = new List<AddMovie>();
                    while (sdr.Read())
                    {
                        AddMovie sd = new AddMovie()
                        {
                            showid = Convert.ToString(sdr[0]),
                            moviename = Convert.ToString(sdr[1]),
                            date = Convert.ToDateTime(sdr[2].ToString()),
                            starttime = Convert.ToDateTime(sdr[3].ToString()),
                            endtime = Convert.ToDateTime(sdr[4].ToString())
                        };
                        li.Add(sd);
                        ViewBag.a = sdr[0];
                        ViewBag.b = sdr[1];
                        ViewBag.c = sdr[2];
                        ViewBag.d = sdr[3];
                        ViewBag.e = sdr[4];
                    }
                    con1.Close();
                    ViewBag.err = "invalid show id";
                    return View(li);
                }

            }


        }
    
    }

