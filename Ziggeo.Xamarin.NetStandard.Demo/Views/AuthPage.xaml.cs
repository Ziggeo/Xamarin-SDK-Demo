using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Ziggeo.Xamarin.NetStandard.Demo.Models;
using Ziggeo.Xamarin.NetStandard.Demo.ViewModels;
using Xamarin.Forms.Xaml;
using Ziggeo.Xamarin.NetStandard.Demo.Utils;

namespace Ziggeo.Xamarin.NetStandard.Demo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthPage : ContentPage
    {
        public AuthPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<AuthViewModel>(
                this,
                Constants.NavHome,
                async sender =>
                {
                    MessageCenterUnsubscribe();
                    Navigation.InsertPageBefore(new MainPage(), this);
                    await Navigation.PopAsync();
                });
        }

        public void MessageCenterUnsubscribe()
        {
            MessagingCenter.Unsubscribe<AuthViewModel>(this, Constants.NavHome);
        }
    }
}