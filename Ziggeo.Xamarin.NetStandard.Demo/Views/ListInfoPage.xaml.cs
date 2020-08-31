using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Ziggeo.Xamarin.NetStandard.Demo.Models;
using Ziggeo.Xamarin.NetStandard.Demo.ViewModels;

namespace Ziggeo.Xamarin.NetStandard.Demo.Views
{
    public partial class ListInfoPage : ContentPage
    {
        private readonly BaseViewModel _viewModel;

        public ListInfoPage(BaseViewModel model)
        {
            InitializeComponent();

            BindingContext = _viewModel = model;
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (!(args.SelectedItem is BaseAboutItem item))
                return;
            await Launcher.OpenAsync(item.Url);

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.LoadCommand.Execute(null);
        }
    }
}