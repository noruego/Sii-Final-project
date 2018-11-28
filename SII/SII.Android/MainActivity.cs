using System;

using Android.App;
using Android.Content.PM;
using Android.OS;

namespace SII.Droid
{
    [Activity(Label = "SII", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        internal static MainActivity Instance { get; private set; }
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;


            Rg.Plugins.Popup.Popup.Init(this, bundle);

            base.OnCreate(bundle);

            Instance = this;
            global::Xamarin.Forms.Forms.Init(this, bundle);
            try
            {
                LoadApplication(new App());
            }
            catch (Java.Lang.Exception ex)
            {

            }
            catch (System.Exception ex)
            {

            }
        }
        
    }
}

