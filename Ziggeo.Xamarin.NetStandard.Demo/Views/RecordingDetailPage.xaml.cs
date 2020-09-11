using System;
using Acr.UserDialogs;
using Xamarin.Forms;
using Ziggeo.Xamarin.NetStandard.Demo.Models;
using Ziggeo.Xamarin.NetStandard.Demo.ViewModels;

namespace Ziggeo.Xamarin.NetStandard.Demo.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new VideoItem
            {
                Token = "Item 1",
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
            LoadImage();
        }

        async void LoadImage()
        {
            ShowLoading();
            try
            {
                var stream = await App.ZiggeoApplication.Videos.DownloadImage(viewModel.Item.Token);
                this.img.Source = ImageSource.FromStream(() => { return stream; });
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Okay");
            }
            finally
            {
                HideLoading();
            }
        }

        async void Delete_Clicked(object sender, System.EventArgs e)
        {
            ShowLoading();
            try
            {
                await App.ZiggeoApplication.Videos.Destroy(viewModel.Item.Token);
                await Navigation.PopAsync();
            }
            catch (Exception exception)
            {
                await DisplayAlert("Error", exception.Message, "Okay");
            }
            finally
            {
                HideLoading();
            }
        }

        void Play_Clicked(object sender, System.EventArgs e)
        {
             App.ZiggeoApplication.StartPlayer(viewModel.Item.Token);
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