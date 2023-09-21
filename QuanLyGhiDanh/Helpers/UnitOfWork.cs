
using AutoMapper;
using PhanMemGhiDanh.Data;
using QuanLyGhiDanh.Interface;
using QuanLyGhiDanh.Services;

namespace QuanLyGhiDanh.Helpers
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GhiDanhDbContext _dbcontext;
        private readonly IMapper _mapper;
        public UnitOfWork(GhiDanhDbContext dbcontext, IMapper mapper)
        {
            _mapper = mapper;
            _dbcontext = dbcontext;
        }
        public IGiangVienService GiangVienService => new GiangVienService(_dbcontext, _mapper);

        public IHocVienService HocVienService => new HocVienService(_dbcontext, _mapper);
        public IKhoaHocService KhoaHocService => new KhoaHocService(_dbcontext, _mapper);
        public ILopHocService LopHocService => new LopHocService(_dbcontext, _mapper);
        public IMonHocService MonHocService => new MonHocService(_dbcontext, _mapper);

        public INhomBoMonService NhomBoMonService => new NhomBoMonService(_dbcontext, _mapper);

        public IAccountService AccountService => throw new NotImplementedException();

        public IMonHocService IMonHocService => throw new NotImplementedException();

        public async Task<bool> Complete()
        {
            return await _dbcontext.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _dbcontext.ChangeTracker.HasChanges();
        }
    }
}
