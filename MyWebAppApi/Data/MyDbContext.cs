using Microsoft.EntityFrameworkCore;

namespace MyWebAppApi.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }


        //Để map thành database
        #region DbSet
        public DbSet<HangHoa> HangHoas { get; set;}
        public DbSet<Loai> Loais { get; set;}
        public DbSet<DonHangChiTiet> DonHangs { get; set;}
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>(e =>
            {
                e.ToTable("DonHang");
                e.HasKey(dh => dh.MaDonHang);
                e.Property(dh => dh.NgayDat).HasDefaultValueSql("getutcdate()");
                e.Property(dh => dh.NguoiNhanHang).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<DonHangChiTiet>(entity =>
            {
                entity.ToTable("ChiTietDonHang");
                entity.HasKey(e => new {e.MaDonHang, e.MaHangHoa});

                entity.HasOne(e => e.DonHang)
                .WithMany(e => e.DonHangChiTiets)
                .HasForeignKey(e => e.MaDonHang)
                .HasConstraintName("FK_DonHangCT_DonHang");

                entity.HasOne(e => e.HangHoa)
                .WithMany(e => e.DonHangChiTiets)
                .HasForeignKey(e => e.MaDonHang)
                .HasConstraintName("FK_DonHangCT_HangHoa");
            });
        }
    }
}
