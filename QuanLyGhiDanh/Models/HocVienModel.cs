using System.ComponentModel.DataAnnotations;

namespace QuanLyGhiDanh.Models
{
    public class HocVienModel
    {
        [Required]
        public int IdHocVien { get; set; }
        [Required]
        public string? TenHV { get; set; }
        [Required]
        public string? NgaySinhHV { get; set; }
        [Required]
        public bool GioiTinhHV { get; set; } = false;
        [Required]
        public string? EmailHV { get; set; }
        [Required]
        public string? DiachiHV { get; set; }
        [Required]
        public string? TenNguoiGiamHo { get; set; }
    }
}
