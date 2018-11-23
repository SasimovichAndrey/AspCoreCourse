using System.Collections.Generic;

namespace AspNeCoretCourse.Controllers.ApiModels
{
    public class MakeApiModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ModelApiModel> Models { get; set; }
    }
}