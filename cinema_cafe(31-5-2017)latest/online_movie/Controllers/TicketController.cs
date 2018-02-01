using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using Common;
using BusinessEntities;
using BussinessLayer;

namespace OnlineMovie.Controllers
{
    public class TicketController : Controller
    {
        Commoncls com = new Commoncls();

        public ActionResult Index()
        {
            string str1 = Session["suserid"].ToString();
            string str2 = Session["bookid"].ToString();
            Ticket ticket_obj = new Ticket();
            ticket_obj.userid = str1;
            ticket_obj.bookingid = str2;
            Layer ticketObj=new Layer();
            List<Ticket> li = new List<Ticket>();
            li = ticketObj.Ticket(ticket_obj);
            

            return View(li);

        }
         
        }

    }

