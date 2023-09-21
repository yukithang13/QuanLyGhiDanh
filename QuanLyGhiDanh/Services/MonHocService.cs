using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PhanMemGhiDanh.Data;
using QuanLyGhiDanh.Helpers;
using QuanLyGhiDanh.Interface;
using QuanLyGhiDanh.Models;

namespace QuanLyGhiDanh.Services
{
    public class MonHocService : IMonHocService
    {
        private readonly GhiDanhDbContext _dbcontext;
        private readonly IMapper _mapper;

        public MonHocService(GhiDanhDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }


        // get 1 id
        public async Task<MonHocModel> GetMonHocByIdAsync(int id)
        {
            var monhoc = await _dbcontext.Monhocs!.FindAsync(id);
            return _mapper.Map<MonHocModel>(monhoc);
        }

        // get all

        public async Task<List<MonHocModel>> GetAllMonHocByAsync()
        {
            var AllMon = await _dbcontext.Monhocs.ToListAsync();
            return _mapper.Map<List<MonHocModel>>(AllMon);
        }

        //page
        public async Task<PagedList<Monhoc>> GetMonHocByPageAsync(int pageNumber, int pageSize)
        {
            var query = _dbcontext.Monhocs.AsQueryable();

            var pagedList = await PagedList<Monhoc>.CreateAsync((IQueryable<Monhoc>)query, pageNumber, pageSize);

            return pagedList;
        }

        // add
        public async Task<int> AddMonHocAsync(MonHocModel monhocmodel)
        {
            var newMonHoc = _mapper.Map<Monhoc>(monhocmodel);
            _dbcontext.Monhocs.Add(newMonHoc);
            await _dbcontext.SaveChangesAsync();

            return newMonHoc.IdMonHoc;
        }
        //update
        public async Task UpdateMonHocAsync(int id, MonHocModel monhocmodel)
        {
            if (id == monhocmodel.IdMonHoc)
            {
                var updateMon = _mapper.Map<Monhoc>(monhocmodel);
                _dbcontext.Monhocs.Update(updateMon);
                await _dbcontext.SaveChangesAsync();
            }
        }


        // delete
        public async Task DeleteMonHocAsync(int id)
        {
            var deleteMon = _dbcontext.Monhocs.SingleOrDefault(g => g.IdMonHoc == id);
            if (deleteMon != null)
            {
                _dbcontext.Monhocs.Remove(deleteMon);
                await _dbcontext.SaveChangesAsync();
            }
        }
    }
}
