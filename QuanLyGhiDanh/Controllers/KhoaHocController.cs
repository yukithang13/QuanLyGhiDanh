﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("page-khoa-hoc")]
        public async Task<IActionResult> GetKhoaHocByPage([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var pagedList = await _khoahocServ.GetKhoaHocByPageAsync(pageNumber, pageSize);
                return Ok(pagedList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("search-khoa-hoc")]
        public async Task<IActionResult> FindKhoaHocByPageAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, string searchString = "") // default 1-10 size
        {
            try
            {
                var pagedList = await _khoahocServ.FindKhoaHocByPageAsync(pageNumber, pageSize, searchString);
                return Ok(pagedList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
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
