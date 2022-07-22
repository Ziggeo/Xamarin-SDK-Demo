using System;
using Xamarin.Forms;
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
            _viewModel.GetCustomPlayerMode();
            _viewModel.GetCustomCameraMode();

        }

        void OnBlurModeToggled(object sender, ToggledEventArgs e)
        {
            if (e != null && e.Value != _viewModel.IsBlurMode)
            {
                _viewModel.IsBlurMode = e.Value;
            }
        }

        void OnCustomPlayerModeToggled(object sender, ToggledEventArgs e)
        {
            if (e != null && e.Value != _viewModel.CustomPlayerMode)
            {
                _viewModel.CustomPlayerMode = e.Value;
            }
        }

        void OnCustomCameraModeToggled(object sender, ToggledEventArgs e)
        {
            if (e != null && e.Value != _viewModel.CustomPlayerMode)
            {
                _viewModel.CustomCameraMode = e.Value;
            }
        }

        private void SaveSettings(object sender, EventArgs e)
        {
            _viewModel.SaveBlurMode();
            _viewModel.SaveCustomPlayerMode();
            _viewModel.SaveCustomPlayerMode();
        }
    }
}