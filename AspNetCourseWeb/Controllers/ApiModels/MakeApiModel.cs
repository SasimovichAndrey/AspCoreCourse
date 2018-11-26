using System.Collections.Generic;

namespace AspNetCoreCourse.Controllers.ApiModels
{
    public class MakeApiModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<SimpleModelApiModel> Models { get; set; }
    }
}