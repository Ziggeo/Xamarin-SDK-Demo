using System.Collections.Generic;
using System.Threading.Tasks;
using Ziggeo.Xamarin.NetStandard.Demo.Models;

namespace Ziggeo.Xamarin.NetStandard.Demo.Services
{
    public interface IImagesService
    {
        void AddCachedItem(ImageItem item);
        Task<bool> Delete(string id);
        Task<IEnumerable<ImageItem>> Index();
    }
}