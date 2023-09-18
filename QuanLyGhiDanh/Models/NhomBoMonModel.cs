using System.ComponentModel.DataAnnotations;

namespace QuanLyGhiDanh.Models
{
    public class NhomBoMonModel
    {
        public int IdNhomBoMon { get; set; }
        [Required]
        public string? TenNhomBoMon { get; set; }
    }
}
