using PhanMemGhiDanh.Data;
using QuanLyGhiDanh.Helpers;
using QuanLyGhiDanh.Models;

namespace QuanLyGhiDanh.Interface
{
    public interface IHocVienService
    {
        Task<HocVienModel> GetHocVienByIdAsync(int id);
        Task<List<HocVienModel>> GetAllHocVienByAsync();
        Task<PagedList<HocVien>> GetHocVienByPageAsync(int pageNumber, int pageSize);
        Task<PagedList<HocVien>> FindHocVienByPageAsync(int pageNumber, int pageSize, string searchString);
        Task<int> AddHocVienAsync(HocVienModel hocvienmodel);
        Task DeleteHocVienAsync(int id);
        Task UpdateHocVienAsync(int id, HocVienModel hocvienmodel);
    }
}
