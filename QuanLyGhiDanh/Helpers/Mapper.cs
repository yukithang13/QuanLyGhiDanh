using AutoMapper;
using PhanMemGhiDanh.Data;
using QuanLyGhiDanh.Models;

namespace QuanLyGhiDanh.Helpers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<GiangVien, GiangVienModel>().ReverseMap();
            CreateMap<HocVien, HocVienModel>().ReverseMap();
            CreateMap<KhoaHoc, KhoaHocModel>().ReverseMap();
            CreateMap<LopHoc, LopHocModel>().ReverseMap();
            CreateMap<Monhoc, MonHocModel>().ReverseMap();
            CreateMap<NhomBoMon, NhomBoMonModel>().ReverseMap();
        }
    }
}
