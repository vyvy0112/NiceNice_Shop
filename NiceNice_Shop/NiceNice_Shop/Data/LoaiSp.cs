using System;
using System.Collections.Generic;

namespace NiceNice_Shop.Data;

public partial class LoaiSp
{
    public int MaLoaiSp { get; set; }

    public string TenLoaiSp { get; set; } = null!;

    public int SoLuong { get; set; }

    public int DonGia { get; set; }

    public string? MoTa { get; set; }

    public string? Hinh { get; set; }

    public virtual ICollection<GioHang> GioHangs { get; set; } = new List<GioHang>();

    public virtual ICollection<HangHoa> HangHoas { get; set; } = new List<HangHoa>();
}
