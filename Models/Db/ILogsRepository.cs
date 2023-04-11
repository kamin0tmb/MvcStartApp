using System.Threading.Tasks;

namespace MvcStartApp.Models.Db
{
    public interface ILogsRepository
    {
        Task AddRequest(string url);
        Task<Request[]> GetRequest();
    }
}