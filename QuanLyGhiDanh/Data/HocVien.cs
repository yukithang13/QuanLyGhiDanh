using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhanMemGhiDanh.Data
{

    public class HocVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHocVien { get; set; }
        public string? TenHV { get; set; }
        public string? NgaySinhHV { get; set; }
        public bool GioiTinhHV { get; set; } = false;
        public string? EmailHV { get; set; }
        public string? DiachiHV { get; set; }
        public string? TenNguoiGiamHo { get; set; }
    }

}
