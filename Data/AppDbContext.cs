using AspNetCoreCourse.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNeCoretCourse.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<Make>().Property(m => m.Name).IsRequired();
            builder.Entity<Make>().Property(m => m.Name).HasMaxLength(255);
            builder.Entity<Model>().ToTable("Models");
        }

        public DbSet<Make> Makes { get; set; }
        public DbSet<Feature> Features { get; set; }
    }
}