using System.Collections.Generic;
using AspNetCoreCourse.Controllers.ApiModels;
using AspNetCoreCourse.Service;
using AspNetCoreCourse.Service.Data.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreCourse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly BuisnessLogicService _buisnessLogicService;
        private readonly IMapper _mapper;

        public VehiclesController(BuisnessLogicService buisnessLogicService, IMapper mapper)
        {
            _buisnessLogicService = buisnessLogicService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<VehicleGetApiModel> Get()
        {
            var vehicles = _buisnessLogicService.GetVehicles();

            var apiModels = _mapper.Map<IEnumerable<VehicleGetApiModel>>(vehicles);

            return apiModels;
        }

        [HttpPost]
        public VehicleGetApiModel Post(CreateVehicleApiModel model)
        {
            var newVehicle = _mapper.Map<Vehicle>(model);

            newVehicle = _buisnessLogicService.CreateNewVehicle(newVehicle);

            var retModel = _mapper.Map<VehicleGetApiModel>(newVehicle);

            return retModel;
        }
    }
}