using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PhanMemGhiDanh.Data;
using QuanLyGhiDanh.Helpers;
using QuanLyGhiDanh.Interface;
using QuanLyGhiDanh.Models;

namespace QuanLyGhiDanh.Services
{
    public class GiangVienService : IGiangVienService
    {
        private readonly GhiDanhDbContext _dbcontext;
        private readonly IMapper _mapper;

        public GiangVienService(GhiDanhDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }



        // get 1 id
        public async Task<GiangVienModel> GetGiangVienByIdAsync(int id)
        {
            var gv = await _dbcontext.Giangviens!.FindAsync(id);
            return _mapper.Map<GiangVienModel>(gv);
        }

        // get all

        public async Task<List<GiangVienModel>> GetAllGiangVienByAsync()
        {
            var gvs = await _dbcontext.Giangviens.ToListAsync();
            return _mapper.Map<List<GiangVienModel>>(gvs);
        }

        // Page
        public async Task<PagedList<GiangVien>> GetGiangVienByPageAsync(int pageNumber, int pageSize)
        {
            var query = _dbcontext.Giangviens.AsQueryable();

            var pagedList = await PagedList<GiangVien>.CreateAsync((IQueryable<GiangVien>)query, pageNumber, pageSize);

            return pagedList;
        }


        // add
        public async Task<int> AddGiangVienAsync(GiangVienModel giangvienmodel)
        {
            var newGV = _mapper.Map<GiangVien>(giangvienmodel);
            _dbcontext.Giangviens.Add(newGV);
            await _dbcontext.SaveChangesAsync();

            return newGV.IdGiangVien;
        }
        //update
        public async Task UpdateGiangVienAsync(int id, GiangVienModel giangvienmodel)
        {
            if (id == giangvienmodel.IdGiangVien)
            {
                var updateGV = _mapper.Map<GiangVien>(giangvienmodel);
                _dbcontext.Giangviens.Update(updateGV);
                await _dbcontext.SaveChangesAsync();
            }
        }


        // delete
        public async Task DeleteGiangVienAsync(int id)
        {
            var deleteGv = _dbcontext.Giangviens.SingleOrDefault(g => g.IdGiangVien == id);
            if (deleteGv != null)
            {
                _dbcontext.Giangviens.Remove(deleteGv);
                await _dbcontext.SaveChangesAsync();
            }
        }

    }
}
