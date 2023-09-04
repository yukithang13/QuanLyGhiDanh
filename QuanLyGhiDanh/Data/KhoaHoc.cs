using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhanMemGhiDanh.Data
{

    public class KhoaHoc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdKhoaHoc { get; set; }
        public string? TenKhoaHoc { get; set; }
    }
}
