using System;

using Xamarin.Forms;

namespace FormsTestApp
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = false;
        public static Ziggeo.ZiggeoApplication ZiggeoApplication = new Ziggeo.ZiggeoApplication("4f0190ef04f6c877daae7e8aa20d54c6");

        public App()
        {
            InitializeComponent();

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
