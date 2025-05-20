using System;
using System.Collections.Generic;

namespace DEMOwebAPI.Entities;

public partial class SanphamHasSukien
{
    public int SukienId { get; set; }

    public int SanphamId { get; set; }

    public virtual Sukien Sukien { get; set; } = null!;
}
