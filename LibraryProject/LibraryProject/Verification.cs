using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace LibraryProject
{
    class Verification
    {
        public static bool verifyPassword(string input)
        {
            string regexp = "^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{8,32}$";

            return Regex.IsMatch(input, regexp);

        }

        public static bool verifyLogin(string input)
        {
            if (!input.Contains(" ") && input.Length >= 5)
            {
                return true;
            }

            return false;
        }

    }
}
