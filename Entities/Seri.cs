using System;
using System.Collections.Generic;

namespace DEMOwebAPI.Entities;

public partial class Seri
{
    public int Id { get; set; }

    public string? MaSeri { get; set; }

    public int ChitietphieuxuatId { get; set; }

    public int? YeucautrahangId { get; set; }

    public int? YeucaudoihangId { get; set; }

    public virtual Chitietphieuxuat Chitietphieuxuat { get; set; } = null!;

    public virtual Yeucaudoihang? Yeucaudoihang { get; set; }

    public virtual Yeucautrahang? Yeucautrahang { get; set; }
}
