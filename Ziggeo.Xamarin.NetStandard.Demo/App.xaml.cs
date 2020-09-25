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
            Page page = new AuthPage();
            if (IsLoggedIn())
            {
                page = new MainPage();
                ZiggeoApplication.AppToken = Preferences.Get(Constants.KeyAppToken, null);
            }

            _initConfigs();
            //ZiggeoApplication.ServerAuthToken = "SERVER_AUTH_TOKEN";
            //ZiggeoApplication.ClientAuthToken = "CLIENT_AUTH_TOKEN";

            DependencyService.Register<InfoService>();
            if (UseMockDataStore)
                DependencyService.Register<MockVideosService>();
            else
                DependencyService.Register<CloudVideosService>();


            if (Device.RuntimePlatform == Device.iOS)
                MainPage = page;
            else
                MainPage = new NavigationPage(page);
        }

        public bool IsLoggedIn()
        {
            return !string.IsNullOrEmpty(Preferences.Get(Constants.KeyAppToken, null));
        }

        private void _initConfigs()
        {
            _initPlayerConfig();
            _initCameraRecorderConfig();
            _initFileSelectorConfig();
            _initScreenRecorderConfig();
            _initUploaderConfig();
        }

        private void _initPlayerConfig()
        {
            var plConfig = new PlayerConfig();
            plConfig.Error += exception => EventLogger.Add(AppResources.ev_pl_error, exception.ToString());
            plConfig.Loaded += () => EventLogger.Add(AppResources.ev_pl_loaded);
            plConfig.CanceledByUser += () => EventLogger.Add(AppResources.ev_pl_canceledByUser);
            plConfig.AccessGranted += () => EventLogger.Add(AppResources.ev_pl_accessGranted);
            plConfig.AccessForbidden += (permissions) =>
                EventLogger.Add(AppResources.ev_pl_accessForbidden, permissions.ToString());
            plConfig.Playing += () => EventLogger.Add(AppResources.ev_pl_playing);
            plConfig.Paused += () => EventLogger.Add(AppResources.ev_pl_paused);
            plConfig.Ended += () => EventLogger.Add(AppResources.ev_pl_ended);
            plConfig.Seek += (seekToMillis) =>
                EventLogger.Add(AppResources.ev_pl_seek, seekToMillis.ToString());
            plConfig.ReadyToPlay += () => EventLogger.Add(AppResources.ev_pl_readyToPlay);
            ZiggeoApplication.PlayerConfig = plConfig;
        }

        private void _initFileSelectorConfig()
        {
            var fsConfig = new FileSelectorConfig();
            fsConfig.Error += exception => EventLogger.Add(AppResources.ev_fs_loaded, exception.ToString());
            fsConfig.Loaded += () => EventLogger.Add(AppResources.ev_fs_loaded);
            fsConfig.CanceledByUser += () => EventLogger.Add(AppResources.ev_fs_canceledByUser);
            fsConfig.AccessGranted += () => EventLogger.Add(AppResources.ev_fs_accessGranted);
            fsConfig.AccessForbidden += (permissions) =>
                EventLogger.Add(AppResources.ev_fs_accessForbidden, permissions.ToString());
            fsConfig.UploadSelected += (paths) =>
                EventLogger.Add(AppResources.ev_fs_uploadSelected, paths.ToString());
            ZiggeoApplication.FileSelectorConfig = fsConfig;
        }

        private void _initCameraRecorderConfig()
        {
            CameraRecorderConfig config = new CameraRecorderConfig();
            config.Error += exception => EventLogger.Add(AppResources.ev_rec_error, exception.ToString());
            config.Loaded += () => EventLogger.Add(AppResources.ev_rec_loaded);
            config.CanceledByUser += () => EventLogger.Add(AppResources.ev_rec_canceledByUser);
            config.AccessGranted += () => EventLogger.Add(AppResources.ev_rec_accessGranted);
            config.AccessForbidden += permissions =>
                EventLogger.Add(AppResources.ev_rec_accessForbidden, permissions.ToString());
            config.NoMicrophone += () => EventLogger.Add(AppResources.ev_rec_noMicrophone);
            config.HasMicrophone += () => EventLogger.Add(AppResources.ev_rec_hasMicrophone);
            config.HasCamera += () => EventLogger.Add(AppResources.ev_rec_hasCamera);
            config.NoCamera += () => EventLogger.Add(AppResources.ev_rec_noCamera);
            config.MicrophoneHealth += health =>
                EventLogger.Add(AppResources.ev_rec_microphoneHealth, health);
            config.StreamingStarted += () => EventLogger.Add(AppResources.ev_rec_streamingStarted);
            config.StreamingStopped += () => EventLogger.Add(AppResources.ev_rec_streamingStopped);
            config.RecordingStopped += path => EventLogger.Add(AppResources.ev_rec_recordingStopped);
            config.ReadyToRecord += () => EventLogger.Add(AppResources.ev_rec_readyToRecord);
            config.RecordingStarted += () => EventLogger.Add(AppResources.ev_rec_recordingStarted);
            config.RecordingProgress += millisPassed => EventLogger.Add(AppResources.ev_rec_recordingProgress);
            config.ManuallySubmitted += () => EventLogger.Add(AppResources.ev_rec_manuallySubmitted);
            config.Countdown += secondsLeft =>
                EventLogger.Add(AppResources.ev_rec_countdown, secondsLeft.ToString());
            ZiggeoApplication.CameraRecorderConfig = config;
        }

        private void _initScreenRecorderConfig()
        {
            ScreenRecorderConfig config = new ScreenRecorderConfig();
            config.Error += exception => Console.WriteLine("SR.Error:" + exception);
            ZiggeoApplication.ScreenRecorderConfig = config;
        }

        private void _initUploaderConfig()
        {
            UploaderConfig config = new UploaderConfig();
            config.Error += exception => EventLogger.Add(AppResources.ev_upl_error, exception.ToString());
            config.UploadingStarted += videoToken =>
                EventLogger.Add(AppResources.ev_upl_uploadingStarted, videoToken);
            config.UploadProgress += (videoToken, videoPath, uploadedBytes, totalBytes) =>
                EventLogger.Add(AppResources.ev_upl_uploadProgress, $"{videoToken} {uploadedBytes}/{totalBytes}");
            config.Uploaded += (path, videoToken) =>
                EventLogger.Add(AppResources.ev_upl_uploaded, videoToken);
            config.Verified += videoToken => EventLogger.Add(AppResources.ev_upl_verified, videoToken);
            config.Processing += videoToken => EventLogger.Add(AppResources.ev_upl_processing, videoToken);
            config.Processed += videoToken => EventLogger.Add(AppResources.ev_upl_processed, videoToken);
            ZiggeoApplication.UploaderConfig = config;
        }
    }
}