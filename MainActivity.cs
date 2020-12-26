using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.Design.Widget;
using System;
using System.Data.SqlClient;
using Org.Json;
using System.Text;
using System.Net.Http;
namespace Simsons
{
    
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText Name;
        EditText Place;
        EditText UserName;
        EditText Password;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            Name = FindViewById<EditText>(Resource.Id.txtName);
            Place = FindViewById<EditText>(Resource.Id.txtPlace);
            UserName = FindViewById<EditText>(Resource.Id.txtUserName);
            Password = FindViewById<EditText>(Resource.Id.txtPassword);
            var button = FindViewById<Button>(Resource.Id.btnSignUp);
            button.Click += DoRegister;
        }
        public async void  DoRegister (object sender, EventArgs e)
        {
            HttpClient client;
            client = new HttpClient();
            Console.WriteLine(Name.Text);
            JSONObject json = new JSONObject();
            json.Put("Name", Name.Text);
            json.Put("Place", Place.Text);
            json.Put("UserName", UserName.Text);
            json.Put("Password", Password.Text);
            Console.WriteLine(json.ToString());

            Uri uri = new Uri(string.Format("http://192.168.1.7:5001/api/Person"));

  //string json = JsonConvert.SerializeObject(item);
            StringContent content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            
                response = await client.PostAsync(uri, content);
 
  if (response.IsSuccessStatusCode)
            {

                var context = Android.App.Application.Context;
                var tostMessage = "user registered successfully";
                var durtion = ToastLength.Long;


                Toast.MakeText(context, tostMessage, durtion).Show();
                StartActivity(typeof(SampleActivity));


            }


        }
        
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}