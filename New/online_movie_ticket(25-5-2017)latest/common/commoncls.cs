using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common
{
    public class commoncls
    {
        public readonly string login_proc = "loginproc @user,@pawd";

        public readonly string register_proc = "insertproc @name,@mob,@user,@pawd,@ans";

        public readonly string price_proc = "priceproc @type,@price";

        public readonly string addmovie_proc = "addproc @sid,@mname,@sdate,@stime,@etime";

        public readonly string forgetpassword_proc = "forgotproc @user,@ans";
    }
}

