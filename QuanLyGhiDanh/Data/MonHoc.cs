using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhanMemGhiDanh.Data
{

    public class Monhoc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMonHoc { get; set; }
        public string? TenMon { get; set; }
        public int? IdNhomBoMon { get; set; }
        public int? IdKhoaHoc { get; set; }

        public KhoaHoc? Khoahoc { get; set; }
        public NhomBoMon? NhomBoMon { get; set; }
    }
}
