using System.ComponentModel.DataAnnotations;

namespace OtzzeiDesafioMottu.Domain.Requests
{
    public class UpdateCnhImageRequest
    {
        [Required]
        public Guid DeliverymanId { get; set; }
        public string CnhImagePath { get; set; } = null!;
    }
}
