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
        public string AddMovie(AddMovie movieObject)
        {
            try
            {

                Data data_object = new Data();
                data_object.MovieAdd(movieObject);
                return "Movie Added Successfully";//added the movies

            }

            catch (Exception ex)
            {
                if (ex.Message.Contains("Violation of PRIMARY KEY constraint"))
                    return "This Movie already exists";//not registered
                else          // if (ex.Message.Contains("Object reference not set to an instance of an object"))
                    return "Unable to Add Movie";
            }
            //catch
            //{
            //    return "Unable to Add Movie";//unable to add the movies
            //}

        }
        public string Validate(Login loginObject)
        {
            try
            {
                
                Data dataObject = new Data();
                string userval = dataObject.ValidateUser(loginObject);
                return userval;//validated
            }
            catch 
            {
                return "login failed";//unable to connect
            }
            
        }
        public string Register(CustomerRegistration custObj)
        {
            try
            {
                
                
                Data dataObject = new Data();
                dataObject.RegisterUser(custObj);
                return "Successfully Registered";//when data is inserted
                
            }
            catch
            {
                return "registration Failed";//unable to insert data
            }

        }
        public string UpdateSeatPrice(UpdateSeatPrice priceObj)
        {
            try
            {
                               
                Data dataObject = new Data();
                dataObject.SeatPrice(priceObj);
                return "Updated Seat Price";//updated the price

            }
            catch
            {
                return "Unable to Update Seat Price";//unable to update
            }

        }
        
        public string Forget(ForgetPassword answerObject)
        {
            try
            {
                
                Data data_object = new Data();
                string result=data_object.ForgetPass(answerObject);
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

        public string EditProfile(CustomerRegistration editObject)
        {
                          
                Data dataObject = new Data();
               string result= dataObject.EditUser(editObject);
               if (result == "edited successfully")
               {
                return "Successfully edited";//when data is edited

            }
               else
            {
                return "editing  Failed";//unable to insert data
            }

        }
        public List<Ticket> Ticket(Ticket ticket_obj)
        {
           
                //Ticket ticket_obj = new Ticket();
                //ticket_obj.userid = userid;
                //ticket_obj.bookingid = bookid;

                Data dataObject = new Data();
               List<Ticket> tickets= dataObject.TicketShow(ticket_obj);
                return (tickets);
         

        }

        public string Cancellation(cancel cancelObj)
        {
            try
            {

                Data dataObject = new Data();
                dataObject.cancellBooking(cancelObj);
                return "cancelled the booking ";//cancelled the booking

            }
            catch
            {
                return "Unable to cancell";//unable to cancell
            }

        }
        
    }
}
