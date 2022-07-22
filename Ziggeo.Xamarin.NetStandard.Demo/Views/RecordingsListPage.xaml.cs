using System;
using Acr.UserDialogs;
using Xamarin.Essentials;
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

        public RecordingsListPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new RecordingsListViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (!(args.SelectedItem is MediaItem item))
                return;

            var model = new RecordingDetailsViewModel {Item = item};
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

        private async void BtnVideo_OnClicked(object sender, EventArgs e)
        {
            if (GetCustomCameraMode())
            {
                await Navigation.PushAsync(new CustomCameraPage());
            }
            else
            {
                App.ZiggeoApplication.StartCameraRecorder();
            }
        }

        private void BtnScreen_OnClicked(object sender, EventArgs e)
        {
            App.ZiggeoApplication.StartScreenRecorder();
        }

        private void BtnImage_OnClicked(object sender, EventArgs e)
        {
            App.ZiggeoApplication.StartImageRecorder();
        }

        private void BtnFolder_OnClicked(object sender, EventArgs e)
        {
            App.ZiggeoApplication.StartFileSelector();
        }

        private void BtnMic_OnClicked(object sender, EventArgs e)
        {
            App.ZiggeoApplication.StartAudioRecorder();
        }

        private void ShowComingSoonToast()
        {
            UserDialogs.Instance.Toast(AppResources.coming_soon, new TimeSpan(1));
        }
        
        private bool GetCustomCameraMode()
        {
            return Preferences.Get(Constants.CustomCameraMode, false);
        }
    }
}