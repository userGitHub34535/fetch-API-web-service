using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace PointsApi.Models
{
    public class PointsContext : DbContext
    {
        public PointsContext(DbContextOptions<PointsContext> options)
            : base(options)
        {
        }

        public DbSet<Points> Points { get; set; } = null!;
    }
}