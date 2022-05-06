namespace web_baiTapLon.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dtHoaDonBan")]
    public partial class dtHoaDonBan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dtHoaDonBan()
        {
            dtChiTietHDBs = new HashSet<dtChiTietHDB>();
        }

        [Key]
        [StringLength(25)]
        public string MaHDB { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayBan { get; set; }

        [StringLength(10)]
        public string MaKH { get; set; }

        [Column(TypeName = "money")]
        public decimal? TongTien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dtChiTietHDB> dtChiTietHDBs { get; set; }

        public virtual dtKhachHang dtKhachHang { get; set; }
    }
}
