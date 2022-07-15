using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ziggeo.Xamarin.NetStandard.Demo.Models;

namespace Ziggeo.Xamarin.NetStandard.Demo.Services
{
    public class MockImagesService : IImagesService
    {
        List<ImageItem> items;

        public MockImagesService()
        {
            items = new List<ImageItem>();
            var mockItems = new List<ImageItem>
            {
                new ImageItem {Token = Guid.NewGuid().ToString()},
                new ImageItem {Token = Guid.NewGuid().ToString()},
                new ImageItem {Token = Guid.NewGuid().ToString()},
                new ImageItem {Token = Guid.NewGuid().ToString()},
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public void AddCachedItem(ImageItem item)
        {
            items.Add(item);
        }

        public async Task<bool> Delete(string token)
        {
            var _item = items.FirstOrDefault(arg => arg.Token == token);
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<ImageItem>> Index()
        {
            return await Task.FromResult(items);
        }
    }
}