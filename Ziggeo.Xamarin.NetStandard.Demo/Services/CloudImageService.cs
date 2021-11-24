using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ziggeo.Xamarin.NetStandard.Demo.Models;

namespace Ziggeo.Xamarin.NetStandard.Demo.Services
{
    public class CloudImageService : IImagesService
    {
        List<ImageItem> items;

        public CloudImageService()
        {
            items = new List<ImageItem>();
        }

        public async Task<IEnumerable<ImageItem>> Index()
        {
            items.Clear();
            items.AddRange((await App.ZiggeoApplication.Images.Index(null))
                .Select(jsonObj =>
            {
                var tags = jsonObj[ImageItem.KeyTags].ToString()
                    .Replace("[", "")
                    .Replace("]", "")
                    .Replace("\"", "")
                    .Replace("\n", "");
            
                return new ImageItem()
                {
                    Token = jsonObj[ImageItem.KeyToken].ToString(),
                    Key = jsonObj[ImageItem.KeyVideoKey].ToString(),
                    Status = jsonObj[ImageItem.KeyState].ToString(),
                    Title = jsonObj[ImageItem.KeyTitle].ToString(),
                    Description = jsonObj[ImageItem.KeyDescription].ToString(),
                    Tags = tags,
                    Date = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                        .AddSeconds((double) jsonObj[ImageItem.KeyDate])
                        .ToLocalTime().ToString("g"),
                };
            }));
            return items;
        }

        public void AddCachedItem(ImageItem item)
        {
            items.Add(item);
        }

        public async Task<bool> Delete(string token)
        {
            try
            {
                await App.ZiggeoApplication.Images.Destroy(token);
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