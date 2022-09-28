using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Repositories;
using System.Threading.Tasks;

namespace MvcStartApp.Controllers
{
    public class LogsController : Controller
    {
        private readonly ILogsRepository _repo;

        public LogsController(ILogsRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var requests = await _repo.GetRequests();
            return View(requests);
        }

    }
}
