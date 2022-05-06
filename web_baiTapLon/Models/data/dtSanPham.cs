namespace web_baiTapLon.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dtSanPham")]
    public partial class dtSanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dtSanPham()
        {
            dtChiTietHDBs = new HashSet<dtChiTietHDB>();
        }

        [Key]
        [StringLength(10)]
        public string MaSP { get; set; }

        [StringLength(50)]
        public string TenSP { get; set; }

        [StringLength(10)]
        public string MaLoai { get; set; }

        [Column(TypeName = "money")]
        public decimal? DonGiaBan { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(50)]
        public string Img { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dtChiTietHDB> dtChiTietHDBs { get; set; }

        public virtual dtLoai dtLoai { get; set; }
    }
}
