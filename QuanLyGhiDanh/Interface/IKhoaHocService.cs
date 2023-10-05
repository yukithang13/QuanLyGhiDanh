using PhanMemGhiDanh.Data;
using QuanLyGhiDanh.Helpers;
using QuanLyGhiDanh.Models;

namespace QuanLyGhiDanh.Interface
{
    public interface IKhoaHocService
    {
        Task<KhoaHocModel> GetKhoaHocByIdAsync(int id);
        Task<List<KhoaHocModel>> GetAllKhoaHocByAsync();
        Task<PagedList<KhoaHoc>> GetKhoaHocByPageAsync(int pageNumber, int pageSize);
        Task<PagedList<KhoaHoc>> FindKhoaHocByPageAsync(int pageNumber, int pageSize, string searchString);

        Task<int> AddKhoaHocAsync(KhoaHocModel khoahocmodel);
        Task DeleteKhoaHocAsync(int id);
        Task UpdateKhoaHocAsync(int id, KhoaHocModel khoahocmodel);
    }
}
