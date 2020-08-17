using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ziggeo.Xamarin.NetStandard.Demo.Services
{
    public interface IDataStore<T>
    {
        void AddCachedItem(T item);
        Task<bool> Delete(string id);
        Task<IEnumerable<T>> Index();
    }
}
