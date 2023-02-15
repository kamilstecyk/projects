using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryProject.CurrencyExchangeServiceReference;

namespace LibraryProject
{
    class CurrencyExchangeOperations
    {
        private static Service1Client client;

        public static double getPriceInPLN(string currencySymbol, double howManyCurrency)
        {
            client = new Service1Client();

            double newPrice = client.SellValue(currencySymbol, howManyCurrency);

            client.Close();

            return newPrice;

        }

        public static string[] getAllAvailableCurrencies()
        {
            client = new Service1Client();

            string[] availableCurrencies = client.getAllAvailableCurrencies();

            client.Close();

            return availableCurrencies;
        }
    }
}
