using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DBFilteringService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public  List<string> getAllFilteredBooks(string author, string type, long fromPrice, long toPrice, string currency)
        {
            return FilteringOperations.getAllFilteredBooks(author, type, fromPrice, toPrice, currency);
        }

        public List<string> getAllTypesOfBooks()
        {
            return FilteringOperations.getAllTypesOfBooks();
        }

        public List<string> getAllAuthorOfBooks()
        {
            return FilteringOperations.getAllAuthorOfBooks();
        }

        public List<string> getAllCurrencies()
        {
            return FilteringOperations.getAllCurrencies();
        }

    }
}
