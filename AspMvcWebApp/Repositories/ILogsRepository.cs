using System.Threading.Tasks;
using MvcStartApp.Models.Db;

namespace MvcStartApp.Repositories
{
    public interface ILogsRepository
    {
        Task AddRequest(string url);
        Task<Request[]> GetRequests();
    }
}
