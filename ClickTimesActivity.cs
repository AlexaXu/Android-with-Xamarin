using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App2
{
    [Activity(Label = "ClickTimesActivity")]
    public class ClickTimesActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ClickTimes);

            var backButton = FindViewById<Button>(Resource.Id.BackButton);
            var label = FindViewById<TextView>(Resource.Id.ShowLabel);

            int count = Intent.GetIntExtra("Click Times", 0);

            label.Text = $"You clicked {count} times";

            backButton.Click += delegate
            {
                var intent = new Intent(this, typeof(MainActivity));
                intent.PutExtra("Click Times", count);
                StartActivity(intent);
            };
        }
    }
}