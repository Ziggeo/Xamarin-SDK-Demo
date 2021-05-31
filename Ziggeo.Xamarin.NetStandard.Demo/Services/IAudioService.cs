using System.Collections.Generic;
using System.Threading.Tasks;
using Ziggeo.Xamarin.NetStandard.Demo.Models;

namespace Ziggeo.Xamarin.NetStandard.Demo.Services
{
    public interface IAudiosService
    {
        void AddCachedItem(AudioItem item);
        Task<bool> Delete(string id);
        Task<IEnumerable<AudioItem>> Index();
    }
}