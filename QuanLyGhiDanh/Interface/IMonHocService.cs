using PhanMemGhiDanh.Data;
using QuanLyGhiDanh.Helpers;
using QuanLyGhiDanh.Models;

namespace QuanLyGhiDanh.Interface
{
    public interface IMonHocService
    {
        Task<MonHocModel> GetMonHocByIdAsync(int id);
        Task<List<MonHocModel>> GetAllMonHocByAsync();
        Task<PagedList<Monhoc>> GetMonHocByPageAsync(int pageNumber, int pageSize);
        Task<int> AddMonHocAsync(MonHocModel monhocmodel);
        Task DeleteMonHocAsync(int id);
        Task UpdateMonHocAsync(int id, MonHocModel monhocmodel);
    }
}
