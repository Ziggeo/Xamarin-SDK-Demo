using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ziggeo.Xamarin.NetStandard.Demo.Utils;

namespace Ziggeo.Xamarin.NetStandard.Demo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomCameraPage : ContentPage
    {
        private bool _isCameraFront;
        private bool _isRecording;
        private bool _isPlayModeOn;

        public CustomCameraPage()
        {
            InitializeComponent();

            PlayVideo.IsVisible = _isPlayModeOn;
            SwitchCamera.IsVisible = !_isRecording;
            StartRecording.IsVisible = !_isRecording;
            StopRecording.IsVisible = _isRecording;
        }

        private void SwitchCamera_OnClicked(object sender, EventArgs e)
        {
            _isCameraFront = !_isCameraFront;
            App.ZiggeoApplication.CameraRecorderConfig.Facing = _isCameraFront
                ? (int)CameraRecorderConfig.CameraFacing.Rear
                : (int)CameraRecorderConfig.CameraFacing.Front;


            Image image = new Image
            {
                Source = _isCameraFront
                    ? new FontImageSource
                    {
                        Color = Color.White,
                        Size = 20,
                        FontFamily = Device.RuntimePlatform == Device.Android
                            ? "materialdesignicons-webfont.ttf#Material Design Icons"
                            : "Material Design Icons",
                        Glyph = Application.Current.Resources["IconSwitchCameraBack"].ToString()
                    }
                    : new FontImageSource
                    {
                        Color = Color.White,
                        Size = 20,
                        FontFamily = Device.RuntimePlatform == Device.Android
                            ? "materialdesignicons-webfont.ttf#Material Design Icons"
                            : "Material Design Icons",
                        Glyph = Application.Current.Resources["IconSwitchCameraFront"].ToString()
                    }
            };
            SwitchCamera.Source = image.Source;
            CameraWidget.SwitchCamera = true;
        }

        private void StartRecording_OnClicked(object sender, EventArgs e)
        {
            CameraWidget.StartRecording = true;

            _isRecording = !_isRecording;
            SwitchCamera.IsVisible = !_isRecording;
            StartRecording.IsVisible = !_isRecording;
            StopRecording.IsVisible = _isRecording;
        }

        private void PlayVideo_OnClicked(object sender, EventArgs e)
        {
            CameraWidget.PlayRecordedFile = "play";
        }

        private void StopRecording_OnClicked(object sender, EventArgs e)
        {
            CameraWidget.StopRecording = true;

            _isPlayModeOn = true;
            _isRecording = false;
            PlayVideo.IsVisible = _isPlayModeOn;
            SwitchCamera.IsVisible = !_isPlayModeOn;
            StartRecording.IsVisible = !_isPlayModeOn;
            StopRecording.IsVisible = !_isPlayModeOn;
        }
    }
}