using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreCourse.Data.Entities
{
    public class VehicleFeature
    {
        public int FeatureId { get; set; }
        public int VehicleId { get; set; }

        public Feature Feature { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
