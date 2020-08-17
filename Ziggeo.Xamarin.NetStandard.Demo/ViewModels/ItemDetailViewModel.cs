using Ziggeo.Xamarin.NetStandard.Demo.Models;

namespace Ziggeo.Xamarin.NetStandard.Demo.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public VideoItem Item { get; set; }
        public ItemDetailViewModel(VideoItem item = null)
        {
            Title = item?.token;
            Item = item;
        }

    }
}
