using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;


namespace DatabaseMicroServiceHost
{
    [ServiceContract]
    public interface IDBoperations
    {
        //IsOneWay=true denotes that there will no return message (or two way communication)   
        //from the server to the client.  
        [OperationContract]
        bool addUserToDB(string login, string password);
    }
}
