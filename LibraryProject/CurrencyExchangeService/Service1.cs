using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CurrencyExchangeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {

        private static string[] currencies = new string[] {"PLN", "EUR", "USD", "CHF", "GBP" }; 

        public double SellValue(string currencySymbol, double howManyCurrency) // return value in pln
        {
            double rate = 0;

            if (currencySymbol.ToUpper().Equals("EUR"))
            {
                rate = 4.5908;

            }
            else if (currencySymbol.ToUpper().Equals("USD"))
            {
                rate = 4.2689;

            }
            else if (currencySymbol.ToUpper().Equals("CHF"))
            {
                rate = 4.4547;
            }
            else if (currencySymbol.ToUpper().Equals("GBP"))
            {
                rate = 5.3681;

            }


            // our CurrencyExchange does not handle pointed currency
            if (rate == 0)
            {
                throw new FaultException("Error");
            }


            return howManyCurrency * rate;

        }

        public double ShowExchangeRate(string currencySymbol)  // return value in PLN
        {
            double rate = 0;

            if (currencySymbol.ToUpper().Equals("EUR"))
            {
                rate = 4.5908;

            }
            else if (currencySymbol.ToUpper().Equals("USD"))
            {
                rate = 4.2689;

            }
            else if (currencySymbol.ToUpper().Equals("CHF"))
            {
                rate = 4.4547;
            }
            else if (currencySymbol.ToUpper().Equals("GBP"))
            {
                rate = 5.3681;

            }


            // our CurrencyExchange does not handle pointed currency
            if (rate == 0)
            {
                //throw new FaultException<MyServiceFault>(new MyServiceFault("We do not have such a currency!"));
                throw new FaultException("Error");
            }


            return rate;

        }

        public string[] getAllAvailableCurrencies()
        {
            return currencies;
        }


    }
}
