﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FormsTestApp
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as VideoItem;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            Ziggeo.IZiggeoRecorder recorder = App.ZiggeoApplication.Recorder;
            recorder.VideoDevice = Ziggeo.ZiggeoVideoDevice.Front;
            recorder.CameraFlipButtonVisible = true;
            recorder.VideoQuality = Ziggeo.VideoQuality.High;
            recorder.AdditionalParameters = new Dictionary<string, string> { { "video_profile", "VIDEO_PROFILE_ID"} };
            try
            {
                string token = await recorder.Record();
                MessagingCenter.Send<ItemsPage, VideoItem>(this, "AddItem", new VideoItem() { token = token });
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Okay");
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
