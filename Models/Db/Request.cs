using System;

namespace MvcStartApp.Models.Db
{
    /// <summary>
    /// Модель для логирования запросов.
    /// </summary>
    public class Request
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
    }
}
