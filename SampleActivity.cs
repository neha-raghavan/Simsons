using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Simsons
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
  
    public class SampleActivity : AppCompatActivity
    {
     
       
            protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);

                    
                SetContentView(Resource.Layout.layout1);
            }
        
    }
}