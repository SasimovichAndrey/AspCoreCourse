using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNeCoretCourse.Data;
using AspNetCoreCourse.Controllers.ApiModels;
using AspNetCoreCourse.Data.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreCourse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public VehiclesController(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<VehicleGetApiModel> Get()
        {
            var vehicles = _dbContext.Vehicles
                .Include(v => v.Model)
                    .ThenInclude(m => m.Make)
                .Include(v => v.Features)
                    .ThenInclude(vf => vf.Feature)
                .ToList();

            var apiModels = _mapper.Map<IEnumerable<VehicleGetApiModel>>(vehicles);

            return apiModels;
        }

        [HttpPost]
        public VehicleGetApiModel Post(CreateVehicleApiModel model)
        {
            var newVehicle = _mapper.Map<Vehicle>(model);

            _dbContext.Vehicles.Add(newVehicle);
            _dbContext.SaveChanges();

            newVehicle = _dbContext.Vehicles
                .Include(v => v.Model)
                    .ThenInclude(m => m.Make)
                .Include(v => v.Features)
                    .ThenInclude(vf => vf.Feature)
                .SingleOrDefault(v => v.Id == newVehicle.Id);

            var retModel = _mapper.Map<VehicleGetApiModel>(newVehicle);

            return retModel;
        }
    }
}