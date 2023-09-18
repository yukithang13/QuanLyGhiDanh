using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PhanMemGhiDanh.Data;
using QuanLyGhiDanh.Interface;
using QuanLyGhiDanh.Models;

namespace QuanLyGhiDanh.Services
{
    public class LopHocService : ILopHocService
    {
        private readonly GhiDanhDbContext _dbcontext;
        private readonly IMapper _mapper;

        public LopHocService(GhiDanhDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }


        // get 1 id
        public async Task<LopHocModel> GetLopHocByIdAsync(int id)
        {
            var lop = await _dbcontext.LopHocs!.FindAsync(id);
            return _mapper.Map<LopHocModel>(lop);
        }

        // get all

        public async Task<List<LopHocModel>> GetAllLopHocByAsync()
        {
            var AllLop = await _dbcontext.LopHocs.ToListAsync();
            return _mapper.Map<List<LopHocModel>>(AllLop);
        }

        // add
        public async Task<int> AddLopHocAsync(LopHocModel lophocmodel)
        {
            var newLopHoc = _mapper.Map<LopHoc>(lophocmodel);
            _dbcontext.LopHocs.Add(newLopHoc);
            await _dbcontext.SaveChangesAsync();

            return newLopHoc.IdLopHoc;
        }
        //update
        public async Task UpdateLopHocAsync(int id, LopHocModel lophocmodel)
        {
            if (id == lophocmodel.IdLopHoc)
            {
                var updateLop = _mapper.Map<LopHoc>(lophocmodel);
                _dbcontext.LopHocs.Update(updateLop);
                await _dbcontext.SaveChangesAsync();
            }
        }


        // delete
        public async Task DeleteLopHocAsync(int id)
        {
            var deleteLop = _dbcontext.LopHocs.SingleOrDefault(g => g.IdLopHoc == id);
            if (deleteLop != null)
            {
                _dbcontext.LopHocs.Remove(deleteLop);
                await _dbcontext.SaveChangesAsync();
            }
        }
    }
}
