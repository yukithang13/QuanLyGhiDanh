using Microsoft.AspNetCore.Mvc;
using QuanLyGhiDanh.Interface;
using QuanLyGhiDanh.Models;

namespace QuanLyGhiDanh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountServ;
        public AccountController(IAccountService serv)
        {
            accountServ = serv;
        }

        [HttpPost("DangKi")]
        public async Task<IActionResult> SignUp(DangKiModel signup)
        {
            var result = await accountServ.DangKiAsync(signup);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            return Unauthorized();
        }

        [HttpPost("DangNhap")]
        public async Task<IActionResult> SignIn(DangNhapModel signin)
        {
            var result = await accountServ.DangNhapAsync(signin);

            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }

            return Ok(result);
        }
    }
}
