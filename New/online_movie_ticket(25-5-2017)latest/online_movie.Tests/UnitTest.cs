using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using online_movie;
using System.Web.Mvc;
using Business_entities;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace online_movie.Tests
{
    /// <summary>
    /// Summary description for UnitTest
    /// </summary>
    [TestClass]
    public class UnitTest
    {
        logincls c = new logincls();



        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        SqlCommand sda;
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
        public void TestMethod1()
        {
            Controllers.homeController ob = new Controllers.homeController();
            sda = new SqlCommand("login_proc");
            SqlDataReader dr = sda.ExecuteReader();


            c.userid = dr[0].ToString();
            c.password = dr[1].ToString();

            var a = ob.Index("userid", "password") as ViewResult;

            Assert.AreEqual("admin@admin", c.userid);
            Assert.AreEqual("admin1", c.password);
            
            
        }
    }
}
