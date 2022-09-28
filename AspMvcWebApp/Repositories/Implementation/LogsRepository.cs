using Microsoft.EntityFrameworkCore;
using MvcStartApp.Models.Db;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MvcStartApp.Repositories.Implementation
{
    public class LogsRepository : ILogsRepository
    {
        private readonly BlogContext _context;

        public LogsRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task AddRequest(string url)
        {
            var request = new Request
            {
                Date = DateTime.Now,
                Id = Guid.NewGuid(),
                Url = url
            };

            var entry = _context.Entry(request);
            if (entry.State == EntityState.Detached)
                await _context.Requests.AddAsync(request);

            await _context.SaveChangesAsync();
        }

        public async Task<Request[]> GetRequests() =>
            await _context.Requests.OrderByDescending(x => x.Date).ToArrayAsync();
    }
}
