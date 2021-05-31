using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ziggeo.Xamarin.NetStandard.Demo.Models;

namespace Ziggeo.Xamarin.NetStandard.Demo.Services
{
    public class MockAudiosService : IAudiosService
    {
        List<AudioItem> items;

        public MockAudiosService()
        {
            items = new List<AudioItem>();
            var mockItems = new List<AudioItem>
            {
                new AudioItem {Token = Guid.NewGuid().ToString()},
                new AudioItem {Token = Guid.NewGuid().ToString()},
                new AudioItem {Token = Guid.NewGuid().ToString()},
                new AudioItem {Token = Guid.NewGuid().ToString()},
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public void AddCachedItem(AudioItem item)
        {
            items.Add(item);
        }

        public async Task<bool> Delete(string token)
        {
            var _item = items.FirstOrDefault(arg => arg.Token == token);
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<AudioItem>> Index()
        {
            return await Task.FromResult(items);
        }
    }
}