using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PhanMemGhiDanh.Data;
using QuanLyGhiDanh.Interface;
using QuanLyGhiDanh.Models;

namespace QuanLyGhiDanh.Services
{
    public class HocVienService : IHocVienService
    {
        private readonly GhiDanhDbContext _dbcontext;
        private readonly IMapper _mapper;

        public HocVienService(GhiDanhDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }


        // get 1 id
        public async Task<HocVienModel> GetHocVienByIdAsync(int id)
        {
            var hv = await _dbcontext.HocViens!.FindAsync(id);
            return _mapper.Map<HocVienModel>(hv);
        }

        // get all

        public async Task<List<HocVienModel>> GetAllHocVienByAsync()
        {
            var hvs = await _dbcontext.HocViens.ToListAsync();
            return _mapper.Map<List<HocVienModel>>(hvs);
        }

        // add
        public async Task<int> AddHocVienAsync(HocVienModel hocvienmodel)
        {
            var newHV = _mapper.Map<HocVien>(hocvienmodel);
            _dbcontext.HocViens.Add(newHV);
            await _dbcontext.SaveChangesAsync();

            return newHV.IdHocVien;
        }
        //update
        public async Task UpdateHocVienAsync(int id, HocVienModel hocvienmodel)
        {
            if (id == hocvienmodel.IdHocVien)
            {
                var updateHV = _mapper.Map<HocVien>(hocvienmodel);
                _dbcontext.HocViens.Update(updateHV);
                await _dbcontext.SaveChangesAsync();
            }
        }


        // delete
        public async Task DeleteHocVienAsync(int id)
        {
            var deleteHV = _dbcontext.HocViens.SingleOrDefault(g => g.IdHocVien == id);
            if (deleteHV != null)
            {
                _dbcontext.HocViens.Remove(deleteHV);
                await _dbcontext.SaveChangesAsync();
            }
        }
    }
}
