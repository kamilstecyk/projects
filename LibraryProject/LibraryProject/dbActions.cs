using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using LibraryProject.DBoperationsServiceReference;

namespace LibraryProject
{
    class dbActions
    {
        static private int loggedUserID = -1;

        private static Service1Client client;

  


        static public int getLoggedUserID()
        {

            return loggedUserID;
        }

        static private void setLoggedUserID(int userID)
        {
            dbActions.loggedUserID = userID;
        }

        
        public static string getUserRole(string login)
        {
            client = new Service1Client();

            string userRole = client.getRoleOfUser(login);

            Console.WriteLine(userRole + " - response from microservice");

            client.Close();

            return userRole;
        }


        public static bool logIn(string login, string password)
        {

            client = new Service1Client();

            int IDuserWhoLogged = client.validateUserAccount(login, password);

            setLoggedUserID(IDuserWhoLogged);
           

            Console.WriteLine(loggedUserID + " - response from microservice");

            client.Close();


            if(IDuserWhoLogged > -1)
            {
                return true;
            }

            return false;

        }



        public static bool updateUser(string login, string password,string newPassword)
        {

            client = new Service1Client();

            bool response = client.updateUserAccount(login, password, newPassword);

            Console.WriteLine(response + " - response from microservice");

            client.Close();


            return response;
        }



        public static bool addUser(string login, string password)
        {

            client = new Service1Client();

            bool response = client.addUserToDB(login, password);

            Console.WriteLine(response + " - response from microservice");

            client.Close();

            return response;
        }

        public static int getUserIDForLogin(string login)
        {
            client = new Service1Client();

            int userID = client.getIDOfUserLogin(login);

            Console.WriteLine(userID + " - response from microservice");

            client.Close();

            return userID;
        }

    }
}
