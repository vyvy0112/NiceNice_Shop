using System;
using System.Collections.Generic;

namespace NiceNice_Shop.Data;

public partial class HangHoa
{
    public int MaHh { get; set; }

    public string TenHh { get; set; } = null!;

    public int MaLoaiSp { get; set; }

    public string? MoTa { get; set; }

    public double? Dongia { get; set; }

    public string? Hinh { get; set; }

    public DateTime NgaySx { get; set; }

    public double GiamGia { get; set; }

    public virtual ICollection<ChiTietHd> ChiTietHds { get; set; } = new List<ChiTietHd>();

    public virtual LoaiSp MaLoaiSpNavigation { get; set; } = null!;
}
