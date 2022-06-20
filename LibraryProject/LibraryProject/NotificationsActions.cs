using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryProject.NotificationsServiceReference;


namespace LibraryProject
{
    class NotificationsActions
    {
        static private Service1Client client;
       
        public static string getNotificationsAboutEndingLeasingOfBooks(int userID)
        {
            client = new Service1Client();

            string notification = client.getNotificationAboutLeasedBook(userID);

            client.Close();

            return notification;
        }
            
    }
}
