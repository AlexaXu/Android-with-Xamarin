using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Widget;
using Android.OS;

namespace App2
{

    [Activity(Label = "Click App", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            if (bundle != null)
            {
                count = bundle.GetInt("count");
            }

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            Button clickButton = FindViewById<Button>(Resource.Id.ClickButton);
            Button showButton = FindViewById<Button>(Resource.Id.ShowButton);

            //var label = FindViewById<TextView>(Resource.Id.textView1);
            //label.Text = $"You clicked {count} times";

            count = Intent.GetIntExtra("Click Times", 0);

            clickButton.Click += delegate
            {
                count++;
                //label.Text = $"You clicked {count} times";
            };

            showButton.Click += delegate
            {
                Intent intent = new Intent(this, typeof(ClickTimesActivity));
                intent.PutExtra("Click Times", count);
                StartActivity(intent);
            };
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutInt("count", count);
            base.OnSaveInstanceState(outState);
        }

        /*protected override void OnRestoreInstanceState(Bundle savedInstanceState)
        {
            base.OnRestoreInstanceState(savedInstanceState);

            count = savedInstanceState.GetInt("count");
        }*/
    }

    
}