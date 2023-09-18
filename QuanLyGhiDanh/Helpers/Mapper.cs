using AutoMapper;
using PhanMemGhiDanh.Data;
using QuanLyGhiDanh.Models;

namespace QuanLyGhiDanh.Helpers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<GiangVien, GiangVienModel>().ReverseMap(); ;
        }
    }
}
