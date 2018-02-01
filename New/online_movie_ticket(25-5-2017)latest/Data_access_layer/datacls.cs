using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_entities;
using System.Data.SqlClient;
using System.Configuration;
using common;

namespace Data_access_layer
{
    public class Datacls
    {
        string connstr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        
        
        
        public int validateuser(logincls log)
        {
            SqlCommand sda;
            SqlConnection con = new SqlConnection(connstr);
            commoncls comm = new commoncls();
            
            sda = new SqlCommand(comm.login_proc, con);
            
            SqlParameter p1 = new SqlParameter("@user", log.userid);
            SqlParameter p2 = new SqlParameter("@pawd", log.password);

            sda.Parameters.Add(p1);
            sda.Parameters.Add(p2);
            con.Open();
            int result = (int)sda.ExecuteScalar();
            return result;
            
        }
        public void registeruser(registrationcls reg)
        {
            SqlCommand sda;
            SqlConnection con = new SqlConnection(connstr);
            commoncls comm = new commoncls();

            sda = new SqlCommand(comm.register_proc, con);
            
            SqlParameter p1 = new SqlParameter("@name", reg.name);
            SqlParameter p2 = new SqlParameter("@mob", reg.mobile);
            SqlParameter p3 = new SqlParameter("@user", reg.userid);
            SqlParameter p4 = new SqlParameter("@pawd", reg.password);
            SqlParameter p5 = new SqlParameter("@ans", reg.answer);
            sda.Parameters.Add(p1);
            sda.Parameters.Add(p2);
            sda.Parameters.Add(p3);
            sda.Parameters.Add(p4);
            sda.Parameters.Add(p5);
            con.Open();
            sda.ExecuteNonQuery();
            
                    

        }
        public void seatprice(updatepricecls price)
        {
            SqlCommand sda;
            SqlConnection con = new SqlConnection(connstr);
            commoncls comm = new commoncls();

            sda = new SqlCommand(comm.price_proc, con);

            SqlParameter p1 = new SqlParameter("@type", price.type);
            SqlParameter p2 = new SqlParameter("@price", price.price);
            
            sda.Parameters.Add(p1);
            sda.Parameters.Add(p2);
            
            
            con.Open();
            sda.ExecuteNonQuery();



        }
        public void movieadd(addmoviecls movie)
        {
            SqlCommand sda;
            SqlConnection con = new SqlConnection(connstr);
            commoncls comm = new commoncls();

            sda = new SqlCommand(comm.addmovie_proc, con);
            SqlParameter p1 = new SqlParameter("@sid", movie.showid);
            SqlParameter p2 = new SqlParameter("@mname", movie.moviename);
            SqlParameter p3 = new SqlParameter("@sdate", movie.date);
            SqlParameter p4 = new SqlParameter("@stime", movie.starttime);
            SqlParameter p5 = new SqlParameter("@etime", movie.endtime);

            sda.Parameters.Add(p1);
            sda.Parameters.Add(p2);
            sda.Parameters.Add(p3);
            sda.Parameters.Add(p4);
            sda.Parameters.Add(p5);
           

            con.Open();
            sda.ExecuteNonQuery();



        }
        public int forgetpass(forgetpasswordcls answer)
        {
            SqlCommand sda;
            SqlConnection con = new SqlConnection(connstr);
            commoncls comm = new commoncls();

            sda = new SqlCommand(comm.forgetpassword_proc, con);
            SqlParameter p1 = new SqlParameter("@user", answer.userid);
            SqlParameter p2 = new SqlParameter("@ans", answer.answer);
           
            sda.Parameters.Add(p1);
            sda.Parameters.Add(p2);
            con.Open();
            int result = (int)sda.ExecuteScalar();
            return result;



        }
    }
}
