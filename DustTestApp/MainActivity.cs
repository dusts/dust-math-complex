using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;

namespace DustTestApp
{
    [Activity(Label = "DustTestApp", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            SetupMathView();
        }

        private void SetupMathView()
        {
            var doMathButton = FindViewById<AppCompatButton>(Resource.Id.doMath);
            var clearButton = FindViewById<AppCompatButton>(Resource.Id.clear);
            var realNumberField = FindViewById<AppCompatEditText>(Resource.Id.realNumber);
            var imaginaryNumberField = FindViewById<AppCompatEditText>(Resource.Id.imaginaryNumber);
            var resultAlgField = FindViewById<AppCompatEditText>(Resource.Id.resultAlgebric);
            var resultExpField = FindViewById<AppCompatEditText>(Resource.Id.resultExponentional);

            doMathButton.Click += (sender, e) =>
            {
                var realNumber = Convert.ToDouble(realNumberField.Text);
                var imaginaryNumber = Convert.ToDouble(imaginaryNumberField.Text);
                var expoFormRealPart = Math.Sqrt(realNumber * realNumber + imaginaryNumber * imaginaryNumber);
                var expoFormImaginaryPart = this.RadianToDegree(Math.Atan2(imaginaryNumber, realNumber));

                var algebricFormRealPart = realNumber * Math.Cos(DegreeToRadian(imaginaryNumber));
                var algebricFormImaginaryPart = realNumber * Math.Sin(DegreeToRadian(imaginaryNumber));

                resultAlgField.Text = $"{algebricFormRealPart}+j({algebricFormImaginaryPart})";
                resultExpField.Text = $"{expoFormRealPart}*e^j({expoFormImaginaryPart})";
            };

            clearButton.Click += (sender, e) =>
            {
                realNumberField.Text = String.Empty;
                imaginaryNumberField.Text = String.Empty;
                resultAlgField.Text = String.Empty;
                resultExpField.Text = String.Empty;
            };
        }

        private double RadianToDegree(double angle) { return angle * (180.0 / Math.PI); }

        private double DegreeToRadian(double angle) { return Math.PI * angle / 180.0; }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

