using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace FormsTestApp
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
