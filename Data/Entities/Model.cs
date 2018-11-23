using AspNetCoreCourse.Data.Entities;

namespace AspNetCoreCourse.Data.Entities
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int MakeId { get; set; }

        public Make Make { get; set; }
    }
}