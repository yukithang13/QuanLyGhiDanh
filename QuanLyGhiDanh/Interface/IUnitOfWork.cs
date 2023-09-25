namespace QuanLyGhiDanh.Interface
{
    public interface IUnitOfWork
    {

        IAccountService AccountService { get; }
        IGiangVienService GiangVienService { get; }
        IHocVienService HocVienService { get; }
        IKhoaHocService KhoaHocService { get; }
        ILopHocService LopHocService { get; }
        IMonHocService MonHocService { get; }
        INhomBoMonService NhomBoMonService { get; }


        Task<bool> Complete();
        bool HasChanges();

    }
}
