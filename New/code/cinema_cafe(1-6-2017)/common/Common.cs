using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace common
{
    public class Common
    {
        public readonly string login_proc = "loginproc @user,@pawd";

        public readonly string register_proc = "insertproc @name,@mob,@user,@pawd,@ans";

        public readonly string price_proc = "priceproc @type,@price";

        public readonly string addmovie_proc = "addproc @sid,@mname,@sdate,@stime,@etime";

        public readonly string forgetpassword_proc = "forgotproc @user,@ans";
        public string Connection;
        public Common()
        {
            try
            {
                Connection = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            }
            catch(Exception)
            {
                Connection="server=172.16.170.165;database=MovieTickets;uid=sa;password=Passw0rd@12";
            }
        }
    }
}

