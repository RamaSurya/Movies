using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_entities;
using Data_access_layer;

namespace Bussiness_layer
{
    public class layercls
    {
        public int validate(String userid, string password)
        {
            try
            {
                logincls login_object = new logincls();
                login_object.userid = userid;
                login_object.password = password;
                Datacls data_object = new Datacls();
                int userval = data_object.validateuser(login_object);
                return userval;
            }
            catch 
            {
                return 4;
            }
            
        }
        public int register(string name,string mobile,string userid, string password,string answer)
        {
            try
            {
                registrationcls register_object =new registrationcls();
                register_object.name = name;
                register_object.mobile = mobile;
                register_object.userid = userid;
                register_object.password = password;
                register_object.answer = answer;
                Datacls data_object = new Datacls();
                data_object.registeruser(register_object);
                return 1;
                
            }
            catch
            {
                return 2;
            }

        }
        public int updateseatprice(string type, int price)
        {
            try
            {
                updatepricecls price_object = new updatepricecls();
                price_object.type = type;
                price_object.price = price;
                Datacls data_object = new Datacls();
                data_object.seatprice(price_object);
                return 1;

            }
            catch
            {
                return 2;
            }

        }
        public int addmovie(string showid, string moviename, DateTime date, DateTime starttime, DateTime endtime)
        {
            try
            {
                addmoviecls movie_object = new addmoviecls();
                movie_object.moviename = moviename;
                movie_object.date = date;
                movie_object.starttime =starttime;
                movie_object.endtime = endtime;
                Datacls data_object = new Datacls();
                data_object.movieadd(movie_object);
                return 1;

            }
            catch
            {
                return 2;
            }

        }
        public int forget(string userid,string answer)
        {
            try
            {
                forgetpasswordcls answer_object = new forgetpasswordcls();
                answer_object.userid = userid;
                answer_object.answer = answer;
                Datacls data_object = new Datacls();
                int result=data_object.forgetpass(answer_object);
                if (result == 1)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }

            }
            catch
            {
                return 4;
            }

        }

    }
}
