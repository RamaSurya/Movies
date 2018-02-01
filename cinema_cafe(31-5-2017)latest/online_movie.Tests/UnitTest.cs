using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessEntities;
using BussinessLayer;
using DataAccessLayer;
using OnlineMovie;
using OnlineMovie.Controllers;
using Common;
using System.Web.Mvc;

namespace OnlineMovie.Tests
{

    [TestClass]
    public class OnlineMovieTestCases
    {




        [TestMethod]
        public void TestMethod_For_ValidateUser_In_LayerClass()
        {
            Login Login = new Login();
            Login.userid = "ab.ab@gmail.com";
            Login.password = "Aleena@12";
            Layer Layer = new Layer();
            string Result = Layer.Validate(Login);
            string expected = "loged in as customer";
            Assert.AreEqual(expected, Result);
        }



        [TestMethod]
        public void TestMethod_For_ValidateAdmin_In_LayerClass()
        {
            Login Login = new Login();
            Login.userid = "Admin@Admin.com";
            Login.password = "admin123";
            Layer Layer = new Layer();
            string Result = Layer.Validate(Login);
            string expected = "loged in as admin";
            Assert.AreEqual(expected, Result);
        }



        [TestMethod]
        public void TestMethod_For_InValidate_Login_In_LayerClass()
        {
            Login Login = new Login();
            Login.userid = "Admin@ad.com";
            Login.password = "admin1234";
            Layer Layer = new Layer();
            string Result = Layer.Validate(Login);
            string expected = "Invalid Userid or Password";
            Assert.AreEqual(expected, Result);
        }




        [TestMethod]
        public void TestMethod_For_UserRegister()
        {
            CustomerRegistration CustomerRegistration = new CustomerRegistration();
            CustomerRegistration.userid = "Swami@gmail.com";
            CustomerRegistration.name = "prasadRao ";
            CustomerRegistration.mobile = "9658743219";
            CustomerRegistration.password = "Dayyam";
            CustomerRegistration.answer = "Kulli";
            Layer Layer = new Layer();
            string Result = Layer.Register(CustomerRegistration);
            string expected = "Successfully Registered";
            Assert.AreEqual(expected, Result);
        }




        [TestMethod]
        public void TestMethod_For_UserRegister_Already_Exists()
        {
            CustomerRegistration CustomerRegistration = new CustomerRegistration();
            CustomerRegistration.userid = "Swami@gmail.com";
            CustomerRegistration.name = "prasadRao ";
            CustomerRegistration.mobile = "9658743219";
            CustomerRegistration.password = "Dayyam";
            CustomerRegistration.answer = "Kulli";
            Layer Layer = new Layer();
            string Result = Layer.Register(CustomerRegistration);
            string expected =  "This user already exists";
            Assert.AreEqual(expected, Result);
        }




        [TestMethod]
        public void TestMethod_For_UserRegister_DidNot_Match_Validation()
        {
            CustomerRegistration CustomerRegistration = new CustomerRegistration();
            CustomerRegistration.userid = "werrt";
            CustomerRegistration.name = "sdfhkjd ";
            CustomerRegistration.mobile = "564658556";
            CustomerRegistration.password = "fsdgrtdh";
            CustomerRegistration.answer = "dfasdgs";
            Layer Layer = new Layer();
            string Result = Layer.Register(CustomerRegistration);
            string expected =  "Unable to register";
            Assert.AreEqual(expected, Result);
        }





        [TestMethod]
        public void TestMethod_For_Updating_SeatPrice()
        {
            UpdateSeatPrice UpdateSeatPrice = new UpdateSeatPrice();
            UpdateSeatPrice.type = "Platinum";
            UpdateSeatPrice.price = 500;
            Layer layer = new Layer();
            string Result = layer.UpdateSeatPrice(UpdateSeatPrice);
            string Expected = "Updated Seat Price";
            Assert.AreEqual(Expected,Result);
        }


        [TestMethod]
        public void TestMethod_For__Unable_To_UpdateSeatPrice()
        {
            UpdateSeatPrice UpdateSeatPrice = new UpdateSeatPrice();
            UpdateSeatPrice.type = "";
            UpdateSeatPrice.price = 40;
            Layer layer = new Layer();
            string Result = layer.UpdateSeatPrice(UpdateSeatPrice);
            string Expected = "Unable to Update Seat Price";
            Assert.AreEqual(Expected, Result);
        }



        [TestMethod]
        public void TestMethod_For_AddMovie()           //add movie
        {

            AddMovie am = new AddMovie();
            am.showid = "323457";
            am.moviename = "mirchiprabhas";
            am.date = Convert.ToDateTime("2017-06-02");
            am.starttime = DateTime.Parse(("03:30 PM").ToString());
            am.endtime = DateTime.Parse(("06:00 PM").ToString());
            Layer la = new Layer();
            string expected = "Movie Added Successfully";
            string actual = la.AddMovie(am);
            Assert.AreEqual(expected, actual);
        }



        [TestMethod]
        public void TestMethod_For_Movie_Already_Exists()           // Movie already exists
        {

            AddMovie am = new AddMovie();
            am.showid = "323457";
            am.moviename = "mirchiprabhas";
            am.date = Convert.ToDateTime("2017-06-02");
            am.starttime = DateTime.Parse(("03:30 PM").ToString());
            am.endtime = DateTime.Parse(("06:00 PM").ToString());
            Layer la = new Layer();
            string expected = "This Movie already exists";
            string actual = la.AddMovie(am);
            Assert.AreEqual(expected, actual);
        }



        [TestMethod]
        public void TestMethod_For_Unable_To_AddMovie()           // Unable to Add Movie 
        {

            AddMovie am = new AddMovie();
            am.showid = "323457";
            am.moviename = "mirchiprabhas";
            am.date = Convert.ToDateTime("");
            am.starttime = DateTime.Parse(("03:30 PM").ToString());
            am.endtime = DateTime.Parse(("06:00 PM").ToString());
            Layer la = new Layer();
            string expected = "Unable to Add Movie";
            string actual = la.AddMovie(am);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestMethod_For_Edit_Profile()               //user register already exists
        {

            CustomerRegistration CustomerRegistration = new CustomerRegistration();
            CustomerRegistration.userid = "testingtest@gmail.com";
            CustomerRegistration.name = "tester";
            CustomerRegistration.mobile = "9989199984";
            CustomerRegistration.password = "test123";
            CustomerRegistration.answer = "test";
            Layer Layer = new Layer();
            string expected =  "edited successfully";
            string actual = Layer.EditProfile(CustomerRegistration);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestMethod_For_Unable_To_Edit_Profile()               //user register already exists
        {

            CustomerRegistration CustomerRegistration = new CustomerRegistration();
            CustomerRegistration.userid = "testingtest@gmail.com";
            CustomerRegistration.name = "tester";
            CustomerRegistration.mobile = "9989199";
            CustomerRegistration.password = "test123";
            CustomerRegistration.answer = "test";
            Layer Layer = new Layer();
            string expected = "unable to edit";
            string actual = Layer.EditProfile(CustomerRegistration);
            Assert.AreEqual(expected, actual);
        }



        Controllers.HomeController hc = new Controllers.HomeController();

         //-------------------------------------DataAccess Layer-----------------------------------






        [TestMethod]
        public void TestMethod_For_InValid_Admin()                   //admin login failed 
        {

            Login lg = new Login();           //connection is not established
            lg.userid = "admin@admin.com";
            lg.password = "admin";
            Data da = new Data();
            string expected =  "login failed";
            string actual = da.ValidateUser(lg);
            Assert.AreEqual(expected, actual);

        }



        [TestMethod]
        public void TestMethod_For_Valid_Admin()                   //admin login
        {

            Login lg = new Login();
            lg.userid = "admin@admin.com";
            lg.password = "admin123";
            Data da = new Data();

            string expected = "loged in as admin";
            string actual = da.ValidateUser(lg);
            Assert.AreEqual(expected, actual);

        }



        [TestMethod]
        public void TestMethod_For_Admin()                   //admin login fails
        {

            Login lg = new Login();
            lg.userid = "admin@admin";
            lg.password = "admin1";
            Data da = new Data();
            //int expected = 0;
            //string actual = da.ValidateUser(lg);
            //Assert.AreEqual(expected, actual);

        }



        [TestMethod]
        public void TestMethod_For_InValid_User()                   //user invalid login
        {

            Login lg = new Login();
            lg.userid = "abcd";
            lg.password = "dcba";
            Data da = new Data();

            int expected = 2;
            string actual = da.ValidateUser(lg);
            Assert.AreNotEqual(expected, actual);

        }



        [TestMethod]
        public void TestMethod_For_Failed_User_Registration()               //user register
        {

            CustomerRegistration CustomerRegistration = new CustomerRegistration();
            CustomerRegistration.userid = "uma12345@gmail.com";
            CustomerRegistration.name = "uma";
            CustomerRegistration.mobile = "9989199984";
            CustomerRegistration.password = "uma123";
            CustomerRegistration.answer = "mahi";
            Data c = new Data();
            string expected = "registration Failed";
            string actual = c.RegisterUser(CustomerRegistration);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod_For_User_Registration()               //user register
        {

            CustomerRegistration CustomerRegistration = new CustomerRegistration();
            CustomerRegistration.userid = "uma12345@gmail.com";
            CustomerRegistration.name = "umamaheswari";
            CustomerRegistration.mobile = "9989199984";
            CustomerRegistration.password = "uma123";
            CustomerRegistration.answer = "mahi";
            Data c = new Data();
            string expected ="Successfully Registered";
            string actual = c.RegisterUser(CustomerRegistration);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestMethod_For_Already_Exists_User_Registration()               //user register already exists
        {

            CustomerRegistration CustomerRegistration = new CustomerRegistration();
            CustomerRegistration.userid = "uma12345@gmail.com";
            CustomerRegistration.name = "umamaheswari";
            CustomerRegistration.mobile = "9989199984";
            CustomerRegistration.password = "uma123";
            CustomerRegistration.answer = "mahi";
            Data c = new Data();
            string expected = "registration Failed";                         // "User Already Exists";
            string actual = c.RegisterUser(CustomerRegistration);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestMethod_For_ForgotPassword()               //forgot password
        {

            ForgetPassword forgetpassword = new ForgetPassword();
            forgetpassword.userid = "testingtest@gmail.com";
            forgetpassword.answer = "answer";
            Data c = new Data();
            string expected =  "Successfully Loged in";
            string actual = c.ForgetPass(forgetpassword);
            Assert.AreEqual(expected, actual);


        }


        [TestMethod]
        public void TestMethod_For_Invalid_Credentials_ForgotPassword()               //forgot password
        {


            ForgetPassword forgetpassword = new ForgetPassword();
            forgetpassword.userid = "ab@ab";
            forgetpassword.answer = "axc";
            Data c = new Data();
            string expected =  "Invalid Credentials";
            string actual = c.ForgetPass(forgetpassword);
            Assert.AreEqual(expected, actual);


        }


        [TestMethod]
        public void TestMethod_For_Unable_To_Connect_ForgotPassword_Login()               //forgot password
        {


            ForgetPassword forgetpassword = new ForgetPassword();
            forgetpassword.userid = "ab@ab";
            forgetpassword.answer = "asdf";
            Data c = new Data();
            string expected = "Unable to Login";
            string actual = c.ForgetPass(forgetpassword);
            Assert.AreEqual(expected, actual);


        }


        [TestMethod]
        public void TestMethod_For_Update_Price()               //update price
        {


            UpdateSeatPrice UpdateSeatPrice = new UpdateSeatPrice();
            UpdateSeatPrice.type = "platinum";
            UpdateSeatPrice.price = 555;
            Data c1 = new Data();
            string expected =  "Updated Seat Price";
            string actual = c1.SeatPrice(UpdateSeatPrice);
            Assert.AreEqual(expected, actual);


        }


        [TestMethod]
        public void TestMethod_For__UnableTo_UpdateSeatPrice()
        {
            UpdateSeatPrice UpdateSeatPrice = new UpdateSeatPrice();
            UpdateSeatPrice.type = "";
            UpdateSeatPrice.price = 300;
            Data dl = new Data();
            string Result = dl.SeatPrice(UpdateSeatPrice);
            string Expected = "Unable to Add Movie"; //"Unable to Update Seat Price";
            Assert.AreEqual(Expected, Result);
        }



        [TestMethod]
        public void TestMethod_For_Seat_Price_Not_Valid()
        {
            UpdateSeatPrice UpdateSeatPrice = new UpdateSeatPrice();
            UpdateSeatPrice.type = "Platinum";
            UpdateSeatPrice.price = 30;
            Data dl = new Data();
            string Result = dl.SeatPrice(UpdateSeatPrice);
            string Expected = "Not a Valid Price";
            Assert.AreEqual(Expected, Result);
        }




        [TestMethod]
        public void TestMethod_For_AddMovie_Success()           //add movie
        {

            AddMovie addmovie = new AddMovie();
            addmovie.showid = "323457";
            addmovie.moviename = "mirchiprabhas";
            addmovie.date = Convert.ToDateTime("2017-06-02");
            addmovie.starttime = DateTime.Parse(("03:30 PM").ToString());
            addmovie.endtime = DateTime.Parse(("06:00 PM").ToString());
            Layer la = new Layer();
            string expected =  "Movie Added Successfully";
            string actual = la.AddMovie(addmovie);
            Assert.AreEqual(expected, actual);
        }



        [TestMethod]
        public void TestMethod_For_Movie_AlreadyExists()           // Movie already exists
        {

            AddMovie addmovie = new AddMovie();
            addmovie.showid = "323457";
            addmovie.moviename = "mirchiprabhas";
            addmovie.date = Convert.ToDateTime("2017-06-02");
            addmovie.starttime = DateTime.Parse(("03:30 PM").ToString());
            addmovie.endtime = DateTime.Parse(("06:00 PM").ToString());
            Layer la = new Layer();
            string expected = "This Movie already exists";
            string actual = la.AddMovie(addmovie);
            Assert.AreEqual(expected, actual);
        }



        [TestMethod]
        public void TestMethod_For_UnableTo_AddMovie()           // Unable to Add Movie 
        {

            AddMovie addmovie = new AddMovie();
            addmovie.showid = "323457";
            addmovie.moviename = "mirchiprabhas";
            addmovie.date = Convert.ToDateTime("");
            addmovie.starttime = DateTime.Parse(("03:30 PM").ToString());
            addmovie.endtime = DateTime.Parse(("06:00 PM").ToString());
            Layer la = new Layer();
            string expected = "Unable to Add Movie";
            string actual = la.AddMovie(addmovie);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestMethodFor_Edit_Profile()               //user register already exists
        {

            CustomerRegistration CustomerRegistration = new CustomerRegistration();
            CustomerRegistration.userid = "uma12345@gmail.com";
            CustomerRegistration.name = "maheswari";
            CustomerRegistration.mobile = "9989199984";
            CustomerRegistration.password = "uma123";
            CustomerRegistration.answer = "mahi";
            Data c = new Data();
            string expected = "edited successfully";
            string actual = c.EditUser(CustomerRegistration);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod_For_UnableTo_EditProfile()               //user register already exists
        {

            CustomerRegistration CustomerRegistration = new CustomerRegistration();
            CustomerRegistration.userid = "uma12345@gmail.com";
            CustomerRegistration.name = "maheswari";
            CustomerRegistration.mobile = "9989199";
            CustomerRegistration.password = "uma123";
            CustomerRegistration.answer = "mahi";
            Data c = new Data();
            string expected = "unable to edit";
            string actual = c.EditUser(CustomerRegistration);
            Assert.AreEqual(expected, actual);
        }

       // -------------------------------------------Controllers---------------------


        [TestMethod]
        public void TestMethod_For_HomeController_Index()//Home Controller
        {
            Controllers.HomeController hc = new Controllers.HomeController();
            Layer l = new Layer();
            var res = hc.Index() as ViewResult;
            Assert.AreEqual("", res.ViewName);


        }




        [TestMethod]
        public void TestMethod_For_HomeController_ValidateUser()                   //admin login
        {

            Login lg = new Login();
            lg.userid = "admin@admin";
            lg.password = "admin@admin";
            Data da = new Data();
            Layer l = new Layer();
            string ab = da.ValidateUser(lg);
            var res = hc.Index() as ViewResult;
            var a = res.Model as Login;
            Assert.IsNotNull(res);
            

        }



        [TestMethod]
        public void TestMethod_For_EditProfileController_Index()
        {

            EditProfileController Edit = new EditProfileController();
            CustomerRegistration EditProfile = new CustomerRegistration();
            EditProfile.name = "tester";
            EditProfile.mobile = "9874512663";
            EditProfile.userid="testingtest@gmail.com";
            EditProfile.password = "tester123";
            EditProfile.answer = "tester";
            ViewResult res = Edit.Index(EditProfile.name, EditProfile.mobile, EditProfile.userid, EditProfile.password, EditProfile.answer) as ViewResult;
             Assert.AreEqual("profile edited Successfully", res.ViewBag.Message_For_Edit_Profile);

        }



        [TestMethod]
        public void TestMethod_For_EditProfileController_Index_CannotEdit()
        {

            EditProfileController Edit = new EditProfileController();
            CustomerRegistration EditProfile = new CustomerRegistration();
            EditProfile.name = "";
            EditProfile.mobile = "9874512663";
            EditProfile.userid = "testingtest@gmail.com";
            EditProfile.password = "tester123";
            EditProfile.answer = "tester";
            ViewResult res = Edit.Index(EditProfile.name, EditProfile.mobile, EditProfile.userid, EditProfile.password, EditProfile.answer) as ViewResult;
           Assert.AreEqual("cannot edit your profile", res.ViewBag.Message_For_Edit_Profile);
          
        }

        [TestMethod]
        public void TestMethod_For_ForgotPasswordController()
        {
            ForgotPasswordController forget = new ForgotPasswordController();
            CustomerRegistration Login = new CustomerRegistration();
            Login.userid = "testingtest@gmail.com";
            Login.answer = "tester";
            //RedirectToRouteResult res = forget.Index(Login.userid, Login.answer) as RedirectToRouteResult;
            //Assert.AreEqual("CustomerHome",res.RouteName);

        }


        [TestMethod]
        public void TestMethod_For_ForgotPasswordController_UnabletoConnect()
        {
            ForgotPasswordController forget = new ForgotPasswordController();
            CustomerRegistration Login = new CustomerRegistration();
            Login.userid = "testingtest@gmail.com";
            Login.answer = "";
            ViewResult res = forget.Index(Login.userid, Login.answer) as ViewResult;
            Assert.AreEqual("unable to connect", res.ViewBag.Message_For_Forgot_Password);
            
        }


        [TestMethod]
        public void TestMethod_For_ForgotPasswordController_Invalid()
        {
            ForgotPasswordController forget = new ForgotPasswordController();
            CustomerRegistration Login = new CustomerRegistration();
            Login.userid = "testingtest@gmail.com";
            Login.answer = "test123";
            ViewResult res = forget.Index(Login.userid, Login.answer) as ViewResult;
            Assert.AreEqual("invalid userid or answer", res.ViewBag.Message_For_Forgot_Password);

        }
    }
}
    
