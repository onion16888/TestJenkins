﻿using Android.App;
using Android.Widget;
using Android.OS;

namespace TestJenkins.Droid
{
	[Activity(Label = "TestJenkins", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button>(Resource.Id.myButton);
			TextView text1 = FindViewById<TextView>(Resource.Id.textView1);
			button.Click += delegate { 
				button.Text = string.Format("{0} clicks!", count);
				text1.Text = string.Format("{0} clicks!", count);
				count++;
			};
		}
	}
}


