using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhanMemGhiDanh.Data
{

    public class LopHoc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLopHoc { get; set; }
        public string? TenLop { get; set; }
        public string? MonHoc { get; set; }
        public string? GiangvienPhuTrach { get; set; }
        public DateTime NgayHoc { get; set; }
        public string? GioHoc { get; set; }
        public string? BatDauKetThuc { get; set; }
        public int HocPhi { get; set; }

        public int IdHocVien { get; set; }
        public HocVien? HocVien { get; set; }

    }
}
