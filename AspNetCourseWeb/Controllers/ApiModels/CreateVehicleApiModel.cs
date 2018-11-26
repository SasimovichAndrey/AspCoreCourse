using System.ComponentModel.DataAnnotations;

namespace AspNetCoreCourse.Controllers.ApiModels
{
    public class CreateVehicleApiModel
    {
        [Required]
        public string ContactName { get; set; }
        [Required]
        public string ContactPhone { get; set; }
        [Required]
        public int? ModelId { get; set; }
        [Required]
        public int[] FeaturesIds { get; set; }
    }
}
