using Microsoft.AspNetCore.Mvc;
using QuanLyGhiDanh.Interface;
using QuanLyGhiDanh.Models;

namespace QuanLyGhiDanh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonHocController : ControllerBase
    {
        private readonly IMonHocService _monhocServ;
        public MonHocController(IMonHocService serv)
        {
            _monhocServ = serv;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMonHoc()
        {
            try
            {
                return Ok(await _monhocServ.GetAllMonHocByAsync());
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetMonHocByIdAsync(int id)
        {
            var Mon = await _monhocServ.GetMonHocByIdAsync(id);
            return Mon == null ? NotFound() : Ok(Mon);
        }

        [HttpPost]
        public async Task<IActionResult> AddMonHocAsync(MonHocModel monhocmodel)
        {
            var newMon = await _monhocServ.AddMonHocAsync(monhocmodel);
            var Mon = await _monhocServ.GetMonHocByIdAsync(newMon);
            return Mon == null ? NotFound() : Ok(Mon);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMonHocAsync(int id, [FromBody] MonHocModel monhocmodel)
        {
            if (id != monhocmodel.IdMonHoc)
            {
                return NotFound();
            }
            await _monhocServ.UpdateMonHocAsync(id, monhocmodel);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMonHocAsync([FromBody] int id)
        {
            await _monhocServ.DeleteMonHocAsync(id);
            return Ok();
        }
    }
}
