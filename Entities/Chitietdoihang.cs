using System;
using System.Collections.Generic;

namespace DEMOwebAPI.Entities;

public partial class Chitietdoihang
{
    public long Id { get; set; }

    public long YeucaudoihangId { get; set; }

    public int SoLuong { get; set; }

    public string HinhAnh { get; set; } = null!;

    public int SanPhamDoiId { get; set; }
}
