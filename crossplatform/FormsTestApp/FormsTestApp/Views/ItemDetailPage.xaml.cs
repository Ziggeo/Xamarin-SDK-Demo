using Xamarin.Forms;
using Acr.UserDialogs;

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
            LoadImage();
        }

        async void LoadImage()
        {
            ShowLoading();
            var stream = await App.ZiggeoApplication.Videos.DownloadImage(viewModel.Item.token);
            this.img.Source = ImageSource.FromStream(() => { return stream; });
            HideLoading();
        }

        async void Delete_Clicked(object sender, System.EventArgs e)
        {
            ShowLoading();
            await App.ZiggeoApplication.Videos.Destroy(viewModel.Item.token);
            HideLoading();
            await Navigation.PopAsync();
        }

        async void Play_Clicked(object sender, System.EventArgs e)
        {
            Ziggeo.IZiggeoPlayer player = App.ZiggeoApplication.Player;
            await player.Play(viewModel.Item.token);
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