using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Models
{
    public class TrinosContext : DbContext
    {
        public TrinosContext(DbContextOptions<TrinosContext> options)
        : base(options)
        {
        }

        public DbSet<Trinos> TrinosCollection { get; set; } = null!;
    }
}