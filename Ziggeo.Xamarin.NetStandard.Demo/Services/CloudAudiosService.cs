using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ziggeo.Xamarin.NetStandard.Demo.Models;

namespace Ziggeo.Xamarin.NetStandard.Demo.Services
{
    public class CloudAudiosService : IAudiosService
    {
        List<AudioItem> items;

        public CloudAudiosService()
        {
            items = new List<AudioItem>();
        }

        public async Task<IEnumerable<AudioItem>> Index()
        {
            items.Clear();
            items.AddRange((await App.ZiggeoApplication.Audios.Index(null))
            .Select(jsonObj =>
            {
                var tags = jsonObj[AudioItem.KeyTags].ToString()
                    .Replace("[", "")
                    .Replace("]", "")
                    .Replace("\"", "")
                    .Replace("\n", "");
            
                return new AudioItem()
                {
                    Token = jsonObj[AudioItem.KeyToken].ToString(),
                    Key = jsonObj[AudioItem.KeyVideoKey].ToString(),
                    Status = jsonObj[AudioItem.KeyState].ToString(),
                    Title = jsonObj[AudioItem.KeyTitle].ToString(),
                    Description = jsonObj[AudioItem.KeyDescription].ToString(),
                    Tags = tags,
                    Date = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                        .AddSeconds((double) jsonObj[AudioItem.KeyDate])
                        .ToLocalTime().ToString("g"),
                };
            }));
            return items;
        }

        public void AddCachedItem(AudioItem item)
        {
            items.Add(item);
        }

        public async Task<bool> Delete(string token)
        {
            try
            {
                await App.ZiggeoApplication.Audios.Destroy(token);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}