using FunnyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace FunnyWeb.Controllers.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        
        public required DbSet<CalendarEvent> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Можно удалить этот метод, если он больше не нужен
        }
    }
} 