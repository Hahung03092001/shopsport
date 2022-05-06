using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace web_baiTapLon.data
{
    public partial class dataproducts : DbContext
    {
        public dataproducts()
            : base("name=dataproducts")
        {
        }

        public virtual DbSet<dtChiTietHDB> dtChiTietHDBs { get; set; }
        public virtual DbSet<dtHoaDonBan> dtHoaDonBans { get; set; }
        public virtual DbSet<dtKhachHang> dtKhachHangs { get; set; }
        public virtual DbSet<dtLoai> dtLoais { get; set; }
        public virtual DbSet<dtNhanVien> dtNhanViens { get; set; }
        public virtual DbSet<dtSanPham> dtSanPhams { get; set; }
        public virtual DbSet<dtUser> dtUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<dtChiTietHDB>()
                .Property(e => e.ThanhTien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<dtHoaDonBan>()
                .Property(e => e.TongTien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<dtHoaDonBan>()
                .HasMany(e => e.dtChiTietHDBs)
                .WithRequired(e => e.dtHoaDonBan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<dtSanPham>()
                .Property(e => e.DonGiaBan)
                .HasPrecision(19, 4);

            modelBuilder.Entity<dtSanPham>()
                .HasMany(e => e.dtChiTietHDBs)
                .WithRequired(e => e.dtSanPham)
                .WillCascadeOnDelete(false);
        }
    }
}
