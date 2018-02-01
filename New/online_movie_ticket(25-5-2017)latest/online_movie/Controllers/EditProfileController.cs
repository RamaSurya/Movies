using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace online_movie.Controllers
{
    public class EditProfileController : Controller
    {
        //
        // GET: /EditProfile/
        
        public ActionResult Index()
        {
            string str1 = TempData["suserid"].ToString();
            ViewBag.user = str1;
            return View();
        }
        [HttpPost]
        public ActionResult Index( string t1, string t2,string t3, string t4, string t5)
        {
            try
            {
                t1 = Request["name"];
                t2 = Request["mobilenumber"];
                t3 = Request["userid"];
                t4 = Request["password"];
                t5 = Request["answer"];
                string connstr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlCommand sda;
                SqlConnection con = new SqlConnection(connstr);
                sda = new SqlCommand("editproc @name,@mob,@user,@pawd,@ans", con);
                con.Open();
                SqlParameter p1 = new SqlParameter("@name", t1);
                SqlParameter p2 = new SqlParameter("@mob", t2);
                SqlParameter p3 = new SqlParameter("@user", t3);
                SqlParameter p4 = new SqlParameter("@pawd", t4);
                SqlParameter p5 = new SqlParameter("@ans", t5);
                sda.Parameters.Add(p1);
                sda.Parameters.Add(p2);
                sda.Parameters.Add(p3);
                sda.Parameters.Add(p4);
                sda.Parameters.Add(p5);
                sda.ExecuteNonQuery();
                con.Close();
                ViewBag.a = "Data updated Successfully";
                return View();
            }
            catch
            {
                ViewBag.a = "unable to edit";
                return View();
            }

        }

    }
}
