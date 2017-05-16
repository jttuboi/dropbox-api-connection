using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using DropboxApiConnection;
using System.Text;
using System.IO;

namespace DropboxApiConnection.Droid
{
	[Activity (Label = "DropboxApiConnection.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        Button myButton;
        Button button1;
        Button button2;
        TextView textView;
        
        DropboxService service;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);
            
            service = new DropboxService();

            myButton = FindViewById<Button>(Resource.Id.myButton);
            myButton.Click += Button_Click;
            button1 = FindViewById<Button>(Resource.Id.button1);
            button1.Click += Button1_Click;
            button2 = FindViewById<Button>(Resource.Id.button2);
            button2.Click += Button2_Click;
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            myButton.Text = await service.GetCurrentAccountAsync();
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            textView = FindViewById<TextView>(Resource.Id.textView1);
            textView.Text = await service.GetFile();
        }

        private async void Button2_Click(object sender, EventArgs e)
        {
            await service.SetFile();
        }
    }
}


