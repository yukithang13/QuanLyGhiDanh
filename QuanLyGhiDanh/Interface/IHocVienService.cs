using QuanLyGhiDanh.Models;

namespace QuanLyGhiDanh.Interface
{
    public interface IHocVienService
    {
        Task<HocVienModel> GetHocVienByIdAsync(int id);
        Task<List<HocVienModel>> GetAllHocVienByAsync();
        Task<int> AddHocVienAsync(HocVienModel hocvienmodel);
        Task DeleteHocVienAsync(int id);
        Task UpdateHocVienAsync(int id, HocVienModel hocvienmodel);
    }
}
