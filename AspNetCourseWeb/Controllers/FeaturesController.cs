using AspNeCoretCourse.Service.Data;
using AspNetCoreCourse.Controllers.ApiModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreCourse.Controllers
{
    [Route("api/[controller]")]
    public class FeaturesController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public FeaturesController(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SimpleFeatureApiModel>> Get()
        {
            var features = await _dbContext.Features.ToListAsync();

            var models = _mapper.Map<IEnumerable<SimpleFeatureApiModel>>(features);

            return models;
        }
    }
}
