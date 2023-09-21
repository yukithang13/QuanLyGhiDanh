using PhanMemGhiDanh.Data;
using QuanLyGhiDanh.Helpers;
using QuanLyGhiDanh.Models;

namespace QuanLyGhiDanh.Interface
{
    public interface INhomBoMonService
    {
        Task<NhomBoMonModel> GetNhomBoMonByIdAsync(int id);
        Task<List<NhomBoMonModel>> GetAllNhomBoMonByAsync();
        Task<PagedList<NhomBoMon>> GetNhomBoMonByPageAsync(int pageNumber, int pageSize);
        Task<int> AddNhomBoMonAsync(NhomBoMonModel nhombomonmodel);
        Task DeleteNhomBoMonAsync(int id);
        Task UpdateNhomBoMonAsync(int id, NhomBoMonModel nhombomonmodel);
    }
}
