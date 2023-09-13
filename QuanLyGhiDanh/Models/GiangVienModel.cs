using System.ComponentModel.DataAnnotations;

namespace QuanLyGhiDanh.Models
{
    public class GiangVienModel
    {
        [Required]
        public int IdGiangVien { get; set; }
        [Required]
        public double Masothue { get; set; }
        [Required]
        public string? HoTenGV { get; set; }
        [Required]
        public string? NgaySinhGV { get; set; }
        [Required]
        public bool GioiTinhGV { get; set; } = false;
        [Required]
        public string? EmailGV { get; set; }
        [Required]
        public string? SoDienThoaiGV { get; set; }
        [Required]
        public string? DiachiGV { get; set; }
        [Required]
        public string? MonGiangDay { get; set; }
    }
}
