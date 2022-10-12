using System.Threading.Tasks;

namespace JSMClientsRegistries.Core.Interfaces
{
    public interface IUseCaseAsync<TRequest, TResponse>
    {
        Task<TResponse> ExecuteAsync(TRequest request);
    }
}
