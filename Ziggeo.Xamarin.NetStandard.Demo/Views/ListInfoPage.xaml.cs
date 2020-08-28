﻿using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Ziggeo.Xamarin.NetStandard.Demo.Models;
using Ziggeo.Xamarin.NetStandard.Demo.ViewModels;

namespace Ziggeo.Xamarin.NetStandard.Demo.Views
{
    public partial class ListInfoPage : ContentPage
    {
        BaseViewModel _viewModel;

        public ListInfoPage(BaseViewModel model)
        {
            InitializeComponent();

            BindingContext = _viewModel = model;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as SdkItem;
            if (item == null)
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