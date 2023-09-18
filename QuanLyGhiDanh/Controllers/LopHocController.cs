using Microsoft.AspNetCore.Mvc;
using QuanLyGhiDanh.Interface;
using QuanLyGhiDanh.Models;

namespace QuanLyGhiDanh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LopHocController : ControllerBase
    {
        private readonly ILopHocService _lophocServ;
        public LopHocController(ILopHocService serv)
        {
            _lophocServ = serv;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLopHoc()
        {
            try
            {
                return Ok(await _lophocServ.GetAllLopHocByAsync());
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetLopHocByIdAsync(int id)
        {
            var Lop = await _lophocServ.GetLopHocByIdAsync(id);
            return Lop == null ? NotFound() : Ok(Lop);
        }

        [HttpPost]
        public async Task<IActionResult> AddLopHocAsync(LopHocModel lophocmodel)
        {
            var newLop = await _lophocServ.AddLopHocAsync(lophocmodel);
            var Lop = await _lophocServ.GetLopHocByIdAsync(newLop);
            return Lop == null ? NotFound() : Ok(Lop);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLopHocAsync(int id, [FromBody] LopHocModel lophocmodel)
        {
            if (id != lophocmodel.IdLopHoc)
            {
                return NotFound();
            }
            await _lophocServ.UpdateLopHocAsync(id, lophocmodel);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLopHocAsync([FromBody] int id)
        {
            await _lophocServ.DeleteLopHocAsync(id);
            return Ok();
        }
    }
}
