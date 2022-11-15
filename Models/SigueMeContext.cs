using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Models
{
    public class SigueMeContext : DbContext
    {
        public SigueMeContext(DbContextOptions<TrinosContext> options)
        : base(options)
        {
        }

        public DbSet<Trinos> TodoItems { get; set; } = null!;
    }
}
