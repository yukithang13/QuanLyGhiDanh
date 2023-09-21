using Microsoft.AspNetCore.Mvc;
using QuanLyGhiDanh.Interface;
using QuanLyGhiDanh.Models;

namespace QuanLyGhiDanh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhomBoMonController : ControllerBase
    {
        private readonly INhomBoMonService _nhombomonServ;
        public NhomBoMonController(INhomBoMonService serv)
        {
            _nhombomonServ = serv;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNhomBoMon()
        {
            try
            {
                return Ok(await _nhombomonServ.GetAllNhomBoMonByAsync());
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetNhomBoMonByIdAsync(int id)
        {
            var BoMon = await _nhombomonServ.GetNhomBoMonByIdAsync(id);
            return BoMon == null ? NotFound() : Ok(BoMon);
        }

        [HttpGet("page-nhom-bo-mon")]
        public async Task<IActionResult> GetNhomBoMonByPage([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var pagedList = await _nhombomonServ.GetNhomBoMonByPageAsync(pageNumber, pageSize);
                return Ok(pagedList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNhomBoMonAsync(NhomBoMonModel nhombomonmodel)
        {
            var newBoMon = await _nhombomonServ.AddNhomBoMonAsync(nhombomonmodel);
            var BoMon = await _nhombomonServ.GetNhomBoMonByIdAsync(newBoMon);
            return BoMon == null ? NotFound() : Ok(BoMon);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNhomBoMonAsync(int id, [FromBody] NhomBoMonModel nhombomonmodel)
        {
            if (id != nhombomonmodel.IdNhomBoMon)
            {
                return NotFound();
            }
            await _nhombomonServ.UpdateNhomBoMonAsync(id, nhombomonmodel);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNhomBoMonAsync([FromBody] int id)
        {
            await _nhombomonServ.DeleteNhomBoMonAsync(id);
            return Ok();
        }
    }
}
