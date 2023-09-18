using System.ComponentModel.DataAnnotations;

namespace QuanLyGhiDanh.Models
{
    public class LopHocModel
    {
        [Required]
        public int IdLopHoc { get; set; }
        [Required]
        public string? TenLop { get; set; }
        [Required]
        public string? MonHoc { get; set; }
        [Required]
        public string? GiangvienPhuTrach { get; set; }
        [Required]
        public DateTime NgayHoc { get; set; }
        [Required]
        public string? GioHoc { get; set; }
        [Required]
        public string? BatDauKetThuc { get; set; }
        [Required]
        public int HocPhi { get; set; }

        [Required(ErrorMessage = "Yeu Cau Co Hoc Vien")]
        public string? HocVien { get; set; }
    }
}
