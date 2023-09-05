using Microsoft.AspNetCore.Identity;
using QuanLyGhiDanh.Models;

namespace QuanLyGhiDanh.Services
{
    public interface IAccountService
    {
        public Task<IdentityResult> DangKiAsync(DangKiModel model);
        public Task<string> DangNhapAsync(DangNhapModel model);
    }
}