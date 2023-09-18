using System.ComponentModel.DataAnnotations;

namespace QuanLyGhiDanh.Models
{
    public class MonHocModel
    {
        [Required]
        public int IdMonHoc { get; set; }
        [Required]
        public string? TenMon { get; set; }
        [Required]
        public int? IdNhomBoMon { get; set; }
        [Required]
        public int? IdKhoaHoc { get; set; }

    }
}
