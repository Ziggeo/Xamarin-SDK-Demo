using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ziggeo.Xamarin.NetStandard.Demo.Models;

namespace Ziggeo.Xamarin.NetStandard.Demo.Services
{
    public class MockVideosService : IVideosService
    {
        List<VideoItem> items;

        public MockVideosService()
        {
            items = new List<VideoItem>();
            var mockItems = new List<VideoItem>
            {
                new VideoItem { Token = Guid.NewGuid().ToString()},
                new VideoItem { Token = Guid.NewGuid().ToString()},
                new VideoItem { Token = Guid.NewGuid().ToString()},
                new VideoItem { Token = Guid.NewGuid().ToString()},
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public void AddCachedItem(VideoItem item)
        {
            items.Add(item);
        }

        public async Task<bool> Delete(string token)
        {
            var _item = items.Where((VideoItem arg) => arg.Token == token).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<VideoItem>> Index()
        {
            return await Task.FromResult(items);
        }
    }
}
