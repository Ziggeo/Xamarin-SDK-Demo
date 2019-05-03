using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FormsTestApp
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<VideoItem> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<VideoItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<ItemsPage, VideoItem>(this, "AddItem", (obj, item) =>
            {
                var _item = item as VideoItem;
                Items.Add(_item);
                DataStore.AddCachedItem(_item);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.Index();
                foreach (var item in items)
                {
                    Items.Add(item);

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
