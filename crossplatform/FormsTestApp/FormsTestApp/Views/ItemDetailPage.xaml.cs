using System;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace FormsTestApp
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
                token = "Item 1",
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
            Task.Run(async () =>
            {
                byte[] data = await App.ZiggeoApplication.Videos.GetCover(viewModel.Item.token);
                this.img.Source = ImageSource.FromStream(() =>
                {
                    return new System.IO.MemoryStream(data);
                });
            }).Wait();
        }

        async void Delete_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
            await App.ZiggeoApplication.Videos.Delete(viewModel.Item.token);
        }
    }
}
