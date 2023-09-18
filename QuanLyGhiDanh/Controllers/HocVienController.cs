using Microsoft.AspNetCore.Mvc;
using QuanLyGhiDanh.Interface;
using QuanLyGhiDanh.Models;

namespace QuanLyGhiDanh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HocVienController : ControllerBase
    {
        private readonly IHocVienService _hocvienServ;
        public HocVienController(IHocVienService serv)
        {
            _hocvienServ = serv;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHocVien()
        {
            try
            {
                return Ok(await _hocvienServ.GetAllHocVienByAsync());
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetHocVienByIdAsync(int id)
        {
            var hv = await _hocvienServ.GetHocVienByIdAsync(id);
            return hv == null ? NotFound() : Ok(hv);
        }

        [HttpPost]
        public async Task<IActionResult> AddHocVienAsync(HocVienModel hocvienmodel)
        {
            var newHV = await _hocvienServ.AddHocVienAsync(hocvienmodel);
            var hv = await _hocvienServ.GetHocVienByIdAsync(newHV);
            return gv == null ? NotFound() : Ok(hv);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHocVienAsync(int id, [FromBody] HocVienModel hocvienmodel)
        {
            if (id != hocvienmodel.IdHocVien)
            {
                return NotFound();
            }
            await _hocvienServ.UpdateHocVienAsync(id, hocvienmodel);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHocVienAsync([FromBody] int id)
        {
            await _hocvienServ.DeleteHocVienAsync(id);
            return Ok();
        }
    }
}
