using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineMovie;
using System.Web.Mvc;
using BusinessEntities;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using DataAccessLayer;
using BussinessLayer;

namespace OnlineMovie.Tests
{
    /// <summary>
    /// Summary description for UnitTest
    /// </summary>
    [TestClass]
    public class UnitTest
    {
        Login c = new Login();


       
        Controllers.HomeController hc = new Controllers.HomeController();
        public UnitTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

         [TestMethod]
        public void testmethod0()                   //admin login failed 
        {
                                
            Login lg = new Login();           //connection is not established
            lg.userid = "admin@admin.com";
            lg.password = "admin";
            Data da = new Data();
            string expected = "Exception Error";
            string actual = da.validateuser(lg);
            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod]
        public void testmethod1()                   //admin login
        {       
                  
            Login lg = new Login();
            lg.userid = "admin@admin.com";
            lg.password = "admin123";
            Data da = new Data();

            string expected = "loged in as admin";
            string actual = da.validateuser(lg);
            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod]
        public void testmethod1b()                   //admin login
        {
           
            Login lg = new Login();
            lg.userid = "admin@admin";
            lg.password = "admin1";
            Data da = new Data();

            int expected = 0;
            string actual = da.validateuser(lg);
            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod]
        public void testmethod1a()                   //admin invalid login
        {
            
            Login lg = new Login();
            lg.userid = "abcd";
            lg.password = "dcba";
            Data da = new Data();

            int expected = 2;
            string actual = da.validateuser(lg);
            Assert.AreNotEqual(expected, actual);
           
        }

        [TestMethod]
        public void testmethod2()               //user register
        {           
           
            CustomerRegistration r = new CustomerRegistration();
            r.userid = "uma12345@gmail.com";
            r.name = "uma";
            r.mobile = "9989199984";
            r.password = "uma123";
            r.answer = "mahi";
            Data c = new Data();
            int expected = 1;
            string actual = c.registeruser(r);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void testmethod3()               //forgot password
        {
            
           
            ForgetPassword fg = new ForgetPassword();
            fg.userid = "ab@ab";
            fg.answer = "axc";
            Data c = new Data();
            int expected = 1;
            string actual = c.forgetpass(fg);
            Assert.AreEqual(expected, actual);
            

        }

        [TestMethod]
        public void testmethod4()               //update price
        {

           
            UpdateSeatPrice u = new UpdateSeatPrice();
            u.type = "platinum";
            u.price = 555;
            Data c1 = new Data();
            int expected = 1;
            string actual = c1.seatprice(u);
            Assert.AreEqual(expected, actual);
           

        }

        [TestMethod]
        public void testmethod5()           //add movie
        {
         
           AddMovie am = new AddMovie();
            am.showid = "323457";
            am.moviename = "mirchiprabhas";
            am.date = Convert.ToDateTime("2017-06-02");
            am.starttime = DateTime.Parse(("03:30 PM").ToString());
            am.endtime = DateTime.Parse(("06:00 PM").ToString());
            Data da = new Data();
            string expected = "Movie Added Successfully";
            string actual = da.movieadd(am);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testmethod6()           //user login for valid
        {
           
            Login cl = new Login();
            cl.userid = "ab@ab";
            cl.password = "ab@ab";

            Data d = new Data();
            int expected = 1;
            string actual = d.validateuser(cl);
            Assert.AreEqual(expected, actual);
           
        }

        [TestMethod]
        public void testmethod7()           //user login for invalid
        {
            
            Login cl = new Login();
            cl.userid = "mahi@gmail.com";
            cl.password = "uma";
            Data d = new Data();
            int expected = 0;
            string actual = d.validateuser(cl);
            Assert.AreEqual(expected, actual);
            
        }
        [TestMethod]
        public void testmethod8()//Home Controller
        {
            Controllers.HomeController hc = new Controllers.HomeController();
            Layer l = new Layer();
            var res = hc.Index() as ViewResult;
            Assert.AreEqual("Cinema Cafe", res.ViewName);


        }

        [TestMethod]
        public void testmethod9()                   //admin login
        {
           
            Login lg = new Login();
            lg.userid = "admin@admin";
            lg.password="admin@admin";
            Data da = new Data();
            Layer l = new Layer();
            string ab = da.validateuser(lg);
            var res = hc.Index() as ViewResult;
            var a = res.Model as Login;
            Assert.IsNotNull(res);
            Assert.AreEqual("AdminHome",a.userid,a.password);
            
        }
        [TestMethod]
        public void testmethod10()
        {
          
            Login lg = new Login();
           
           
            Data da = new Data();
            var res = hc.Index( lg.userid = "admin@admin", lg.password = "admin@admin");
            Assert.AreEqual("AdminHome",hc.Response);
            
        }
    }
}
    
