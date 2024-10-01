using System;
using System.Collections.Generic;

namespace NiceNice_Shop.Data;

public partial class GioHang
{
    public string MaGh { get; set; } = null!;

    public int MaLoaiSp { get; set; }

    public string MaKh { get; set; } = null!;

    public int? SoLuong { get; set; }

    public int? DonGia { get; set; }

    public int? TongTien { get; set; }

    public virtual KhachHang MaKhNavigation { get; set; } = null!;

    public virtual LoaiSp MaLoaiSpNavigation { get; set; } = null!;
}
