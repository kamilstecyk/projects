using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryProject.DBFilteringServiceReference;

namespace LibraryProject
{
    class FilteringBooksActions
    {
        private static Service1Client client;

        public static string[] getFilteredBooksFromDB(string author, string type, long fromPrice, long toPrice, string currency)
        {
            client = new Service1Client();

            string[] filteredBooks = client.getAllFilteredBooks(author, type, fromPrice, toPrice, currency);

            client.Close();

            return filteredBooks;
        }


        public static string[] getAllAuthorsOfBooks()
        {
            client = new Service1Client();

            string[] authors = client.getAllAuthorOfBooks();

            client.Close();

            return authors ;
        }

        public static string[] getAllTypesOfBooks()
        {
            client = new Service1Client();

            string[] types = client.getAllTypesOfBooks();

            client.Close();

            return types;
        }

        public static string[] getAllCurrenciesOfBooks()
        {
            client = new Service1Client();

            string[] currencies = client.getAllCurrencies();

            client.Close();

            return currencies;
        }

    }
}
