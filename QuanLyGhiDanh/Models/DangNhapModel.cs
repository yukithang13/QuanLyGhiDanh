using System.ComponentModel.DataAnnotations;

namespace QuanLyGhiDanh.Models
{
    public class DangNhapModel
    {
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
