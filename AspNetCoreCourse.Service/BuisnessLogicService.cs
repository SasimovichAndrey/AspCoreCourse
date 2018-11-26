using AspNeCoretCourse.Service.Data;
using AspNetCoreCourse.Service.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AspNetCoreCourse.Service
{
    public class BuisnessLogicService
    {
        private readonly AppDbContext _dbContext;

        public BuisnessLogicService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Vehicle CreateNewVehicle(Vehicle vehicle)
        {
            _dbContext.Vehicles.Add(vehicle);
            _dbContext.SaveChanges();

            vehicle = _dbContext.Vehicles
                .Include(v => v.Model)
                    .ThenInclude(m => m.Make)
                .Include(v => v.Features)
                    .ThenInclude(vf => vf.Feature)
                .SingleOrDefault(v => v.Id == vehicle.Id);

            return vehicle;
        }

        public object GetVehicles()
        {
            return _dbContext.Vehicles
                .Include(v => v.Model)
                    .ThenInclude(m => m.Make)
                .Include(v => v.Features)
                    .ThenInclude(vf => vf.Feature)
                .ToList();
        }
    }
}
