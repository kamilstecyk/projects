using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DBoperationsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {

        // service connected with users

        public bool addUserToDB(string login, string password)
        {
            return DBoperations.addUser(login, password); 
        }

        public bool checkIfUserExists(string login)
        {
            return DBoperations.checkIfExistUser(login);
        }

        public string getRoleOfUser(string login)
        {
            return DBoperations.getRoleOfUser(login);
        }

        public bool updateUserAccount(string login, string password, string newPassword)
        {
            return DBoperations.updateUserAccount(login, password, newPassword);
        }

        public int validateUserAccount(string login,string password)
        {
            return DBoperations.validateUserAccount(login, password);
        }



        public List<string> getListOfUsers()
        {
            return DBoperations.getListOfUsers();
        }

        public int getIDOfUserLogin(string login)
        {
            return DBoperations.getIDOfUserLogin(login);
        }


        // service connected with books

        public bool addBook( string title, string author, string type, long price, string currency, int numberOfPages)
        {
            return DBoperations.addBook(title, author, type, price, currency, numberOfPages);
        }


        public bool removeBook(string title, string author)
        {
            return DBoperations.removeBook(title, author);
        }

        public bool updateBook(string oldTitle, string newAuthor, string newType, long newPrice, string newCurrency, int newNumberOfPages)
        {
            return DBoperations.updateBook(oldTitle, newAuthor, newType, newPrice, newCurrency, newNumberOfPages);
        }

        public List<string> getHistoryOfUserLeases(int userID)
        {
            return DBoperations.getHistoryOfUserLeases(userID);
        }

        
        public List<string> getAllBooks()
        {
            return DBoperations.getAllBooks();
        }

        public bool leaseBookForUser(int userID, string title, string author)
        {
            return DBoperations.leaseBookForUser(userID, title, author);
        }

        public List<string> getAllAvailableBooksToLease()
        {
            return DBoperations.getAllAvailableBooksToLease();
        }


        public List<string> getAllCurrentlyLeasedBooksForUser(int userID)
        {
            return DBoperations.getAllCurrentlyLeasedBooksForUser(userID);
        }

        public bool returnBookForUser(int userID, string title, string author)
        {
            return DBoperations.returnBookForUser(userID, title, author);
        }

        public bool prolongLeaseOfBookForUser(int userID, DateTime prolongedDate, string title, string author)
        {
            return DBoperations.prolongLeaseOfBookForUser(userID, prolongedDate, title, author);
        }

        public DateTime getLeaseEndDateOfBookForUser(int userID, string title, string author)
        {
            return DBoperations.getLeaseEndDateOfBookForUser(userID, title, author);
        }



    }
}
