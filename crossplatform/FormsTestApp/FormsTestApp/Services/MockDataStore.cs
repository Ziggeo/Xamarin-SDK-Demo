using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormsTestApp
{
    public class MockDataStore : IDataStore<VideoItem>
    {
        List<VideoItem> items;

        public MockDataStore()
        {
            items = new List<VideoItem>();
            var mockItems = new List<VideoItem>
            {
                new VideoItem { token = Guid.NewGuid().ToString()},
                new VideoItem { token = Guid.NewGuid().ToString()},
                new VideoItem { token = Guid.NewGuid().ToString()},
                new VideoItem { token = Guid.NewGuid().ToString()},
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
            var _item = items.Where((VideoItem arg) => arg.token == token).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<VideoItem>> Index()
        {
            return await Task.FromResult(items);
        }
    }
}
