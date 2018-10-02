using System;

using Xamarin.Forms;

namespace FormsTestApp
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = false;
        public static Ziggeo.ZiggeoApplication ZiggeoApplication = new Ziggeo.ZiggeoApplication("ZIGGEO_APP_TOKEN");

        public App()
        {
            InitializeComponent();

            //ZiggeoApplication.ServerAuthToken = "SERVER_AUTH_TOKEN";
            //ZiggeoApplication.ClientAuthToken = "CLIENT_AUTH_TOKEN";

            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<CloudDataStore>();

            if (Device.RuntimePlatform == Device.iOS)
                MainPage = new MainPage();
            else
                MainPage = new NavigationPage(new MainPage());
        }
    }
}
