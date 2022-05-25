using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace RPC_manager
{
    // actions connected with login, registering and remembering password, first forms

    class dbActions
    {

        // we must have login and password columns
        static public dbModel dbContext = new dbModel();    // db context
        static public DbSet<Users> table = dbContext.Users;  // our table in db to perform operations connected with user


        // yet is hardcoded to test our app
        static private int loggedUserID = 14;  // if we are not logged then we return -1


        public static void  setLoggedUser(int userID)
        {
            loggedUserID = userID;
        }

        public static int getLoggedUser()
        {
            return loggedUserID;
        }
 
        public static string getRoleOfLoggedUser()
        {
            var user = from u in dbContext.Users where u.userID == loggedUserID select u;
            var userFounded = user.Single();

            return userFounded.role;
        }
        // here we declare admin account manually with specific credentials
        public static bool addAdmin()
        {
            string login = "adminAccount";
            string password = "adminPassword";
            string hashedPassword = CreateMD5(password);
            string adminRole = "admin";

            // we check if such an admin exists

            try
            {
                var result = dbContext.Users.Where(u => u.login == login && u.password == hashedPassword && u.role.Equals(adminRole)).Select(us => us.userID).Single();
                return false;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Admin does not exists in the table");
            }


            dbContext.Users.Add(new Users() { login = login, password = hashedPassword ,role = adminRole});
            dbContext.SaveChanges();


            return true;
        }

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





        static public bool checkIfUserExists(string login)
        {

            

            var query = from u in table where (u.login == login ) select u;  // we select row 

            var foundedUser = query.FirstOrDefault();


            if (foundedUser != null)
                {
                    Console.WriteLine("User was founded in procedure..");
                    return true;
                }
                
            Console.WriteLine("User was not founded in procedure..");



            return false;

        }


        static public bool logIn(string login, string password)
        {
            string hashedPass = CreateMD5(password);

           
            try
            {

                var result = table.Single(b => b.login == login && b.password == hashedPass);

                var foundedUserID = result.userID;

                setLoggedUser(foundedUserID);
                return true;

            }
            catch(Exception ex)
            {
                Console.WriteLine("Error with login dbActions");
            }

            return false;

        }


        // this method return false if we have such user in db
        public static bool addUser(string newLogin,string newPassword)
        {


            bool response = checkIfUserExists(newLogin);


            if (response)
            {
                return false;

            }
           
            var newUser = new Users { login = newLogin, password = CreateMD5(newPassword) };  // we hash pass
            table.Add(newUser);
            dbContext.SaveChanges();


            return true;  // everything done successfully
            

        }


        public static bool updateUser(string userLogin,string userPassword,string newPassword)
        {
            string hashedPass = CreateMD5(userPassword);

            var result = table.SingleOrDefault(b => b.login == userLogin && b.password == hashedPass);

            if(result != null )   
            {

                result.password = CreateMD5(newPassword);  // we change password
                dbContext.SaveChanges();
                return true;
            }


            return false; // these means we do not have such a user with particular credentials


        }


    }
}
