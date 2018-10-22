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
    }
}
