﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLayer;
using BusinessEntities;

namespace OnlineMovie.Controllers
{
    public class UpdatePriceController : Controller
    {
        //
        // GET: /updateprice/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string type,string priceval)
        {
            type = Request["type"];
            priceval = Request["price"];
            int price =int.Parse(priceval);
            UpdateSeatPrice priceobj = new UpdateSeatPrice();
            priceobj.type = type;
            priceobj.price = price;

            Layer ob = new Layer();
            string result = ob.UpdateSeatPrice(priceobj);
            if (result == "Updated Seat Price")
            {

                ViewBag.Message_For_Seat_UpdatePrice = "updated the price";
                return View();
                
            }
            else
            {
                ViewBag.Message_For_Seat_UpdatePrice = "unable to update";
                return View();

            }

        }
            
        }

}    


