using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Models.Db;
using System.Threading.Tasks;

namespace MvcStartApp.Controllers
{
    public class LogsController : Controller
    {
        private readonly ILogsRepository _logsRepository;

        public LogsController(ILogsRepository logsRepository)
        {
            _logsRepository = logsRepository;
        }
     
        public async Task<IActionResult> Index()
        {
            var requests = await _logsRepository.GetRequest();
            return View(requests);
        }
    }    
}
