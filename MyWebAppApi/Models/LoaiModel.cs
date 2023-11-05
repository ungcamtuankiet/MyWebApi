using System.ComponentModel.DataAnnotations;

namespace MyWebAppApi.Models
{
    public class LoaiModel
    {
        [Required]
        [MaxLength(50)]
        public string TenLoai { get; set; }

    }
}
