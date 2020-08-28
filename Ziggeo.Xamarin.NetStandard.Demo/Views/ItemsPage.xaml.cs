using System;
using Xamarin.Forms;
using Ziggeo.Xamarin.NetStandard.Demo.Models;
using Ziggeo.Xamarin.NetStandard.Demo.Services;
using Ziggeo.Xamarin.NetStandard.Demo.ViewModels;

namespace Ziggeo.Xamarin.NetStandard.Demo.Views
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
            recorder.MaxRecordingDurationSeconds = 5;
            recorder.ShowAudioIndicator = true;
            recorder.ShowLightIndicator = true;
            recorder.ShowFaceOutline = true;
            recorder.LuminosityUpdated += (double luminosity) => {
                //Console.WriteLine("new luminosity value received: {0}", luminosity);
            };
            recorder.AudioLevelUpdated += (double level) =>
            {
                //Console.WriteLine("new audio level received: {0}", level);
            };
            recorder.FaceDetected += (int faceID, double x, double y, double width, double height) => {
                Console.WriteLine("face {0} detected at: {1}x{2}, size: {3}:{4}", faceID, x, y, width, height); 
            };
            try
            {
                string token = await recorder.Record();
                MessagingCenter.Send<ItemsPage, VideoItem>(this, "AddItem", new VideoItem() { Token = token });
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
