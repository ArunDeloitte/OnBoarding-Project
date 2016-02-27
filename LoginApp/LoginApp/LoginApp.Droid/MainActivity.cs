using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using LoginApp;


namespace LoginApp.Droid
{
	[Activity (Label = "LoginApp.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;
        MyClass myObj = new MyClass();
        MySqLite SqObj = new MySqLite();
         List<string> dbase= new List<string>();
         string _username, _Password;
        


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Login);

			// Get our button from the layout resource,
			// and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.buttonSubmit);
            EditText Username = FindViewById<EditText>(Resource.Id.editUserName);
            EditText Password = FindViewById<EditText>(Resource.Id.editPassword);
            TextView Result = FindViewById<TextView>(Resource.Id.textResult);
            EditText eResult = FindViewById<EditText>(Resource.Id.editResult); 
			
			button.Click += delegate {
				button.Text = string.Format ("{0} clicks!", count++);

               //Result.Text= myObj.LoginValidator(Username.Text,Password.Text);
               dbase=SqObj.DoSomeDataAccess();
               foreach (var item in dbase)
               {
                   if (item.Contains("Username") & item.Contains("Password"))
                   {
                       _username =item.Substring(item.IndexOf("Username="), item.LastIndexOf(";") - item.IndexOf("Username="));
                       _username = _username.Substring(_username.IndexOf("=")+1);

                       _Password = item.Substring(item.LastIndexOf("=")+1);
                       //_Password = _Password.Substring(_Password.IndexOf("=")+1);

                       if(Username.Text.Equals(_username) & Password.Text.Equals(_Password))
                       {
                           Result.Text="Login Success :-)";
                           break;
                       }
                       else 
                       {
                           Result.Text = "Login Failed!!";
                       }
                   }
               }
              
			};
		}
	}
}


