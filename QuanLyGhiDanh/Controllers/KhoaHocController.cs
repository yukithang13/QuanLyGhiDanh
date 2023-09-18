using Microsoft.AspNetCore.Mvc;
using QuanLyGhiDanh.Interface;
using QuanLyGhiDanh.Models;

namespace QuanLyGhiDanh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhoaHocController : ControllerBase
    {
        private readonly IKhoaHocService _khoahocServ;
        public KhoaHocController(IKhoaHocService serv)
        {
            _khoahocServ = serv;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllKhoaHoc()
        {
            try
            {
                return Ok(await _khoahocServ.GetAllKhoaHocByAsync());
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetKhoaHocByIdAsync(int id)
        {
            var kh = await _khoahocServ.GetKhoaHocByIdAsync(id);
            return kh == null ? NotFound() : Ok(kh);
        }

        [HttpPost]
        public async Task<IActionResult> AddKhoaHocAsync(KhoaHocModel khoahocmodel)
        {
            var newKH = await _khoahocServ.AddKhoaHocAsync(khoahocmodel);
            var kh = await _khoahocServ.GetKhoaHocByIdAsync(newKH);
            return kh == null ? NotFound() : Ok(kh);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKhoaHocAsync(int id, [FromBody] KhoaHocModel khoahocmodel)
        {
            if (id != khoahocmodel.IdKhoaHoc)
            {
                return NotFound();
            }
            await _khoahocServ.UpdateKhoaHocAsync(id, khoahocmodel);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhoaHocAsync([FromBody] int id)
        {
            await _khoahocServ.DeleteKhoaHocAsync(id);
            return Ok();
        }
    }
}
