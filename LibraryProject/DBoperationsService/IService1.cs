using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DBoperationsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        // operatins connected with users


        //IsOneWay=true denotes that there will no return message (or two way communication)   
        //from the server to the client.  
        [OperationContract]
        bool addUserToDB(string login, string password);

        [OperationContract]
        bool checkIfUserExists(string login);


        [OperationContract]
        int validateUserAccount(string login,string password);  // it return logged user id or -1 when log procedure failed


        [OperationContract]
        bool updateUserAccount(string login, string password,string newPassword);  // it return logged user id or -1 when log procedure failed

        [OperationContract]
        string getRoleOfUser(string login);  // it return logged user id or -1 when log procedure failed

        [OperationContract]
        List<string> getListOfUsers(); 

        [OperationContract]
        int getIDOfUserLogin(string login);   // returns -1 when userID is not founded for given login


        // opearations connected with books 

        [OperationContract]
        bool addBook(string title, string author, string type, long price, string currency, int numberOfPages);

        [OperationContract]
        bool removeBook(string title, string author);

        [OperationContract]
        bool updateBook(string oldTitle, string newAuthor,string newType,long newPrice, string newCurrency,int newNumberOfPages);

        [OperationContract]
        List<string> getHistoryOfUserLeases(int userID);

        [OperationContract]
        List<string> getAllBooks();

        [OperationContract]
        bool leaseBookForUser(int userID,string title,string author);

        [OperationContract]
        List<string> getAllAvailableBooksToLease();

        [OperationContract]
        List<string> getAllCurrentlyLeasedBooksForUser(int userID);

        [OperationContract]
        bool returnBookForUser(int userID, string title,string author);

        [OperationContract]
        bool prolongLeaseOfBookForUser(int userID, DateTime prolongedDate, string title, string author);

        [OperationContract]
        DateTime getLeaseEndDateOfBookForUser(int userID,string title, string author);  //we must be sure that we checking currenty leased book


    }


    [DataContract]
    public class CompositeType
    {
        
    }
}
