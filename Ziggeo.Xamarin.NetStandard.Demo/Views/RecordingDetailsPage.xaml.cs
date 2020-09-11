using System;
using Acr.UserDialogs;
using Xamarin.Forms;
using Ziggeo.Xamarin.NetStandard.Demo.Models;
using Ziggeo.Xamarin.NetStandard.Demo.ViewModels;

namespace Ziggeo.Xamarin.NetStandard.Demo.Views
{
    public partial class RecordingDetailsPage : ContentPage
    {
        private readonly RecordingDetailsViewModel _viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public RecordingDetailsPage()
        {
            InitializeComponent();
            var item = new VideoItem
            {
                Token = "Item 1",
            };

            _viewModel = new RecordingDetailsViewModel {Item = item};
            BindingContext = _viewModel;
        }

        public RecordingDetailsPage(RecordingDetailsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this._viewModel = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.LoadCommand.Execute(null);
        }

        private void ShowLoading()
        {
            UserDialogs.Instance.Loading().Show();
        }

        private void HideLoading()
        {
            UserDialogs.Instance.Loading().Hide();
        }
    }
}