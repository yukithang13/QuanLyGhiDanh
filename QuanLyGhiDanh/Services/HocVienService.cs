﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PhanMemGhiDanh.Data;
using QuanLyGhiDanh.Helpers;
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

        //page
        public async Task<PagedList<HocVien>> GetHocVienByPageAsync(int pageNumber, int pageSize)
        {
            var query = _dbcontext.HocViens.AsQueryable();

            var pagedList = await PagedList<HocVien>.CreateAsync((IQueryable<HocVien>)query, pageNumber, pageSize);

            return pagedList;
        }

        // search
        public async Task<PagedList<HocVien>> FindHocVienByPageAsync(int pageNumber, int pageSize, string searchString = "")
        {
            var query = _dbcontext.HocViens.AsQueryable();


            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(g => g.TenHV.Contains(searchString) || g.TenNguoiGiamHo.Contains(searchString));
            }

            var pagedList = await PagedList<HocVien>.CreateAsync(query, pageNumber, pageSize);

            return pagedList;
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
