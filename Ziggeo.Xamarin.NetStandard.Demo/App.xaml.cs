using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ziggeo;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Ziggeo.Xamarin.NetStandard.Demo
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = false;
        public static IZiggeoApplication ZiggeoApplication;
        public const string ZiggeoApplicationToken = "ZIGGEO_APP_ID";

        public App()
        {
            InitializeComponent();
        }

        public App(IZiggeoApplication instance)
        {
            InitializeComponent();

            ZiggeoApplication = instance;

            //ZiggeoApplication.ServerAuthToken = "SERVER_AUTH_TOKEN";
            //ZiggeoApplication.ClientAuthToken = "CLIENT_AUTH_TOKEN";
            ZiggeoApplication.Videos.UploadStarted += (string filePath) =>
            {
                //upload started
                Console.WriteLine("upload started from {0}", filePath);
            };

            ZiggeoApplication.Videos.UploadProgressChanged += (string token, string filename, long bytesSent, long totalBytes) =>
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

            ZiggeoApplication.Recorder.RecordingStarted += () =>
            {
                //recorder started
                Console.WriteLine("recording started");
            };

            ZiggeoApplication.Recorder.RecordingStopped += () =>
            {
                //recording was stopped
                Console.WriteLine("recording stopped");
            };

            ZiggeoApplication.Recorder.RecordingCanceled += () =>
            {
                //recorder was closed by the user
                Console.WriteLine("recorded was closed manually, recording was canceled");
            };

            ZiggeoApplication.Recorder.RecordingFinishedUploadDone += (string token) =>
            {
                //done
                Console.WriteLine("recording and file upload were finished with token {0}", token);
            };

            ZiggeoApplication.Recorder.RecordingError += (Exception ex) =>
            {
                //handle error
                Console.WriteLine("recorder error: {0}", ex.ToString());
            };

            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<CloudDataStore>();

            if (Device.RuntimePlatform == Device.iOS)
                MainPage = new MainPage();
            else
                MainPage = new NavigationPage(new MainPage());
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
