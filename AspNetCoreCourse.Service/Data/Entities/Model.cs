using System.Collections.Generic;

namespace AspNetCoreCourse.Service.Data.Entities
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int MakeId { get; set; }

        public Make Make { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}