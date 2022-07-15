using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Ziggeo.Xamarin.NetStandard.Demo.Utils;
using Ziggeo.Xamarin.NetStandard.Demo.ViewModels;

namespace Ziggeo.Xamarin.NetStandard.Demo.Views
{
    public partial class SettingsPage : ContentPage
    {
        private readonly SettingsViewModel _viewModel;

        public SettingsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new SettingsViewModel();
            _viewModel.GetBlurMode();
        }

        void OnBlurModeToggled(object sender, ToggledEventArgs e)
        {
            if (e != null && e.Value != _viewModel.IsBlurMode)
            {
                _viewModel.IsBlurMode = e.Value;
            }
        }

        private void SaveSettings(object sender, EventArgs e)
        {
            _viewModel.SaveBlurMode();
        }
    }
}