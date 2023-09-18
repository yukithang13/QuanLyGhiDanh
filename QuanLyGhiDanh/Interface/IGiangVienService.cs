using QuanLyGhiDanh.Models;

namespace QuanLyGhiDanh.Interface
{
    public interface IGiangVienService
    {

        Task<GiangVienModel> GetGiangVienByIdAsync(int id);
        Task<List<GiangVienModel>> GetAllGiangVienByAsync();
        Task<int> AddGiangVienAsync(GiangVienModel giangvienmodel);
        Task DeleteGiangVienAsync(int id);
        Task UpdateGiangVienAsync(int id, GiangVienModel giangvienmodel);
    }
}
