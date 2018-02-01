using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Common
{
    public class Commoncls
    {
        public readonly string LoginProc = "loginproc @user,@pawd";

        public readonly string RegisterProc = "insertproc @name,@mob,@user,@pawd,@ans";

        public readonly string PriceProc = "priceproc @type,@price";

        public readonly string AddmovieProc = "addproc @sid,@mname,@sdate,@stime,@etime";

        public readonly string ForgetpasswordProc = "forgotproc @user,@ans";
        public readonly string EditProc = "editproc @name,@mob,@user,@pawd,@ans";
        public readonly string TicketProc = "showticketproc @user,@bkid";
        public readonly string CancelProc = "cancelproc @bkid,@user";
        public string connection;
        public Commoncls()
        {
            try
            {
                connection = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            }
            catch(Exception)
            {
                connection="server=172.16.170.165;database=MovieTickets;uid=sa;password=Passw0rd@12";
            }
        }
    }
}

