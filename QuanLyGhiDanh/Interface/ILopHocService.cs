using PhanMemGhiDanh.Data;
using QuanLyGhiDanh.Helpers;
using QuanLyGhiDanh.Models;

namespace QuanLyGhiDanh.Interface
{
    public interface ILopHocService
    {
        Task<LopHocModel> GetLopHocByIdAsync(int id);
        Task<List<LopHocModel>> GetAllLopHocByAsync();
        Task<PagedList<LopHoc>> GetLopHocByPageAsync(int pageNumber, int pageSize);
        Task<PagedList<LopHoc>> FindLopHocByPageAsync(int pageNumber, int pageSize, string searchString);
        Task<int> AddLopHocAsync(LopHocModel lophocmodel);
        Task DeleteLopHocAsync(int id);
        Task UpdateLopHocAsync(int id, LopHocModel lophocmodel);
    }
}
