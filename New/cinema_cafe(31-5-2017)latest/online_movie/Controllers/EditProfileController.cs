using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using common;
using System.Configuration;


namespace OnlineMovie.Controllers
{
    public class EditProfileController : Controller
    {
        Common com = new Common();
        
        public ActionResult Index()
        {
            string str1 = Session["suserid"].ToString();
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
               
                SqlCommand sda;
                SqlConnection con = new SqlConnection(com.Connection);
                sda = new SqlCommand("editproc @name,@mob,@user,@pawd,@ans", con);
                con.Open();
                SqlParameter UserName = new SqlParameter("@name", t1);
                SqlParameter UserMobileNumber = new SqlParameter("@mob", t2);
                SqlParameter UserId = new SqlParameter("@user", t3);
                SqlParameter UserPassword = new SqlParameter("@pawd", t4);
                SqlParameter UserSecurityAnswer = new SqlParameter("@ans", t5);
                sda.Parameters.Add(UserName);
                sda.Parameters.Add(UserMobileNumber);
                sda.Parameters.Add(UserId);
                sda.Parameters.Add(UserPassword);
                sda.Parameters.Add(UserSecurityAnswer);
                sda.ExecuteNonQuery();
                con.Close();
                ViewBag.Message_For_Edit_Profile = "Data updated Successfully";
                return View();
            }
            catch
            {
                ViewBag.Message_For_Edit_Profile = "unable to edit";
                return View();
            }

        }

    }
}
