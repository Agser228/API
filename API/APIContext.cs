using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options) { }
        public DbSet<Event> Event { get; set; }
        public DbSet<Thematic> Thematic { get; set; }
        public DbSet<Congratulation> Congratulation { get; set; }
        
    }
}
