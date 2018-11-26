using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreCourse.Controllers.ApiModels
{
    public class VehicleGetApiModel
    {
        public int Id { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public SimpleModelApiModel Model { get; set; }
        public SimpleMakeApiModel Make { get; set; }
        public IEnumerable<SimpleFeatureApiModel> Features { get; set; }
    }
}
