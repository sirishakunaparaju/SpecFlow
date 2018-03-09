using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonSpecflow.Utils
{
    class CreateAccountElements
    {
        //Elements
        public static string Name = "customerName";
        public static string Email = "email";
        public static string Password = "password";
        public static string ReEnterPassword = "passwordCheck";
        public static string CreateAccount = " //input[@id='continue']";


        //Data
        public static string strName = "testAmazon";
        public static string strEmail = "test@gmail.com";
        public static string strPassword = "Test@123";
        public static string strReEnterPassword = "Test@123";
       
    }
}
