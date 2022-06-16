using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBoperationsService
{
    class DBoperations
    {

        public static Model1 dbContext = new Model1();
        private const int LEASING_TIME_IN_MONTHS = 1; 

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {

                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);


                StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }

                return sb.ToString();
            }
        }


        public static bool addUser(string login,string password)
        {

            string hashedPassword = CreateMD5(password);

            try
            {
                Users user = new Users { Login =login, Password = hashedPassword, Role = "user" };
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("System could not add user");
            }


            return false;
        }


        public static bool checkIfExistUser(string login)
        {

            var queryResult = from u in dbContext.Users where u.Login == login select u;

            try
            {
                queryResult.Single();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Such a user does not exists!");
            }

            return false;

        }

        public static int validateUserAccount(string login,string password)
        {
            string hashedPass = CreateMD5(password);

            var queryResult = from u in dbContext.Users where u.Login.Equals(login) && u.Password.Equals(hashedPass) select u;

            try 
            {
                var user = queryResult.Single();

                return user.UserID;
            }   
            catch(Exception ex)
            {
                Console.WriteLine("Such a user account does not exists!");
            }

            return -1;
        }

        public static bool updateUserAccount(string login, string password, string newPassword)
        {
            int loggedUserID = validateUserAccount(login, password);

            if(loggedUserID > -1)
            {

                string newHashedPassword = CreateMD5(newPassword);

                var userRecord = dbContext.Users.Where(u => u.UserID == loggedUserID).Select(us => us).Single();

                userRecord.Password = newHashedPassword;

                dbContext.SaveChanges();

                return true;

            }

            // such a user does not exist
            return false;
        }

        public static string getRoleOfUser(string login)
        {

            try
            {

                var userRecord = dbContext.Users.Where(u => u.Login.Equals( login)).Select(us => us).Single();

                return userRecord.Role;

            }
            catch(Exception ex)
            {
                Console.WriteLine("Such a user does not exist");
            }

            return "";
        }

        public static List<string> getListOfUsers()
        {
            List<string> listOfUsers = new List<string>();

            var users = dbContext.Users.Select(r => r);

            foreach(var user in users)
            {
                listOfUsers.Add(user.Login);
            }

            return listOfUsers;
        }


        public static int getIDOfUserLogin(string login)
        {
            try
            {
                var user = dbContext.Users.Where(u => u.Login.Equals(login)).Select(us => us).Single();

                return user.UserID;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Could not find user ID with such a login!");
            }

            return -1;
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        public static bool addBook(string title, string author, string type, long price, string currency, int numberOfPages)
        {
            
            try
            {
                Books newBook = new Books {Title = title,Author = author,Type = type,Price = price,Currency = currency,NumberOfPages = numberOfPages };

                dbContext.Books.Add(newBook);

                dbContext.SaveChanges();

                return true;

            }
            catch(Exception ex)
            {
                Console.WriteLine("Such a book exists!");
                dbContext = new Model1();   // we refresh context 
            }

            return false;

        }


        public static bool removeBook(string title, string author)
        {

            try
            {

                var bookToDelete = dbContext.Books.Where(b => b.Title.Equals(title) && b.Author.Equals( author)).Select(r => r).Single();

                dbContext.Books.Remove(bookToDelete);

                dbContext.SaveChanges();

                return true;

            }
            catch(Exception ex)
            {
                Console.WriteLine("Could not delete this book or does not exist!");
            }

            return false;
        }


        public static bool updateBook(string oldTitle, string newAuthor, string newType, long newPrice, string newCurrency, int newNumberOfPages)
        {

            try
            {

                var bookToUpdate = dbContext.Books.Where(b => b.Title.Equals(oldTitle)).Select(r => r).Single();

                bookToUpdate.Author = newAuthor;
                bookToUpdate.Type = newType;
                bookToUpdate.Price = newPrice;
                bookToUpdate.Currency = newCurrency;
                bookToUpdate.NumberOfPages = newNumberOfPages;

                dbContext.SaveChanges();

                return true;

            }
            catch(Exception ex)
            {
                Console.WriteLine("Could not update this book! Maybe it does not exist");
            }


            return false;
        }


        public static List<string> getHistoryOfUserLeases(int userID)
        {
            List<string> listOfUserLeasedBooks = new List<string>();

            try 
            {
                DateTime now = DateTime.Now;

                var leasedBooksOfUser = from us in dbContext.Users join l in dbContext.Leases on us.UserID equals l.UserID
                                        join b in dbContext.Books on l.BookID equals b.BookID
                                        where us.UserID == userID && l.LeaseEnd <= now 
                                        select new { b.Title, b.Author,b.Type,l.LeaseEnd } ;

                foreach(var leasedBook in leasedBooksOfUser)
                {

                    string record = leasedBook.Title + " ; " + leasedBook.Author + " ; " + leasedBook.Type  + " ; " + leasedBook.LeaseEnd;
                    listOfUserLeasedBooks.Add(record);

                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("Cannot get history of leased books for user!");
            }


            return listOfUserLeasedBooks;
        }


        public static List<string> getAllBooks()
        {
            List<string> listOfBooks = new List<string>();


            try
            {

                var allBooks = dbContext.Books.Select(b => b);

                foreach(var book in allBooks)
                {
                    string record = book.Title + " ; " + book.Author + " ; " + book.Type + " ; " + book.Price + " ; " + book.Currency + " ; " + book.NumberOfPages;
                    listOfBooks.Add(record);
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("Could not get all books!");
            }

            return listOfBooks;
        }

        public static List<string> getAllAvailableBooksToLease()
        {
            List<string> availableBooksToLease = new List<string>();

            var availableBooks = dbContext.Books.Where(b => b.isLeased == false).Select(book => book);

            foreach(var book in availableBooks)
            {
                string record = book.Title + " ; " + book.Author + " ; " + book.Type + " ; " + book.Price + " ; " + book.Currency + " ; " + book.NumberOfPages;
                availableBooksToLease.Add(record);
            }
                
            return availableBooksToLease;
        }


        public static bool leaseBookForUser(int userID, string title, string author)
        {

            try
            {

                var currentlyLeasingBooks = getAllCurrentlyLeasedBooksForUser(userID);

                if(currentlyLeasingBooks.Count >= 3)
                {
                    throw new Exception();
                }

                Console.WriteLine("Actually leasing books: " + currentlyLeasingBooks.Count);

            }
            catch(Exception ex)
            {
                return false;
            }

            

            try
            {

                var bookToLease = dbContext.Books.Where(b => b.Title.Equals(title) && b.Author.Equals(author) && b.isLeased == false).Select(book => book).Single();
                var user = dbContext.Users.Where(u => u.UserID == userID).Select(ur => ur).Single();

                DateTime startLeasingDate = DateTime.Now;
                DateTime endOfLeasingDate = startLeasingDate.AddMonths(LEASING_TIME_IN_MONTHS);

                // we wlll need to change this value to false, when the time of leasing is completed or user returned partiuclar book
                bookToLease.isLeased = true;

                Leases leaseOfUSer = new Leases { BookID = bookToLease.BookID, UserID = user.UserID, LeaseStart = startLeasingDate, LeaseEnd = endOfLeasingDate };
                dbContext.Leases.Add(leaseOfUSer);

                dbContext.SaveChanges();
                return true;

            }
            catch(Exception ex)
            {
                Console.WriteLine("User could not lease this book! ");
            }

            return false;
        }


        public static List<string> getAllCurrentlyLeasedBooksForUser(int userID)
        {

            List<string> currentlyLeasedBooks = new List<string>();

            try
            {
                DateTime nowDate = DateTime.Now;

                var userLeasingBooks = from b in dbContext.Books
                                       join l in dbContext.Leases
                                       on b.BookID equals l.BookID
                                       where l.LeaseStart <= nowDate && l.LeaseEnd >= nowDate && l.UserID == userID
                                       select new { b.Title, b.Author, b.Type, b.Price, b.Currency, b.NumberOfPages, l.LeaseStart, l.LeaseEnd };

                foreach(var leasingBook in userLeasingBooks)
                {
                    string record = leasingBook.Title + " ; " + leasingBook.Author + " ; " + leasingBook.Type + " ; " + leasingBook.Price + " ; " + leasingBook.Currency + " ; " + leasingBook.NumberOfPages + " ; " + leasingBook.LeaseStart + " ; " + leasingBook.LeaseEnd;
                    currentlyLeasedBooks.Add(record);
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("Could not get all currently leased books for user!");
            }

            return currentlyLeasedBooks;
        }


        public static bool returnBookForUser(int userID, string title, string author)
        {

            DateTime nowDate = DateTime.Now;

            try 
            {

                var leasingBookRecord = (from b in dbContext.Books
                                         join l in dbContext.Leases
                                            on b.BookID equals l.BookID
                                         where b.Title.Equals(title) && b.Author.Equals(author) && l.UserID == userID && l.LeaseStart <= nowDate && l.LeaseEnd >= nowDate
                                         select l).Single();

                var bookToReturn = dbContext.Books.Where(b => b.Title.Equals(title) && b.Author.Equals(author))
                                    .Select(book => book).Single();

                leasingBookRecord.LeaseEnd = nowDate;

                bookToReturn.isLeased = false;

                dbContext.SaveChanges();

                return true;

            }
            catch(Exception ex)
            {
                Console.WriteLine("Could not return book for user!");
            }

            return false;
        }

        public static bool prolongLeaseOfBookForUser(int userID, DateTime prolongedDate, string title, string author)
        {
            DateTime nowDate = DateTime.Now;

            try
            {

                var bookToProlong = (from b in dbContext.Books
                                     join l in dbContext.Leases
                                         on b.BookID equals l.BookID
                                     where b.Title.Equals(title) && b.Author.Equals(author) && l.UserID == userID && l.LeaseStart <= nowDate && l.LeaseEnd >= nowDate
                                     select l).Single();

          
                bookToProlong.LeaseEnd = prolongedDate;

                dbContext.SaveChanges();

                return true;

            }
            catch(Exception ex)
            {
                Console.WriteLine("Could not prolong lease of book for user!");
            }


            return false;
        }

        public static DateTime getLeaseEndDateOfBookForUser(int userID, string title, string author)
        {
            DateTime nowDate = DateTime.Now;

            var bookLeased = (from b in dbContext.Books
                              join l in dbContext.Leases
                                 on b.BookID equals l.BookID
                              where b.Title.Equals(title) && b.Author.Equals(author) && l.LeaseStart <= nowDate && l.LeaseEnd >= nowDate && l.UserID == userID
                              select l).Single();


            return bookLeased.LeaseEnd;
        }


    }
}
