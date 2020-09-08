using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Ziggeo.Xamarin.NetStandard.Demo.Models;
using Ziggeo.Xamarin.NetStandard.Demo.Services;
using Ziggeo.Xamarin.NetStandard.Demo.Views;

namespace Ziggeo.Xamarin.NetStandard.Demo.ViewModels
{
    public class RecordingsListViewModel : BaseViewModel
    {
        public ObservableCollection<VideoItem> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public IVideosService VideosService => DependencyService.Get<IVideosService>() ?? new MockVideosService();

        public RecordingsListViewModel()
        {
            Items = new ObservableCollection<VideoItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadCommand());
        }

        public override async Task ExecuteLoadCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await VideosService.Index();
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