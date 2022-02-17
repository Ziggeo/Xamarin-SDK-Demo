using Xamarin.Essentials;
using Xamarin.Forms;
using Ziggeo.Xamarin.NetStandard.Demo.Utils;

namespace Ziggeo.Xamarin.NetStandard.Demo.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public bool IsBlurMode { get; set; }

        public SettingsViewModel()
        {
            IsBlurMode = false;
            // IsBlurMode = Preferences.Get(Constants.BlurMode, false);
        }
        
         public void SaveBlurMode()
                {
                    Preferences.Set(Constants.BlurMode, IsBlurMode);
                }
    }
}