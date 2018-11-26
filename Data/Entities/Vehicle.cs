using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreCourse.Data.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }

        public Model Model { get; set; }
        public ICollection<VehicleFeature> Features { get; set; }
    }
}
