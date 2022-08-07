using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ziggeo.Xamarin.NetStandard.Demo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomPlayerPage : ContentPage
    {
        public CustomPlayerPage(List<string> tokens, List<string> paths)
        {
            InitializeComponent();
            var playerView = App.ZiggeoVideoView;
            playerView.HorizontalOptions = LayoutOptions.FillAndExpand;
            playerView.VerticalOptions = LayoutOptions.FillAndExpand;
            if (tokens != null && tokens.Count >= 1)
            {
                App.ZVideoView.SetVideoTokens(tokens);
            }
            else
            {
                App.ZVideoView.SetVideoUris(paths);
            }

            App.ZVideoView.LoadConfigs();
            App.ZVideoView.InitViews();
            App.ZVideoView.PrepareQueueAndStartPlaying();

            StackLayout.Children.Add(playerView);
        }
    }
}