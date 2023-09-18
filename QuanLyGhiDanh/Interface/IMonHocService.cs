using QuanLyGhiDanh.Models;

namespace QuanLyGhiDanh.Interface
{
    public interface IMonHocService
    {
        Task<MonHocModel> GetMonHocByIdAsync(int id);
        Task<List<MonHocModel>> GetAllMonHocByAsync();
        Task<int> AddMonHocAsync(MonHocModel monhocmodel);
        Task DeleteMonHocAsync(int id);
        Task UpdateMonHocAsync(int id, MonHocModel monhocmodel);
    }
}
