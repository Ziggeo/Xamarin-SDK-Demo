using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Ziggeo.Xamarin.NetStandard.Demo.Models;
using Ziggeo.Xamarin.NetStandard.Demo.Utils;
using Ziggeo.Xamarin.NetStandard.Demo.ViewModels;

namespace Ziggeo.Xamarin.NetStandard.Demo.Views
{
    public partial class RecordingsListPage : ContentPage
    {
        private bool _isOpened;
        private readonly RecordingsListViewModel _viewModel;
        private readonly EventLogger _logger = App.EventLogger;

        public RecordingsListPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new RecordingsListViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as VideoItem;
            if (item == null)
                return;

            RecordingDetailsViewModel model = new RecordingDetailsViewModel {Item = item};
            await Navigation.PushAsync(new RecordingDetailsPage(model));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.LoadItemsCommand.Execute(null);
        }

        private void BtnRoot_OnClicked(object sender, EventArgs e)
        {
            BtnRoot.RotateTo(_isOpened ? 0 : 45);
            _isOpened = !_isOpened;
            BtnFolder.IsVisible = _isOpened;
            BtnImage.IsVisible = _isOpened;
            BtnMic.IsVisible = _isOpened;
            BtnScreen.IsVisible = _isOpened;
            BtnVideo.IsVisible = _isOpened;
        }

        private void BtnVideo_OnClicked(object sender, EventArgs e)
        {
            _initConfigs();
            App.ZiggeoApplication.StartCameraRecorder();
        }

        private void BtnScreen_OnClicked(object sender, EventArgs e)
        {
            _initConfigs();
            App.ZiggeoApplication.StartScreenRecorder();
        }

        private void BtnImage_OnClicked(object sender, EventArgs e)
        {
            _initConfigs();
            ShowComingSoonToast();
        }

        private void BtnFolder_OnClicked(object sender, EventArgs e)
        {
            _initConfigs();
            App.ZiggeoApplication.StartFileSelector();
        }

        private void BtnMic_OnClicked(object sender, EventArgs e)
        {
            _initConfigs();
            ShowComingSoonToast();
        }

        private void ShowComingSoonToast()
        {
            Acr.UserDialogs.UserDialogs.Instance.Toast(AppResources.coming_soon, new TimeSpan(1));
        }

        private void _initConfigs()
        {
            _initPlayerConfig();
            _initCameraRecorderConfig();
            _initFileSelectorConfig();
            _initScreenRecorderConfig();
        }

        private void _initPlayerConfig()
        {
            var plConfig = new PlayerConfig();
            plConfig.Error += exception => _logger.Add(AppResources.ev_pl_error, exception.ToString());
            plConfig.Loaded += () => _logger.Add(AppResources.ev_pl_loaded);
            plConfig.CanceledByUser += () => _logger.Add(AppResources.ev_pl_canceledByUser);
            plConfig.AccessGranted += () => _logger.Add(AppResources.ev_pl_accessGranted);
            plConfig.AccessForbidden += (permissions) =>
                _logger.Add(AppResources.ev_pl_accessForbidden, permissions.ToString());
            plConfig.Playing += () => _logger.Add(AppResources.ev_pl_playing);
            plConfig.Paused += () => _logger.Add(AppResources.ev_pl_paused);
            plConfig.Ended += () => _logger.Add(AppResources.ev_pl_ended);
            plConfig.Seek += (seekToMillis) =>
                _logger.Add(AppResources.ev_pl_seek, seekToMillis.ToString());
            plConfig.ReadyToPlay += () => _logger.Add(AppResources.ev_pl_readyToPlay);
            App.ZiggeoApplication.PlayerConfig = plConfig;
        }

        private void _initFileSelectorConfig()
        {
            var fsConfig = new FileSelectorConfig();
            fsConfig.Error += exception => _logger.Add(AppResources.ev_fs_loaded, exception.ToString());
            fsConfig.Loaded += () => _logger.Add(AppResources.ev_fs_loaded);
            fsConfig.CanceledByUser += () => _logger.Add(AppResources.ev_fs_canceledByUser);
            fsConfig.AccessGranted += () => _logger.Add(AppResources.ev_fs_accessGranted);
            fsConfig.AccessForbidden += (permissions) =>
                _logger.Add(AppResources.ev_fs_accessForbidden, permissions.ToString());
            fsConfig.UploadSelected += (paths) =>
                _logger.Add(AppResources.ev_fs_uploadSelected, paths.ToString());
            App.ZiggeoApplication.FileSelectorConfig = fsConfig;
        }

        private void _initCameraRecorderConfig()
        {
            CameraRecorderConfig config = new CameraRecorderConfig();
            config.Error += exception => Console.WriteLine("SR.Error:" + exception);
            App.ZiggeoApplication.CameraRecorderConfig = config;
        }

        private void _initScreenRecorderConfig()
        {
            ScreenRecorderConfig config = new ScreenRecorderConfig();
            config.Error += exception => Console.WriteLine("SR.Error:" + exception);
            App.ZiggeoApplication.ScreenRecorderConfig = config;
        }
    }
}