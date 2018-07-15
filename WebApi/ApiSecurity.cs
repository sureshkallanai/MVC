using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi
{
    public class ApiSecurity
    {
        public static bool VaidateUser(string username, string password)
        {
            // Check if it is valid credential  
           // if (true)//CheckUserInDB(username, password))  
           if(username=="suresh"&&password=="password")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
    }
}