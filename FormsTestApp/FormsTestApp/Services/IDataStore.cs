using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormsTestApp
{
    public interface IDataStore<T>
    {
        void AddCachedItem(T item);
        Task<bool> Delete(string id);
        Task<IEnumerable<T>> Index();
    }
}
