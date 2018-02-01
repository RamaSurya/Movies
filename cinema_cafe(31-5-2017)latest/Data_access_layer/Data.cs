using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using System.Data.SqlClient;
using System.Configuration;
using Common;

namespace DataAccessLayer
{
    public class Data
    {
        Commoncls com = new Commoncls();

        public string ValidateUser(Login log)
        {
            SqlCommand sda;
            SqlConnection con = new SqlConnection(com.connection);
            Commoncls comm = new Commoncls();

            sda = new SqlCommand(comm.LoginProc, con);

            SqlParameter userId = new SqlParameter("@user", log.userid);
            SqlParameter userPassword = new SqlParameter("@pawd", log.password);

            sda.Parameters.Add(userId);
            sda.Parameters.Add(userPassword);
            try
            {
                con.Open();
                int res = (int)sda.ExecuteScalar();//result to validate user if 1 user able to login
                if (res == 1)
                    return "loged in as customer";
                if (res == 2)
                    return "loged in as admin";
                if (res == 4)
                    return "login failed";
            }
            catch (Exception)
            {
                return "Exception Error";
            }
            return "Not Connected";

        }
        public string RegisterUser(CustomerRegistration reg)
        {
            SqlCommand sda;
            SqlConnection con = new SqlConnection(com.connection);
            Commoncls comm = new Commoncls();

            sda = new SqlCommand(comm.RegisterProc, con);

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
                int res = (int)sda.ExecuteNonQuery();//1 if user is registered successfully
                if (res == 1)
                    return "Successfully Registered";
                if (res == 2)
                    return "registration Failed";
                if (res == 4)
                    return "User Already Exists";
            }
            catch (Exception)
            {
                return "registration Failed"; ;//not registered
            }

            return "Not Connected";

        }
        public string SeatPrice(UpdateSeatPrice price)
        {
            SqlCommand sda;
            SqlConnection con = new SqlConnection(com.connection);
            Commoncls comm = new Commoncls();

            sda = new SqlCommand(comm.PriceProc, con);

            SqlParameter SeatType = new SqlParameter("@type", price.type);
            SqlParameter SeatPrice = new SqlParameter("@price", price.price);

            sda.Parameters.Add(SeatType);
            sda.Parameters.Add(SeatPrice);

            try
            {
                con.Open();
                int res = (int)sda.ExecuteNonQuery();
                if (res == 1)
                    return "Updated Seat Price";
                if (res == 2)
                    return "Unable to Update Seat Price";
                if (res == 4)
                    return "Not a Valid Price";
            }
            catch (Exception)
            {
                return "Unable to Update Seat Price"; ;
            }

            return "Not Connected";

        }
        public void MovieAdd(AddMovie movieObject)
        {
            SqlCommand sda;
            SqlConnection con = new SqlConnection(com.connection);
            Commoncls comm = new Commoncls();
            sda = new SqlCommand("addproc @sid,@mname,@sdate,@stime,@etime", con);
            con.Open();
            SqlParameter ShowId = new SqlParameter("@sid", movieObject.showid);
            SqlParameter MovieName = new SqlParameter("@mname", movieObject.moviename);
            SqlParameter MovieDate = new SqlParameter("@sdate", movieObject.date);
            SqlParameter MovieStartTime = new SqlParameter("@stime", movieObject.starttime);
            SqlParameter MovieEndTime = new SqlParameter("@etime", movieObject.endtime);
            sda.Parameters.Add(ShowId);
            sda.Parameters.Add(MovieName);
            sda.Parameters.Add(MovieDate);
            sda.Parameters.Add(MovieStartTime);
            sda.Parameters.Add(MovieEndTime);
            sda.ExecuteNonQuery();

            con.Close();
        }
        public string ForgetPass(ForgetPassword answer)
        {
            SqlCommand sda;
            SqlConnection con = new SqlConnection(com.connection);
            Commoncls comm = new Commoncls();

            sda = new SqlCommand(comm.ForgetpasswordProc, con);
            SqlParameter UserId = new SqlParameter("@user", answer.userid);
            SqlParameter UserAnswer = new SqlParameter("@ans", answer.answer);

            sda.Parameters.Add(UserId);
            sda.Parameters.Add(UserAnswer);
            try
            {
                con.Open();
                int res = (int)sda.ExecuteScalar();
                if (res == 1)
                    return "Successfully Loged in";
                if (res == 2)
                    return "Invalid Credentials";
                if (res == 4)
                    return "Unable to Login";
            }
            catch (Exception)
            {
                return "Unable to Login"; ;
            }
            return "Not Connected";
        }
        public string EditUser(CustomerRegistration reg)
        {

            try
            {
                SqlCommand sda;
                SqlConnection con = new SqlConnection(com.connection);
                Commoncls comm = new Commoncls();
                sda = new SqlCommand(comm.EditProc, con);
                con.Open();
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

                sda.ExecuteNonQuery();
                return "edited successfully";

            }
            catch (Exception)
            {
                return "unable to edit";
            }

        }
        public List<Ticket> TicketShow(Ticket ticket_obj)
        {
            SqlCommand sda;
            int bkid = Convert.ToInt32(ticket_obj.bookingid);
            SqlConnection con = new SqlConnection(com.connection);
            Commoncls comm = new Commoncls();
            sda = new SqlCommand(comm.TicketProc, con);
            con.Open();
            SqlParameter User = new SqlParameter("@user", ticket_obj.userid);
            SqlParameter bookId = new SqlParameter("@bkid", bkid);
            sda.Parameters.Add(User);
            sda.Parameters.Add(bookId);
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
            return (li);
        }

        public void cancellBooking(cancel reg)
        {
            Commoncls com = new Commoncls();
            SqlCommand sda1;
            SqlConnection con = new SqlConnection(com.connection);
            Commoncls comm = new Commoncls();
            sda1 = new SqlCommand(comm.CancelProc, con);//to change the status
            con.Open();

            SqlParameter bkid = new SqlParameter("@bkid",reg.bookid);//procedure to change seat status
            SqlParameter user = new SqlParameter("@user", reg.userid);

            sda1.Parameters.Add(bkid);
            sda1.Parameters.Add(user);
            sda1.ExecuteNonQuery();
            con.Close();
           
        }
    }
}

