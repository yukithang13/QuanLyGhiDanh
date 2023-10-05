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

        [HttpGet("page-hoc-vien")]
        public async Task<IActionResult> GetHocVienByPage([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var pagedList = await _hocvienServ.GetHocVienByPageAsync(pageNumber, pageSize);
                return Ok(pagedList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddHocVienAsync(HocVienModel hocvienmodel)
        {
            var newHV = await _hocvienServ.AddHocVienAsync(hocvienmodel);
            var hv = await _hocvienServ.GetHocVienByIdAsync(newHV);
            return hv == null ? NotFound() : Ok(hv);
        }




        [HttpGet("search-hoc-vien")]
        public async Task<IActionResult> FindHocVienByPageAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, string searchString = "") // default 1-10 size
        {
            try
            {
                var pagedList = await _hocvienServ.FindHocVienByPageAsync(pageNumber, pageSize, searchString);
                return Ok(pagedList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
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
