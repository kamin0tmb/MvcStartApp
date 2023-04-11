using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MvcStartApp.Models.Db
{
    public class LogsRepository : ILogsRepository
    {
        // ссылка на контекст
        private readonly BlogContext _context;

        // Метод-конструктор для инициализации
        public LogsRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task AddRequest(string url)
        {
            var request = new Request()
            {
                Date = DateTime.Now,
                Id = Guid.NewGuid(),
                Url = url
            };

            // Добавление информации о запросе
            var entry = _context.Entry(request);
            if (entry.State == EntityState.Detached)
                await _context.Requests.AddAsync(request);

            // Сохранение изенений
            await _context.SaveChangesAsync();
        }

        public async Task<Request[]> GetRequest()
        {
            // Получим всех активных пользователей
            return await _context.Requests.ToArrayAsync();
        }
    }
}
