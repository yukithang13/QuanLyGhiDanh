using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuanLyGhiDanh.Interface;

namespace QuanLyGhiDanh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {


        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public AdminController(IMapper mapper, IUnitOfWork uow)
        {

            _mapper = mapper;
            _uow = uow;
        }


        /*[Authorize(Policy = "AdminRole")]
        [HttpGet]
        public async Task<IActionResult> GetAllGiangVien()
        {
            try
            {
                return Ok(await _uow.GiangVienService.GetAllGiangVienByAsync());
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [Authorize(Policy = "AdminRole")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGiangVienByIdAsync(int id)
        {
            var gv = await _uow.GiangVienService.GetGiangVienByIdAsync(id);
            return gv == null ? NotFound() : Ok(gv);
        }

        [Authorize(Policy = "AdminRole")]
        [HttpGet("page-giang-vien")]
        public async Task<IActionResult> GetGiangVienByPage([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10) // default 1-10 size
        {
            try
            {
                var pagedList = await _uow.GiangVienService.GetGiangVienByPageAsync(pageNumber, pageSize);
                return Ok(pagedList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize(Policy = "AdminRole")]
        [HttpPost]
        public async Task<IActionResult> AddGiangVienAsync(GiangVienModel giangvienmodel)
        {
            var newGV = await _uow.GiangVienService.AddGiangVienAsync(giangvienmodel);
            var gv = await _uow.GiangVienService.GetGiangVienByIdAsync(newGV);
            return gv == null ? NotFound() : Ok(gv);
        }

        [Authorize(Policy = "AdminRole")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGiangVienAsync(int id, [FromBody] GiangVienModel giangvienmodel)
        {
            if (id != giangvienmodel.IdGiangVien)
            {
                return NotFound();
            }
            await _uow.GiangVienService.UpdateGiangVienAsync(id, giangvienmodel);
            return Ok();
        }

        [Authorize(Policy = "AdminRole")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGiangVienAsync([FromBody] int id)
        {
            await _uow.GiangVienService.DeleteGiangVienAsync(id);
            return Ok();
        }

        [Authorize(Policy = "AdminRole")]
        [HttpGet]
        public async Task<IActionResult> GetAllHocVien()
        {
            try
            {
                return Ok(await _uow.HocVienService.GetAllHocVienByAsync());
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [Authorize(Policy = "AdminRole")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHocVienByIdAsync(int id)
        {
            var hv = await _uow.HocVienService.GetHocVienByIdAsync(id);
            return hv == null ? NotFound() : Ok(hv);
        }

        [Authorize(Policy = "AdminRole")]
        [HttpGet("page-hoc-vien")]
        public async Task<IActionResult> GetHocVienByPage([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var pagedList = await _uow.HocVienService.GetHocVienByPageAsync(pageNumber, pageSize);
                return Ok(pagedList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize(Policy = "AdminRole")]
        [HttpPost]
        public async Task<IActionResult> AddHocVienAsync(HocVienModel hocvienmodel)
        {
            var newHV = await _uow.HocVienService.AddHocVienAsync(hocvienmodel);
            var hv = await _uow.HocVienService.GetHocVienByIdAsync(newHV);
            return hv == null ? NotFound() : Ok(hv);
        }

        [Authorize(Policy = "AdminRole")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHocVienAsync(int id, [FromBody] HocVienModel hocvienmodel)
        {
            if (id != hocvienmodel.IdHocVien)
            {
                return NotFound();
            }
            await _uow.HocVienService.UpdateHocVienAsync(id, hocvienmodel);
            return Ok();
        }

        [Authorize(Policy = "AdminRole")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHocVienAsync([FromBody] int id)
        {
            await _uow.HocVienService.DeleteHocVienAsync(id);
            return Ok();
        }

        //Khoa hoc

        [Authorize(Policy = "AdminRole")]
        [HttpGet]
        public async Task<IActionResult> GetAllKhoaHoc()
        {
            try
            {
                return Ok(await _uow.KhoaHocService.GetAllKhoaHocByAsync());
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [Authorize(Policy = "AdminRole")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKhoaHocByIdAsync(int id)
        {
            var kh = await _uow.KhoaHocService.GetKhoaHocByIdAsync(id);
            return kh == null ? NotFound() : Ok(kh);
        }

        [Authorize(Policy = "AdminRole")]
        [HttpGet("page-khoa-hoc")]
        public async Task<IActionResult> GetKhoaHocByPage([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var pagedList = await _uow.KhoaHocService.GetKhoaHocByPageAsync(pageNumber, pageSize);
                return Ok(pagedList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [Authorize(Policy = "AdminRole")]
        [HttpPost]
        public async Task<IActionResult> AddKhoaHocAsync(KhoaHocModel khoahocmodel)
        {
            var newKH = await _uow.KhoaHocService.AddKhoaHocAsync(khoahocmodel);
            var kh = await _uow.KhoaHocService.GetKhoaHocByIdAsync(newKH);
            return kh == null ? NotFound() : Ok(kh);
        }

        [Authorize(Policy = "AdminRole")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKhoaHocAsync(int id, [FromBody] KhoaHocModel khoahocmodel)
        {
            if (id != khoahocmodel.IdKhoaHoc)
            {
                return NotFound();
            }
            await _uow.KhoaHocService.UpdateKhoaHocAsync(id, khoahocmodel);
            return Ok();
        }

        [Authorize(Policy = "AdminRole")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhoaHocAsync([FromBody] int id)
        {
            await _uow.KhoaHocService.DeleteKhoaHocAsync(id);
            return Ok();
        }

        //  lophoc
        [Authorize(Policy = "AdminRole")]
        [HttpGet]
        public async Task<IActionResult> GetAllLopHoc()
        {
            try
            {
                return Ok(await _uow.LopHocService.GetAllLopHocByAsync());
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [Authorize(Policy = "AdminRole")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLopHocByIdAsync(int id)
        {
            var Lop = await _uow.LopHocService.GetLopHocByIdAsync(id);
            return Lop == null ? NotFound() : Ok(Lop);
        }

        [Authorize(Policy = "AdminRole")]
        [HttpGet("page-lop-hoc")]
        public async Task<IActionResult> GetLopHocByPage([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var pagedList = await _uow.LopHocService.GetLopHocByPageAsync(pageNumber, pageSize);
                return Ok(pagedList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize(Policy = "AdminRole")]
        [HttpPost]
        public async Task<IActionResult> AddLopHocAsync(LopHocModel lophocmodel)
        {
            var newLop = await _uow.LopHocService.AddLopHocAsync(lophocmodel);
            var Lop = await _uow.LopHocService.GetLopHocByIdAsync(newLop);
            return Lop == null ? NotFound() : Ok(Lop);
        }

        [Authorize(Policy = "AdminRole")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLopHocAsync(int id, [FromBody] LopHocModel lophocmodel)
        {
            if (id != lophocmodel.IdLopHoc)
            {
                return NotFound();
            }
            await _uow.LopHocService.UpdateLopHocAsync(id, lophocmodel);
            return Ok();
        }

        [Authorize(Policy = "AdminRole")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLopHocAsync([FromBody] int id)
        {
            await _uow.LopHocService.DeleteLopHocAsync(id);
            return Ok();
        }

        // monhoc

        [Authorize(Policy = "AdminRole")]
        [HttpGet]
        public async Task<IActionResult> GetAllMonHoc()
        {
            try
            {
                return Ok(await _uow.IMonHocService.GetAllMonHocByAsync());
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [Authorize(Policy = "AdminRole")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMonHocByIdAsync(int id)
        {
            var Mon = await _uow.IMonHocService.GetMonHocByIdAsync(id);
            return Mon == null ? NotFound() : Ok(Mon);
        }

        [Authorize(Policy = "AdminRole")]
        [HttpGet("page-mon-hoc")]
        public async Task<IActionResult> GetMonHocByPage([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var pagedList = await _uow.IMonHocService.GetMonHocByPageAsync(pageNumber, pageSize);
                return Ok(pagedList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize(Policy = "AdminRole")]
        [HttpPost]
        public async Task<IActionResult> AddMonHocAsync(MonHocModel monhocmodel)
        {
            var newMon = await _uow.IMonHocService.AddMonHocAsync(monhocmodel);
            var Mon = await _uow.IMonHocService.GetMonHocByIdAsync(newMon);
            return Mon == null ? NotFound() : Ok(Mon);
        }

        [Authorize(Policy = "AdminRole")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMonHocAsync(int id, [FromBody] MonHocModel monhocmodel)
        {
            if (id != monhocmodel.IdMonHoc)
            {
                return NotFound();
            }
            await _uow.IMonHocService.UpdateMonHocAsync(id, monhocmodel);
            return Ok();
        }

        [Authorize(Policy = "AdminRole")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMonHocAsync([FromBody] int id)
        {
            await _uow.IMonHocService.DeleteMonHocAsync(id);
            return Ok();
        }

        // nhom bo mon
        [Authorize(Policy = "AdminRole")]
        [HttpGet]
        public async Task<IActionResult> GetAllNhomBoMon()
        {
            try
            {
                return Ok(await _uow.NhomBoMonService.GetAllNhomBoMonByAsync());
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [Authorize(Policy = "AdminRole")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNhomBoMonByIdAsync(int id)
        {
            var BoMon = await _uow.NhomBoMonService.GetNhomBoMonByIdAsync(id);
            return BoMon == null ? NotFound() : Ok(BoMon);
        }

        [Authorize(Policy = "AdminRole")]
        [HttpGet("page-nhom-bo-mon")]
        public async Task<IActionResult> GetNhomBoMonByPage([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var pagedList = await _uow.NhomBoMonService.GetNhomBoMonByPageAsync(pageNumber, pageSize);
                return Ok(pagedList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize(Policy = "AdminRole")]
        [HttpPost]
        public async Task<IActionResult> AddNhomBoMonAsync(NhomBoMonModel nhombomonmodel)
        {
            var newBoMon = await _uow.NhomBoMonService.AddNhomBoMonAsync(nhombomonmodel);
            var BoMon = await _uow.NhomBoMonService.GetNhomBoMonByIdAsync(newBoMon);
            return BoMon == null ? NotFound() : Ok(BoMon);
        }

        [Authorize(Policy = "AdminRole")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNhomBoMonAsync(int id, [FromBody] NhomBoMonModel nhombomonmodel)
        {
            if (id != nhombomonmodel.IdNhomBoMon)
            {
                return NotFound();
            }
            await _uow.NhomBoMonService.UpdateNhomBoMonAsync(id, nhombomonmodel);
            return Ok();
        }

        [Authorize(Policy = "AdminRole")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNhomBoMonAsync([FromBody] int id)
        {
            await _uow.NhomBoMonService.DeleteNhomBoMonAsync(id);
            return Ok();
        }*/

    }
}
