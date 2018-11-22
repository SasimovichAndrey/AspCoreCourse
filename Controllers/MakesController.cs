using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNeCoretCourse.Data;
using AspNetCoreCourse.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreCourse.Controllers
{
    [Route("api/[controller]")]
    public class MakesController : Controller
    {
        private readonly AppDbContext _dbContext;

        public MakesController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Make> Makes()
        {
            var makes = _dbContext.Makes.ToList();

            return makes;
        }
    }
}
