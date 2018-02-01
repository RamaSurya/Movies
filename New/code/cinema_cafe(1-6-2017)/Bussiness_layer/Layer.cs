using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using DataAccessLayer;

namespace BussinessLayer
{
    public class Layer
    {
        public string validate(String userid, string password)
        {
            try
            {
                Login login_object = new Login();
                login_object.userid = userid;
                login_object.password = password;
                Data data_object = new Data();
                string userval = data_object.validateuser(login_object);
                return userval;//validated
            }
            catch 
            {
                return "login failed";//unable to connect
            }
            
        }
        public string register(string name,string mobile,string userid, string password,string answer)
        {
            try
            {
                CustomerRegistration register_object =new CustomerRegistration();
                register_object.name = name;
                register_object.mobile = mobile;
                register_object.userid = userid;
                register_object.password = password;
                register_object.answer = answer;
                Data data_object = new Data();
                data_object.registeruser(register_object);
                return "Successfully Registered";//when data is inserted
                
            }
            catch
            {
                return "registration Failed";//unable to insert data
            }

        }
        public string updateseatprice(string type, int price)
        {
            try
            {
                UpdateSeatPrice price_object = new UpdateSeatPrice();
                price_object.type = type;
                price_object.price = price;
                Data data_object = new Data();
                data_object.seatprice(price_object);
                return "Updated Seat Price";//updated the price

            }
            catch
            {
                return "Unable to Update Seat Price";//unable to update
            }

        }
        public string addmovie(string showid, string moviename, DateTime date, DateTime starttime, DateTime endtime)
        {
            try
            {
                AddMovie movie_object = new AddMovie();
                movie_object.moviename = moviename;
                movie_object.date = date;
                movie_object.starttime =starttime;
                movie_object.endtime = endtime;
                Data data_object = new Data();
                data_object.movieadd(movie_object);
                return "Movie Added Successfully";//added the movies

            }
            catch
            {
                return "Unable to Add Movie";//unable to add the movies
            }

        }
        public string forget(string userid,string answer)
        {
            try
            {
                ForgetPassword answer_object = new ForgetPassword();
                answer_object.userid = userid;
                answer_object.answer = answer;
                Data data_object = new Data();
                string result=data_object.forgetpass(answer_object);
                if (result == "Successfully Loged in")
                {
                    return "Successfully Loged in";//answer is matching
                }
                else
                {
                    return "Unable to Login";//answer is not matching
                }

            }
            catch
            {
                return "Exception Error";//unable to establish the connection
            }

        }

    }
}
