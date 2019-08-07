using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Ziggeo.Xamarin.NetStandard.Demo
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
