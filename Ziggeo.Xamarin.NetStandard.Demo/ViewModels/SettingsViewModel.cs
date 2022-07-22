using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Ziggeo.Xamarin.NetStandard.Demo.Utils;

namespace Ziggeo.Xamarin.NetStandard.Demo.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private bool _isBlurMode;
        private bool _customPlayerMode;
        private bool _customCameraMode;
        public bool IsBlurMode
        {
            get => _isBlurMode;
            set {  _isBlurMode = value; OnPropertyChanged(nameof(IsBlurMode));  }
        }
        
        public bool CustomPlayerMode
        {
            get => _customPlayerMode;
            set {  _customPlayerMode = value; OnPropertyChanged(nameof(CustomPlayerMode));  }
        }
        
        public bool CustomCameraMode
        {
            get => _customCameraMode;
            set {  _customCameraMode = value; OnPropertyChanged(nameof(CustomCameraMode));  }
        }

        public SettingsViewModel()
        {
        }
        
        public void GetBlurMode()
        {
            IsBlurMode = Preferences.Get(Constants.BlurMode, false);
        }
        
        public void GetCustomPlayerMode()
        {
            CustomPlayerMode = Preferences.Get(Constants.CustomPlayerMode, false);
        }
        
        public void GetCustomCameraMode()
        {
            CustomCameraMode = Preferences.Get(Constants.CustomCameraMode, false);
        }
        
         public void SaveBlurMode()
                {
                    Preferences.Set(Constants.BlurMode, IsBlurMode);
                    App.ZiggeoApplication.CameraRecorderConfig.BlurMode = IsBlurMode;
                }
         
         public void SaveCustomPlayerMode()
         {
             Preferences.Set(Constants.CustomPlayerMode, CustomPlayerMode);
         }
         
         public void SaveCustomCameraMode()
         {
             Preferences.Set(Constants.CustomCameraMode, CustomCameraMode);
         }
    }
}