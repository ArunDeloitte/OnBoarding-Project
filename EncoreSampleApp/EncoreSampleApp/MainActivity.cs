using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;

namespace EncoreSampleApp
{
    [Activity(Label = "EncoreSampleApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.btnLogin);
            

            // Get out EditText fields and compare values with the username and password
            EditText username = FindViewById<EditText>(Resource.Id.editEmailID);
            EditText password = FindViewById<EditText>(Resource.Id.editPasword);

            button.Click += delegate {

                if (username.Text.Equals("Encoress@gmail.com", StringComparison.OrdinalIgnoreCase) & password.Text.Equals("Password01"))
                {
                    //Intiating the activity for the second screen
                    Toast.MakeText(this, "Login Successful...", ToastLength.Short);
                    var intent = new Intent(this, typeof(WelcomeScreenActivity));
                    StartActivity(intent);
                }

                else
                {
                    username.Text = "";
                    password.Text = "";
                    Toast.MakeText(this, "Invalid Credentials!!! Please Try Again.", ToastLength.Short);

                }
            };

            
        }
    }
}

