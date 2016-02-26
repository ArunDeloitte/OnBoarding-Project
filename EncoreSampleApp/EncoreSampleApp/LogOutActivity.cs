using Android.App;
using Android.Content;
using Android.OS;


namespace EncoreSampleApp
{
    [Activity(Label = "LogOutActivity")]
    public class LogOutActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.LogingOff);

            var builder = new AlertDialog.Builder(this);
            builder.SetMessage("Do you Really want to exit the application!");
            builder.SetPositiveButton("OK", (s, e) => { Process.KillProcess(Process.MyPid()); });
            builder.SetNegativeButton("Cancel", (s, e) =>
            {
                var intent = new Intent(this, typeof(WelcomeScreenActivity));
                StartActivity(intent);
            });
            builder.Create().Show();
            

        }


        
    }
}