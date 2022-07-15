using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Ziggeo.Xamarin.NetStandard.Demo.Models;
using Ziggeo.Xamarin.NetStandard.Demo.Services;

namespace Ziggeo.Xamarin.NetStandard.Demo.ViewModels
{
    public class RecordingsListViewModel : BaseViewModel
    {
        public ObservableCollection<MediaItem> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public IVideosService VideosService => DependencyService.Get<IVideosService>() ?? new MockVideosService();
        public IAudiosService AudiosService => DependencyService.Get<IAudiosService>() ?? new MockAudiosService();
        public IImagesService ImagesService => DependencyService.Get<IImagesService>() ?? new MockImagesService();

        public RecordingsListViewModel()
        {
            Items = new ObservableCollection<MediaItem>();
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
                var videoItems = await VideosService.Index();
                var audioItems = await AudiosService.Index();
                var imageItems = await ImagesService.Index();

                var items = videoItems.Concat<MediaItem>(audioItems).Concat(imageItems);
                var mediaItems = items as MediaItem[] ?? items.ToArray();
                var orderedEnumerable = mediaItems
                        .OrderByDescending(item => DateTime.Parse(item.Date))
                    .ToList();
                foreach (var item in orderedEnumerable)
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