using System;
using System.Collections.Generic;

namespace DEMOwebAPI.Entities;

public partial class Chitiettrahang
{
    public int Id { get; set; }

    public string HinhAnh { get; set; } = null!;

    public int SoLuong { get; set; }

    public int SanPhamTraId { get; set; }

    public int YeucautrahangId { get; set; }

    public virtual Yeucautrahang Yeucautrahang { get; set; } = null!;
}
