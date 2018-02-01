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

    }
}
