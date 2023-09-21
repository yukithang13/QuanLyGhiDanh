using Microsoft.AspNetCore.Mvc;
using QuanLyGhiDanh.Interface;
using QuanLyGhiDanh.Models;

namespace QuanLyGhiDanh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiangVienController : ControllerBase
    {
        private readonly IGiangVienService _giangvienServ;
        public GiangVienController(IGiangVienService serv)
        {
            _giangvienServ = serv;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGiangVien()
        {
            try
            {
                return Ok(await _giangvienServ.GetAllGiangVienByAsync());
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetGiangVienByIdAsync(int id)
        {
            var gv = await _giangvienServ.GetGiangVienByIdAsync(id);
            return gv == null ? NotFound() : Ok(gv);
        }

        [HttpGet("page-giang-vien")]
        public async Task<IActionResult> GetGiangVienByPage([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10) // default 1-10 size
        {
            try
            {
                var pagedList = await _giangvienServ.GetGiangVienByPageAsync(pageNumber, pageSize);
                return Ok(pagedList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddGiangVienAsync(GiangVienModel giangvienmodel)
        {
            var newGV = await _giangvienServ.AddGiangVienAsync(giangvienmodel);
            var gv = await _giangvienServ.GetGiangVienByIdAsync(newGV);
            return gv == null ? NotFound() : Ok(gv);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGiangVienAsync(int id, [FromBody] GiangVienModel giangvienmodel)
        {
            if (id != giangvienmodel.IdGiangVien)
            {
                return NotFound();
            }
            await _giangvienServ.UpdateGiangVienAsync(id, giangvienmodel);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGiangVienAsync([FromBody] int id)
        {
            await _giangvienServ.DeleteGiangVienAsync(id);
            return Ok();
        }
    }
}
