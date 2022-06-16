using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryProject.DBoperationsServiceReference;

namespace LibraryProject
{
    class dbActionsBooks
    {

        private static Service1Client client;

        public static bool addBook( string title, string author, string type, long price, string currency, int numberOfPages)
        {

            client = new Service1Client();

            bool response = client.addBook(title, author, type, price, currency, numberOfPages);

            client.Close();

            return response;
        }

        public static string[] getAllBooks()
        {
            client = new Service1Client();

            string[] books = client.getAllBooks();

            client.Close();

            return books;
        }


        public static bool  removeBook(string title, string author)
        {
            client = new Service1Client();

            bool response = client.removeBook(title, author);

            client.Close();

            return response;
        }

        public static bool updateBook(string oldTitle, string newAuthor, string newType, long newPrice, string newCurrency, int newNumberOfPages)
        {
            client = new Service1Client();

            bool response = client.updateBook(oldTitle, newAuthor, newType, newPrice, newCurrency, newNumberOfPages);

            client.Close();

            return response;
        }

        public static string[] getAllUsers()
        {
            client = new Service1Client();

           var users = client.getListOfUsers();

            client.Close();

            return users;
        }

        public static string[] getUserHistoryOfBooks(int userID)
        {
            client = new Service1Client();

            var userHistoryOfBooks = client.getHistoryOfUserLeases(userID);

            client.Close();

            return userHistoryOfBooks;
        }


        public static string[] getAllAvailableBooksToLease()
        {
            client = new Service1Client();

            var availableBooksToLease = client.getAllAvailableBooksToLease();

            client.Close();

            return availableBooksToLease;
        }

        public static bool leaseBookForUser(int userID,string title,string author)
        {
            client = new Service1Client();

            bool response = client.leaseBookForUser(userID, title, author);

            client.Close();

            return response;
        }

        public static string[] getAllCurrentlyLeasingBooksForUser(int userID)
        {
            client = new Service1Client();

            var currenlyLeasingBooks = client.getAllCurrentlyLeasedBooksForUser(userID);

            client.Close();

            return currenlyLeasingBooks;
        }

        public static bool returnBookForUser(int userID, string title, string author)
        {
            client = new Service1Client();

            bool response = client.returnBookForUser(userID, title, author);

            client.Close();

            return response;
        }

        public static DateTime getLeaseEndDateOfLeasedBookForUser(int userID, string title, string author)
        {
            client = new Service1Client();

            DateTime leaseEndDate = client.getLeaseEndDateOfBookForUser(userID, title, author);
            client.Close();

            return leaseEndDate;
        }

        public static bool prolongLeaseOfBookForUser(int userID, DateTime prolongedDate, string title, string author)
        {
            client = new Service1Client();

            bool response = client.prolongLeaseOfBookForUser(userID, prolongedDate, title, author);

            client.Close();

            return response;
        }


    }
}
