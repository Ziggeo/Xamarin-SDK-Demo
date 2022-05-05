using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using FFImageLoading.Forms.Platform;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Platform = Xamarin.Essentials.Platform;

namespace Ziggeo.Xamarin.NetStandard.Demo.Droid
{
    
    // #define TEST 
    
    [Activity(Label = "Ziggeo demo. Xamarin", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            // TabLayoutResource = Resource.Layout.Tabbar;
            // ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

// #if (DEBUG && TEST)
           // Your TestConfiguration.cs Activity
           // Intent iTestConfiguration = new Intent(this, typeof(TestConfiguration));
           // StartActivity(iTestConfiguration);
// #endif
// #if !TEST
            Platform.Init(this, savedInstanceState);
            Forms.Init(this, savedInstanceState);
            FormsMaterial.Init(this, savedInstanceState);
            CachedImageRenderer.Init(true);
            CachedImageRenderer.InitImageViewHandler();
            UserDialogs.Init(this);
            LoadApplication(new App(new ZiggeoApplication()));
// #endif
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

}