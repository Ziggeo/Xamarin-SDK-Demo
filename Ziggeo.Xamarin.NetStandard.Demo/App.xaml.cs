using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using Ziggeo;
using Ziggeo.Xamarin.NetStandard.Demo.Services;
using Ziggeo.Xamarin.NetStandard.Demo.Utils;
using Ziggeo.Xamarin.NetStandard.Demo.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Ziggeo.Xamarin.NetStandard.Demo
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = false;
        public static IZiggeoApplication ZiggeoApplication;
        public static EventLogger EventLogger;

        public App()
        {
            InitializeComponent();
        }

        public App(IZiggeoApplication instance)
        {
            InitializeComponent();
            EventLogger = new EventLogger();
            ZiggeoApplication = instance;
            if (IsLoggedIn())
            {
                ZiggeoApplication.AppToken = Preferences.Get(Constants.KeyAppToken, null);
            }

            //ZiggeoApplication.ServerAuthToken = "SERVER_AUTH_TOKEN";
            //ZiggeoApplication.ClientAuthToken = "CLIENT_AUTH_TOKEN";
            ZiggeoApplication.Videos.UploadStarted += (string filePath) =>
            {
                //upload started
                Console.WriteLine("upload started from {0}", filePath);
            };

            ZiggeoApplication.Videos.UploadProgressChanged +=
                (string token, string filename, long bytesSent, long totalBytes) =>
                {
                    //update progress    
                    Console.WriteLine("upload progress changed for {2}: {0}/{1}", bytesSent, totalBytes, token);
                };

            ZiggeoApplication.Videos.UploadComplete += (string token, string filename) =>
            {
                //done
                Console.WriteLine("{0} upload done with token {1}", filename, token);
            };

            ZiggeoApplication.Videos.UploadFailed += (string filename, Exception error) =>
            {
                //handle error
                Console.WriteLine("{0} upload failed with error {1}", filename, error.ToString());
            };

            DependencyService.Register<InfoService>();
            if (UseMockDataStore)
                DependencyService.Register<MockVideosService>();
            else
                DependencyService.Register<CloudVideosService>();


            Page page = IsLoggedIn() ? (Page) new AuthPage() : new MainPage();

            if (Device.RuntimePlatform == Device.iOS)
                MainPage = page;
            else
                MainPage = new NavigationPage(page);
        }

        public bool IsLoggedIn()
        {
            return String.IsNullOrEmpty(Preferences.Get(Constants.KeyAppToken, null));
        }
    }
}