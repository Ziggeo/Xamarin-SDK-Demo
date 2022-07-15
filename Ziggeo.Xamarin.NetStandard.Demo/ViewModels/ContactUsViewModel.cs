using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Ziggeo.Xamarin.NetStandard.Demo.Utils;

namespace Ziggeo.Xamarin.NetStandard.Demo.ViewModels
{
    public class ContactUsViewModel : BaseViewModel
    {
        public ContactUsViewModel()
        {
            ContactUsCommand = new Command(() =>
            {
                var message = new EmailMessage
                {
                    To = new List<string> {"support@ziggeo.com"},
                };
                Email.ComposeAsync(message);
            });
            VisitSupportCommand = new Command(() => { Launcher.OpenAsync("https://support.ziggeo.com"); });
        }

        public ICommand ContactUsCommand { get; }

        public ICommand VisitSupportCommand { get; }
    }
}