using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Objects;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;


namespace DBFilteringService
{
    class FilteringOperations
    {
        static private LibraryDBContext dBContext = new LibraryDBContext();

        public static Expression<Func<Books, bool>> checkWhetherWasWrittenByGivenAuthor(string author)
        {
            var predicate = PredicateBuilder.False<Books>();

            predicate = predicate.Or(p => p.Author.Equals(author));

            return predicate;
        }

        public static Expression<Func<Books, bool>> checkWhetherIsGivenType(string type)
        {
            var predicate = PredicateBuilder.False<Books>();

            predicate = predicate.Or(p => p.Type.Equals(type));

            return predicate;
        }

        public static Expression<Func<Books, bool>> checkWhetherIsInPriceRange(long fromPrice,long toPrice)
        {
            var predicate = PredicateBuilder.False<Books>();

            predicate = predicate.Or(p => p.Price >= fromPrice && p.Price <= toPrice);

            return predicate;
        }


        public static Expression<Func<Books, bool>> checkWhetherIsInGivenCurrency(string currency)
        {
            var predicate = PredicateBuilder.False<Books>();

            predicate = predicate.Or(p => p.Currency.Equals(currency));

            return predicate;
        }



        public static List<string> getAllFilteredBooks(string author, string type, long fromPrice, long toPrice, string currency)
        {
            var query = dBContext.Books.Select(b => b);

            List<string> filteredBooks = new List<string>();
            
            if(author.Length >  0)
            {
                // query = (DbSet<Books>) query.Where(checkWhetherWasWrittenByGivenAuthor(author));
                query =  query.Where(b => b.Author.Equals(author));
            }
            
            if(type.Length != 0)
            {
                query =  query.Where(b => b.Type.Equals(type));
            }
            
            if(fromPrice >= 0 && toPrice >= 0)
            {
                query =  query.Where(b => b.Price >= fromPrice && b.Price <= toPrice);
            }

            if(currency.Length > 0)
            {
                query =  query.Where(b => b.Currency.Equals(currency));
            }

     

            foreach(var book in query)
            {
                string record = book.Title + " ; " + book.Author + " ; " + book.Type + " ; " + book.Price + " ; " + book.Currency + " ; " + book.NumberOfPages;
                filteredBooks.Add(record);
            }

            return filteredBooks;
        }




        public static List<string> getAllTypesOfBooks()
        {

            var bookTypes = dBContext.Books.Select(b => b.Type); 

            return bookTypes.Distinct().ToList();
        }

        public static List<string> getAllAuthorOfBooks()
        {
            var bookAuthors = dBContext.Books.Select(b => b.Author);

            return bookAuthors.Distinct().ToList();
        }

        public static List<string> getAllCurrencies()
        {
            var currencies = dBContext.Books.Select(b => b.Currency);

            return currencies.Distinct().ToList();
        }


    }
}
