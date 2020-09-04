using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Ziggeo.Xamarin.NetStandard.Demo.Utils;

namespace Ziggeo.Xamarin.NetStandard.Demo.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public string AppToken { get; set; }

        public MainViewModel()
        {
            OnLogoutClicked = new Command(() =>
            {
                Preferences.Set(Constants.KeyAppToken, null);
                MessagingCenter.Send(this, Constants.NavAuth);
            });
        }

        public ICommand OnLogoutClicked { get; }
    }
}