using System;



namespace LoginApp
{
    public class MyClass
    {
        string returnstring = "Login Failed";
       
        public MyClass()
        {
        }

        public string LoginValidator(string username, string password)
        {
            if (username.Equals("aniruth.sabapathy@gmail.com") & password.Equals("Pa22w0rd"))
            {
                returnstring = "success";
            }

            return returnstring;
        }

        
    }
}

