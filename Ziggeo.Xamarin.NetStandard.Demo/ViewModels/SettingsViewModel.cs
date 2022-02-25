using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Ziggeo.Xamarin.NetStandard.Demo.Utils;

namespace Ziggeo.Xamarin.NetStandard.Demo.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private bool _isBlurMode;
        public bool IsBlurMode
        {
            get => _isBlurMode;
            set {  _isBlurMode = value; OnPropertyChanged(nameof(IsBlurMode));  }
        }

        public SettingsViewModel()
        {
        }
        
        public void GetBlurMode()
        {
            IsBlurMode = Preferences.Get(Constants.BlurMode, false);
        }
        
         public void SaveBlurMode()
                {
                    Console.WriteLine("AAAAAAAA _SaveBlurMode"+ IsBlurMode);

                    Preferences.Set(Constants.BlurMode, IsBlurMode);
                    App.ZiggeoApplication.CameraRecorderConfig.BlurMode = IsBlurMode;
                    
                    Console.WriteLine("AAAAAAAA BlurMode"+ App.ZiggeoApplication.CameraRecorderConfig.BlurMode);

                }
    }
}