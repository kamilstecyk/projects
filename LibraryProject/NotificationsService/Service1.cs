using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NotificationsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {

        NotificationsContext dbContext = new NotificationsContext();
        const int daysBeforeEndLeaseToRemind = 5;

        public string getNotificationAboutLeasedBook(int userID)
        {
            try
            {
                DateTime todayDate = DateTime.Now;


                //&& (l.LeaseEnd - todayDate).Days <= daysBeforeEndLeaseToRemind

                var booksOfUserToReturn = from l in dbContext.Leases
                                           join
                                            b in dbContext.Books
                                            on l.BookID equals b.BookID
                                           where l.UserID == userID && l.LeaseStart <= todayDate && ((l.LeaseEnd - todayDate).Days <=  daysBeforeEndLeaseToRemind)
                                           select b;


                    
                StringBuilder booksToReturnBuffer = new StringBuilder();

                foreach (var book in booksOfUserToReturn)
                {
                    booksToReturnBuffer.Append(book.Title + ",");
                }


                string booksToReturn = booksToReturnBuffer.ToString().Remove(booksToReturnBuffer.Length - 1);  // we remove last "," in the string

                string result = "You have to return books: " + booksToReturn + " !";


                return result;

            }
            catch(Exception ex)
            {
                Console.WriteLine("Could not found user with such an id!");
            }

            return "";

        }

    }
}
