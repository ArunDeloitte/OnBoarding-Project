using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace EncoreSampleApp
{
    [Activity(Label = "WelcomeScreenActivity")]
    public class WelcomeScreenActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.WelcomeScreen);
            // Create your application here


            // Get our button from the layout resource,
            // and attach an event to it
            Button logOff = FindViewById<Button>(Resource.Id.btnLogoff);
            TextView txtWelcome = FindViewById<TextView>(Resource.Id.editWelcome);
            //txtWelcome.Enabled = false;
            txtWelcome.Focusable = false;


            logOff.Click += delegate {

                var intent = new Intent(this, typeof(LogOutActivity));
                StartActivity(intent);
            };
        }

        public override void OnBackPressed()
        {
            Toast.MakeText(this, "Please re-login  ", ToastLength.Short);
        }

    }


}