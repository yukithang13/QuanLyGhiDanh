using QuanLyGhiDanh.Models;

namespace QuanLyGhiDanh.Interface
{
    public interface ILopHocService
    {
        Task<LopHocModel> GetLopHocByIdAsync(int id);
        Task<List<LopHocModel>> GetAllLopHocByAsync();
        Task<int> AddLopHocAsync(LopHocModel lophocmodel);
        Task DeleteLopHocAsync(int id);
        Task UpdateLopHocAsync(int id, LopHocModel lophocmodel);
    }
}
