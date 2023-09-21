using PhanMemGhiDanh.Data;
using QuanLyGhiDanh.Helpers;
using QuanLyGhiDanh.Models;

namespace QuanLyGhiDanh.Interface
{
    public interface IAdminService
    {
        // Account
        /*        Task<List<UserModel>> GetAllUserByAsync();
                Task<UserModel> GetUserByIdAsync(int id);
                Task DeleteUsernAsync(int id);
                Task UpdateUserAsync(int id, UserModel usermodel);*/

        // GiangVien
        Task<GiangVienModel> GetGiangVienByIdAsync(int id);
        Task<List<GiangVienModel>> GetAllGiangVienByAsync();
        Task<PagedList<GiangVien>> GetGiangVienByPageAsync(int pageNumber, int pageSize);
        Task<int> AddGiangVienAsync(GiangVienModel giangvienmodel);
        Task DeleteGiangVienAsync(int id);
        Task UpdateGiangVienAsync(int id, GiangVienModel giangvienmodel);

        // HocVien

        Task<HocVienModel> GetHocVienByIdAsync(int id);
        Task<List<HocVienModel>> GetAllHocVienByAsync();
        Task<PagedList<HocVien>> GetHocVienByPageAsync(int pageNumber, int pageSize);
        Task<int> AddHocVienAsync(HocVienModel hocvienmodel);
        Task DeleteHocVienAsync(int id);
        Task UpdateHocVienAsync(int id, HocVienModel hocvienmodel);

        // KhoaHoc

        Task<KhoaHocModel> GetKhoaHocByIdAsync(int id);
        Task<List<KhoaHocModel>> GetAllKhoaHocByAsync();
        Task<PagedList<KhoaHoc>> GetKhoaHocByPageAsync(int pageNumber, int pageSize);
        Task<int> AddKhoaHocAsync(KhoaHocModel khoahocmodel);
        Task DeleteKhoaHocAsync(int id);
        Task UpdateKhoaHocAsync(int id, KhoaHocModel khoahocmodel);

        // LopHoc

        Task<LopHocModel> GetLopHocByIdAsync(int id);
        Task<List<LopHocModel>> GetAllLopHocByAsync();
        Task<PagedList<LopHoc>> GetLopHocByPageAsync(int pageNumber, int pageSize);
        Task<int> AddLopHocAsync(LopHocModel lophocmodel);
        Task DeleteLopHocAsync(int id);
        Task UpdateLopHocAsync(int id, LopHocModel lophocmodel);

        // MonHoc

        Task<MonHocModel> GetMonHocByIdAsync(int id);
        Task<List<MonHocModel>> GetAllMonHocByAsync();
        Task<PagedList<Monhoc>> GetMonHocByPageAsync(int pageNumber, int pageSize);
        Task<int> AddMonHocAsync(MonHocModel monhocmodel);
        Task DeleteMonHocAsync(int id);
        Task UpdateMonHocAsync(int id, MonHocModel monhocmodel);

        // NhomMonHoc

        Task<NhomBoMonModel> GetNhomBoMonByIdAsync(int id);
        Task<List<NhomBoMonModel>> GetAllNhomBoMonByAsync();
        Task<PagedList<NhomBoMon>> GetNhomBoMonByPageAsync(int pageNumber, int pageSize);
        Task<int> AddNhomBoMonAsync(NhomBoMonModel nhombomonmodel);
        Task DeleteNhomBoMonAsync(int id);
        Task UpdateNhomBoMonAsync(int id, NhomBoMonModel nhombomonmodel);
    }
}
