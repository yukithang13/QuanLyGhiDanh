using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PhanMemGhiDanh.Data
{
    public class GhiDanhDbContext : IdentityDbContext<User>
    {
        public GhiDanhDbContext(DbContextOptions<GhiDanhDbContext> opt) : base(opt)
        {

        }


        public virtual DbSet<GiangVien> Giangviens { get; set; }
        public virtual DbSet<HocVien> HocViens { get; set; }
        public virtual DbSet<KhoaHoc> Khoahocs { get; set; }
        public virtual DbSet<LopHoc> LopHocs { get; set; }
        public virtual DbSet<Monhoc> Monhocs { get; set; }
        public virtual DbSet<NhomBoMon> NhomBoMons { get; set; }

    }
}
