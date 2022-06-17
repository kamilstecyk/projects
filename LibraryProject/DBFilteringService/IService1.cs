using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DBFilteringService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<string> getAllFilteredBooks(string author, string type, long fromPrice, long toPrice, string currency);

        [OperationContract]
        List<string> getAllTypesOfBooks();

        [OperationContract]
        List<string> getAllAuthorOfBooks();

        [OperationContract]
        List<string> getAllCurrencies();

    }


    public class CompositeType
    {
    }
}
