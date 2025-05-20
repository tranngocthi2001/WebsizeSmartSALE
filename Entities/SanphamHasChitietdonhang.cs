using System;
using System.Collections.Generic;

namespace DEMOwebAPI.Entities;

public partial class SanphamHasChitietdonhang
{
    public int SoLuong { get; set; }

    public int ChitietdonhangId { get; set; }

    public int SanphamId { get; set; }

    public virtual Chitietdonhang Chitietdonhang { get; set; } = null!;
}
