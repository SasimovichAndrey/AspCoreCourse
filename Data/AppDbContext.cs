using AspNetCoreCourse.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNeCoretCourse.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Make> Makes { get; set; }
        public DbSet<Feature> Features { get; set; }
    }
}