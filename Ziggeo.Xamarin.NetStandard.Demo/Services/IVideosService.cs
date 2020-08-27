using System.Collections.Generic;
using System.Threading.Tasks;
using Ziggeo.Xamarin.NetStandard.Demo.Models;

namespace Ziggeo.Xamarin.NetStandard.Demo.Services
{
    public interface IVideosService
    {
        void AddCachedItem(VideoItem item);
        Task<bool> Delete(string id);
        Task<IEnumerable<VideoItem>> Index();
    }
}
