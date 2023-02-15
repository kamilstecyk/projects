using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPC_manager
{
    class dbActionsEditPasswordsForm
    {
        static public dbModel dbContext = new dbModel();    // db context

        public static Dictionary<int,string> getAllUsers()
        {
            Dictionary<int, string> users = new Dictionary<int, string>();


            var usersFounded = from u in dbContext.Users select u;

            foreach(var record in usersFounded)
            {
                string toAdd = "userID: " + record.userID + " , " + " login: " + record.login + " , " + " password: " + record.password;
                users.Add(record.userID, toAdd);
            }

            return users;
        }

        public static void updateUserPassword(string newPassword,int userIDToChange)
        {
            var userQuery = from u in dbContext.Users where u.userID == userIDToChange select u;
            var user = userQuery.Single();

            string hashedPassword = dbActions.CreateMD5(newPassword);

            user.password = hashedPassword;

            dbContext.SaveChanges();


        }

    }
}
