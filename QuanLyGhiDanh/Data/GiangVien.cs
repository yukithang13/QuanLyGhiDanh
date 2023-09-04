using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhanMemGhiDanh.Data
{

    public class GiangVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdGiangVien { get; set; }
        public double Masothue { get; set; }
        public string? HoTenGV { get; set; }
        public string? NgaySinhGV { get; set; }
        public bool GioiTinhGV { get; set; } = false;
        public string? EmailGV { get; set; }
        public string? SoDienThoaiGV { get; set; }
        public string? DiachiGV { get; set; }
        public string? MonGiangDay { get; set; }
    }
}
