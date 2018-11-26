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
            // feature
            builder.Entity<Feature>().HasKey(f => f.Id);
            builder.Entity<Feature>().Property(f => f.Id).ValueGeneratedOnAdd();
            builder.Entity<Feature>().Property(f => f.Name).IsRequired();
            builder.Entity<Feature>().HasMany(f => f.Vehicles).WithOne(vf => vf.Feature);

            // make
            builder.Entity<Make>().HasKey(m => m.Id);
            builder.Entity<Make>().Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Entity<Make>().Property(m => m.Name).IsRequired();
            builder.Entity<Make>().Property(m => m.Name).HasMaxLength(255);
            builder.Entity<Make>().HasMany(m => m.Models).WithOne(m => m.Make);

            // model
            builder.Entity<Model>().ToTable("Models");
            builder.Entity<Model>().HasKey(m => m.Id);
            builder.Entity<Model>().Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Entity<Model>().Property(m => m.Name).IsRequired();
            builder.Entity<Model>().HasOne(m => m.Make).WithMany(m => m.Models).HasForeignKey(m => m.MakeId);

            // vehicle
            builder.Entity<Vehicle>().ToTable("Vehicle");
            builder.Entity<Vehicle>().HasKey(v => v.Id);
            builder.Entity<Vehicle>().Property(v => v.Id).ValueGeneratedOnAdd();
            builder.Entity<Vehicle>().HasOne(v => v.Model).WithMany(m => m.Vehicles).HasForeignKey(v => v.ModelId);
            builder.Entity<Vehicle>().HasMany(v => v.Features).WithOne(vf => vf.Vehicle);

            // vehicle to feature
            builder.Entity<VehicleFeature>().HasKey(vf => new { vf.FeatureId, vf.VehicleId });
            builder.Entity<VehicleFeature>().HasOne(vf => vf.Feature).WithMany(f => f.Vehicles).HasForeignKey(vf => vf.FeatureId);
            builder.Entity<VehicleFeature>().HasOne(vf => vf.Vehicle).WithMany(f => f.Features).HasForeignKey(vf => vf.VehicleId);
        }

        public DbSet<Make> Makes { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}