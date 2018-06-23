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
                var stream = await App.ZiggeoApplication.Videos.DownloadImage(viewModel.Item.token);
                this.img.Source = ImageSource.FromStream(() =>
                {
                    return stream;
                });
            }).Wait();
        }

        async void Delete_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
            await App.ZiggeoApplication.Videos.Destroy(viewModel.Item.token);
        }

        async void Play_Clicked(object sender, System.EventArgs e)
        {
            Ziggeo.IZiggeoPlayer player = App.ZiggeoApplication.Player;
            await player.Play(viewModel.Item.token);
        }

    }
}
