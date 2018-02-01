using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Common;
using System.Configuration;
using BussinessLayer;
using BusinessEntities;


namespace OnlineMovie.Controllers
{
    public class EditProfileController : Controller
    {
        Commoncls com = new Commoncls();
        
        public ActionResult Index()
        {
            string user = Session["suserid"].ToString();
            ViewBag.Message_For_Admin_Session = user;
            SqlCommand sda;
            SqlConnection con = new SqlConnection(com.connection);
            sda = new SqlCommand("edit @user", con);
            con.Open();
            SqlParameter showid = new SqlParameter("@user", user);
            sda.Parameters.Add(showid);
            SqlDataReader sdr = sda.ExecuteReader();

            while (sdr.Read())
            {
                
                ViewBag.name = sdr[0];
                ViewBag.userid = sdr[1];
                ViewBag.password = sdr[2];
                ViewBag.answer = sdr[3];
                ViewBag.mobile = sdr[4];
            }
            con.Close();

             return View();
        }
        [HttpPost]
        public ActionResult Index( string name, string mobile,string userid, string password, string answer)
        {
            CustomerRegistration editObject2 = new CustomerRegistration();
            editObject2.name = Request["name"];
            editObject2.mobile = Request["mobilenumber"];
            editObject2.password = Request["password"];
            editObject2.answer = Request["answer"];
            editObject2.userid = Request["userid"];
            

                Layer ob = new Layer();
                string result = ob.EditProfile(editObject2);
                
                
                if (result == "Successfully edited")
                {

                    ViewBag.Message_For_Edit_Profile = "profile edited Successfully";
                    return View();
                }
                else 
                {
                    ViewBag.Message_For_Edit_Profile = "cannot edit your profile";
                    return View();
                }
           
        }
    }
}