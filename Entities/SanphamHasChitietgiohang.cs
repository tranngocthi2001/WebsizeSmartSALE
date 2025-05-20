using System;
using System.Collections.Generic;

namespace DEMOwebAPI.Entities;

public partial class SanphamHasChitietgiohang
{
    public int? SoLuong { get; set; }

    public int SanphamId { get; set; }

    public int ChitietgiohangId { get; set; }

    public virtual Chitietgiohang Chitietgiohang { get; set; } = null!;
}
