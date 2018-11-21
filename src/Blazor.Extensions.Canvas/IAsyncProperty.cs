using System.Threading.Tasks;

namespace Blazor.Extensions
{
    public interface IAsyncProperty<T>
    {
        Task<T> GetAsync();
        Task SetAsync(T value);
    }
}
