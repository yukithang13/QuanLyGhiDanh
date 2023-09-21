using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PhanMemGhiDanh.Data;
using QuanLyGhiDanh.Helpers;
using QuanLyGhiDanh.Interface;
using QuanLyGhiDanh.Models;

namespace QuanLyGhiDanh.Services
{
    public class NhomBoMonService : INhomBoMonService
    {
        private readonly GhiDanhDbContext _dbcontext;
        private readonly IMapper _mapper;

        public NhomBoMonService(GhiDanhDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }


        // get 1 id
        public async Task<NhomBoMonModel> GetNhomBoMonByIdAsync(int id)
        {
            var monhoc = await _dbcontext.NhomBoMons!.FindAsync(id);
            return _mapper.Map<NhomBoMonModel>(monhoc);
        }

        // get all

        public async Task<List<NhomBoMonModel>> GetAllNhomBoMonByAsync()
        {
            var AllNhomMon = await _dbcontext.NhomBoMons.ToListAsync();
            return _mapper.Map<List<NhomBoMonModel>>(AllNhomMon);
        }
        //page
        public async Task<PagedList<NhomBoMon>> GetNhomBoMonByPageAsync(int pageNumber, int pageSize)
        {
            var query = _dbcontext.NhomBoMons.AsQueryable();

            var pagedList = await PagedList<NhomBoMon>.CreateAsync((IQueryable<NhomBoMon>)query, pageNumber, pageSize);

            return pagedList;
        }
        // add
        public async Task<int> AddNhomBoMonAsync(NhomBoMonModel nhombomonmodel)
        {
            var newNhomMon = _mapper.Map<NhomBoMon>(nhombomonmodel);
            _dbcontext.NhomBoMons.Add(newNhomMon);
            await _dbcontext.SaveChangesAsync();

            return newNhomMon.IdNhomBoMon;
        }
        //update
        public async Task UpdateNhomBoMonAsync(int id, NhomBoMonModel nhombomonmodel)
        {
            if (id == nhombomonmodel.IdNhomBoMon)
            {
                var updateMon = _mapper.Map<NhomBoMon>(nhombomonmodel);
                _dbcontext.NhomBoMons.Update(updateMon);
                await _dbcontext.SaveChangesAsync();
            }
        }


        // delete
        public async Task DeleteNhomBoMonAsync(int id)
        {
            var deleteNhomMon = _dbcontext.NhomBoMons.SingleOrDefault(g => g.IdNhomBoMon == id);
            if (deleteNhomMon != null)
            {
                _dbcontext.NhomBoMons.Remove(deleteNhomMon);
                await _dbcontext.SaveChangesAsync();
            }
        }
    }
}
