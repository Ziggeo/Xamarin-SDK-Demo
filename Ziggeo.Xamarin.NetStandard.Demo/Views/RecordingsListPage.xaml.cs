using System;
using Xamarin.Forms;

namespace Ziggeo.Xamarin.NetStandard.Demo.Views
{
    public partial class RecordingsListPage : ContentPage
    {
        private bool _isOpened;

        public RecordingsListPage()
        {
            InitializeComponent();
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
            App.ZiggeoApplication.Recorder.StartRecorder();
        }

        private void BtnScreen_OnClicked(object sender, EventArgs e)
        {
            ShowComingSoonToast();
        }

        private void BtnImage_OnClicked(object sender, EventArgs e)
        {
            ShowComingSoonToast();
        }

        private void BtnFolder_OnClicked(object sender, EventArgs e)
        {
            ShowComingSoonToast();
        }

        private void BtnMic_OnClicked(object sender, EventArgs e)
        {
            ShowComingSoonToast();
        }

        private void ShowComingSoonToast()
        {
            Acr.UserDialogs.UserDialogs.Instance.Toast(AppResources.coming_soon, new TimeSpan(1));
        }
    }
}