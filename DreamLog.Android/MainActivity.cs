﻿using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.App;
using Android.OS;

namespace DreamLog.Droid
{
    [Activity(Label = "DreamLog", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            this.Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            this.Window.AddFlags(WindowManagerFlags.TranslucentNavigation);
            this.Window.AddFlags(WindowManagerFlags.TranslucentStatus);

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            Xamarin.Forms.Application.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override void OnBackPressed()
        {
            if(Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed))
            {

            }
            else 
                base.OnBackPressed();
        }
    }
}