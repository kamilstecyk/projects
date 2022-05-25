﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPC_manager
{
    class RegistrationLogic
    {
        public static RegistrationForm regForm = null;

        RegistrationLogic(RegistrationForm formPassed)
        {
            regForm = formPassed;
        }


        static  public bool checkIfPasswordMatches(string pass1,string pass2)
        {
            return pass1.Equals(pass2);
        }


        static public bool register(string login,string pass)
        {
            if (!dbActions.addUser(login,pass))  // user exists
            {
                return false;
            }

            return true;
        }

    }
}
