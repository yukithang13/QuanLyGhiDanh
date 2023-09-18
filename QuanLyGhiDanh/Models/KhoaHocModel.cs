using System.ComponentModel.DataAnnotations;

namespace QuanLyGhiDanh.Models
{
    public class KhoaHocModel
    {
        [Required]
        public int IdKhoaHoc { get; set; }
        [Required]
        public string? TenKhoaHoc { get; set; }
    }
}
