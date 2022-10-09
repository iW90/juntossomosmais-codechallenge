using System.Threading.Tasks;

namespace jsmclients.Core.Interfaces
{
    public interface IUseCaseAsync<TRequest, TResponse>
    {
        Task<TResponse> ExecuteAsync(TRequest request);
    }
}
