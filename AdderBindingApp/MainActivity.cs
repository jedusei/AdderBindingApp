using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Com.Example.Adder;
using System;

namespace AdderBindingApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState); 
            SetContentView(Resource.Layout.activity_main);

            var textView = FindViewById<TextView>(Resource.Id.textView);
            textView.Text = GetAdderResult();
        }

        public override void  OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

             base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        /// <summary>
        /// When built with Minimum Android Version >= API 24, the call to Adder.Add is successful and "1 + 2 = 3" is shown on the screen.
        /// When Minimum Android Version < API 24, Adder.Add throws a Java.Lang.NoSuchMethodException.
        /// </summary>
        private string GetAdderResult()
        {
            try
            {
                int a = 1;
                int b = 2;
                int result = Adder.Add(1, 2);
                return $"{a} + {b} = {result}";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}