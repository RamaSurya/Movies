using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using System.Data.SqlClient;
using System.Configuration;
using common;

namespace DataAccessLayer
{
    public class Data
    {
        Common com = new Common();
       
        public string validateuser(Login log)
        {
            SqlCommand sda;
            SqlConnection con = new SqlConnection(com.Connection);
            Common comm = new Common();
            
            sda = new SqlCommand(comm.login_proc, con);
            
            SqlParameter UserId = new SqlParameter("@user", log.userid);
            SqlParameter UserPassword = new SqlParameter("@pawd", log.password);

            sda.Parameters.Add(UserId);
            sda.Parameters.Add(UserPassword);
            try
            {
                con.Open();
                int res= (int)sda.ExecuteScalar();//result to validate user if 1 user able to login
                if (res == 1)
                    return "loged in as customer";
                if (res == 2)
                    return "loged in as admin";
                if (res == 4)
                    return "login failed";
            }
            catch(Exception)
            {
                return "Exception Error";
            }
            return "Not Connected";
            
        }
        public string registeruser(CustomerRegistration reg)
        {
            SqlCommand sda;
            SqlConnection con = new SqlConnection(com.Connection);
            Common comm = new Common();

            sda = new SqlCommand(comm.register_proc, con);
            
            SqlParameter UserName = new SqlParameter("@name", reg.name);
            SqlParameter UserMobileNumber = new SqlParameter("@mob", reg.mobile);
            SqlParameter UserId = new SqlParameter("@user", reg.userid);
            SqlParameter UserPassword = new SqlParameter("@pawd", reg.password);
            SqlParameter UserSecurityAnswer = new SqlParameter("@ans", reg.answer);
            sda.Parameters.Add(UserName);
            sda.Parameters.Add(UserMobileNumber);
            sda.Parameters.Add(UserId);
            sda.Parameters.Add(UserPassword);
            sda.Parameters.Add(UserSecurityAnswer);
            try
            {
                con.Open();
                int res= (int)sda.ExecuteNonQuery();//1 if user is registered successfully
                if (res == 1)
                    return "Successfully Registered";
                if (res == 2)
                    return "registration Failed";
                if (res == 4)
                    return "User Already Exists";
            }
            catch(Exception)
            {
                return "Exception Error"; ;//not registered
            }

            return "Not Connected";    

        }
        public string seatprice(UpdateSeatPrice price)
        {
            SqlCommand sda;
            SqlConnection con = new SqlConnection(com.Connection);
            Common comm = new Common();

            sda = new SqlCommand(comm.price_proc, con);

            SqlParameter SeatType = new SqlParameter("@type", price.type);
            SqlParameter SeatPrice = new SqlParameter("@price", price.price);

            sda.Parameters.Add(SeatType);
            sda.Parameters.Add(SeatPrice);

            try
            {
                con.Open();
                int res= (int)sda.ExecuteNonQuery();
                if (res == 1)
                    return "Updated Seat Price";
                if (res == 2)
                    return "Unable to Update Seat Price";
                if (res == 4)
                    return "Not a Valid Price";
            }
            catch(Exception)
            {
                return "Exception Error"; ;
            }

            return "Not Connected";

        }
        public string movieadd(AddMovie movie)
        {
            SqlCommand sda;
            SqlConnection con = new SqlConnection(com.Connection);
            Common comm = new Common();

            sda = new SqlCommand(comm.addmovie_proc, con);
            SqlParameter Showid = new SqlParameter("@sid", movie.showid);
            SqlParameter MovieName = new SqlParameter("@mname", movie.moviename);
            SqlParameter MovieDate = new SqlParameter("@sdate", movie.date);
            SqlParameter MovieStartTime = new SqlParameter("@stime", movie.starttime);
            SqlParameter MovieEndTime = new SqlParameter("@etime", movie.endtime);

            sda.Parameters.Add(Showid);
            sda.Parameters.Add(MovieName);
            sda.Parameters.Add(MovieDate);
            sda.Parameters.Add(MovieStartTime);
            sda.Parameters.Add(MovieEndTime);
            try
            {
                con.Open();
                int res= (int)sda.ExecuteNonQuery();
                if (res == 2)
                    return "Movie Added Successfully";
                if (res == 1)
                    return "Movie Already Exists";
                if (res == 4)
                    return "Unable to Add Movie";
            }
            catch(Exception)
            {
                return "Exception Error"; ;
            }

            return "Not Connected";


        }
        public string forgetpass(ForgetPassword answer)
        {
            SqlCommand sda;
            SqlConnection con = new SqlConnection(com.Connection);
            Common comm = new Common();

            sda = new SqlCommand(comm.forgetpassword_proc, con);
            SqlParameter UserId = new SqlParameter("@user", answer.userid);
            SqlParameter UserAnswer = new SqlParameter("@ans", answer.answer);

            sda.Parameters.Add(UserId);
            sda.Parameters.Add(UserAnswer);
            try
            {
                con.Open();
                int res= (int)sda.ExecuteScalar();
                if (res == 1)
                    return "Successfully Loged in";
                if (res == 2)
                    return "Invalid Credentials";
                if (res == 4)
                    return "Unable to Login";
            }
            catch(Exception)
            {
                return "Exception Error"; ;
            }
            return "Not Connected";
        }
    }
}
