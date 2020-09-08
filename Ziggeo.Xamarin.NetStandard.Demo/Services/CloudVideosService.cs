using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ziggeo.Xamarin.NetStandard.Demo.Models;

namespace Ziggeo.Xamarin.NetStandard.Demo.Services
{
    public class CloudVideosService : IVideosService
    {
        List<VideoItem> items;

        public CloudVideosService()
        {
            items = new List<VideoItem>();
        }

        public async Task<IEnumerable<VideoItem>> Index()
        {
            items.Clear();
            items.AddRange((await App.ZiggeoApplication.Videos.Index(null))
                .Select(jsonObj =>
                {
                    var tags = jsonObj["tags"].ToString()
                        .Replace("[", "")
                        .Replace("]", "")
                        .Replace("\"", "")
                        .Replace("\n", "");

                    return new VideoItem()
                    {
                        Token = jsonObj["token"].ToString(),
                        Status = jsonObj["state_string"].ToString(),
                        Tags = tags,
                        Date = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                            .AddSeconds((double) jsonObj["submission_date"])
                            .ToLocalTime().ToString("g"),
                    };
                }));
            return items;
        }

        public void AddCachedItem(VideoItem item)
        {
            items.Add(item);
        }

        public async Task<bool> Delete(string token)
        {
            try
            {
                await App.ZiggeoApplication.Videos.Destroy(token);
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