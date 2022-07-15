using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Ziggeo.Xamarin.NetStandard.Demo.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            OpenWebCommand = new Command(url => Device.OpenUri(new Uri(url.ToString())));
        }

        public ICommand OpenWebCommand { get; }
    }
}