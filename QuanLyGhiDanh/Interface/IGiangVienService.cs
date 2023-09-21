using PhanMemGhiDanh.Data;
using QuanLyGhiDanh.Helpers;
using QuanLyGhiDanh.Models;

namespace QuanLyGhiDanh.Interface
{
    public interface IGiangVienService
    {

        Task<GiangVienModel> GetGiangVienByIdAsync(int id);
        Task<List<GiangVienModel>> GetAllGiangVienByAsync();
        Task<PagedList<GiangVien>> GetGiangVienByPageAsync(int pageNumber, int pageSize);
        Task<int> AddGiangVienAsync(GiangVienModel giangvienmodel);
        Task DeleteGiangVienAsync(int id);
        Task UpdateGiangVienAsync(int id, GiangVienModel giangvienmodel);


    }
}
