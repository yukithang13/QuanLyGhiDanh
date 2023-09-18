﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PhanMemGhiDanh.Data;
using QuanLyGhiDanh.Interface;
using QuanLyGhiDanh.Models;
namespace QuanLyGhiDanh.Services
{
    public class KhoaHocService : IKhoaHocService
    {
        private readonly GhiDanhDbContext _dbcontext;
        private readonly IMapper _mapper;

        public KhoaHocService(GhiDanhDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }


        // get 1 id
        public async Task<KhoaHocModel> GetKhoaHocByIdAsync(int id)
        {
            var kh = await _dbcontext.Khoahocs!.FindAsync(id);
            return _mapper.Map<KhoaHocModel>(kh);
        }

        // get all

        public async Task<List<KhoaHocModel>> GetAllKhoaHocByAsync()
        {
            var khs = await _dbcontext.Khoahocs.ToListAsync();
            return _mapper.Map<List<KhoaHocModel>>(khs);
        }

        // add
        public async Task<int> AddKhoaHocAsync(KhoaHocModel khoahocmodel)
        {
            var newKH = _mapper.Map<KhoaHoc>(khoahocmodel);
            _dbcontext.Khoahocs.Add(newKH);
            await _dbcontext.SaveChangesAsync();

            return newKH.IdKhoaHoc;
        }
        //update
        public async Task UpdateKhoaHocAsync(int id, KhoaHocModel khoahocmodel)
        {
            if (id == khoahocmodel.IdKhoaHoc)
            {
                var updateKH = _mapper.Map<KhoaHoc>(khoahocmodel);
                _dbcontext.Khoahocs.Update(updateKH);
                await _dbcontext.SaveChangesAsync();
            }
        }


        // delete
        public async Task DeleteKhoaHocAsync(int id)
        {
            var deleteKH = _dbcontext.Khoahocs.SingleOrDefault(g => g.IdKhoaHoc == id);
            if (deleteKH != null)
            {
                _dbcontext.Khoahocs.Remove(deleteKH);
                await _dbcontext.SaveChangesAsync();
            }
        }
    }
}
