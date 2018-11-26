using System.Collections.Generic;
using System.Threading.Tasks;
using AspNeCoretCourse.Service.Data;
using AspNetCoreCourse.Controllers.ApiModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreCourse.Controllers
{
    [Route("api/[controller]")]
    public class MakesController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public MakesController(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<MakeApiModel>> Makes()
        {
            var makes = await _dbContext.Makes.Include(m => m.Models).ToListAsync();

            var models = _mapper.Map<IEnumerable<MakeApiModel>>(makes);

            return models;
        }
    }
}
