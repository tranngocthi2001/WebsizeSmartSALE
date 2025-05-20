using System;
using System.Collections.Generic;

namespace DEMOwebAPI.Entities;

public partial class Chitietphieuxuat
{
    public int Id { get; set; }

    public int SoLuong { get; set; }

    public DateTime BaoHanh { get; set; }

    public string GhiChu { get; set; } = null!;

    public int ChitietdonhangId { get; set; }

    public int PhieuxuathangId { get; set; }

    public int? YeucautrahangId { get; set; }

    public int? YeucaudoihangId { get; set; }

    public virtual Chitietdonhang Chitietdonhang { get; set; } = null!;

    public virtual Phieuxuathang Phieuxuathang { get; set; } = null!;

    public virtual ICollection<Seri> Seris { get; set; } = new List<Seri>();

    public virtual Yeucaudoihang? Yeucaudoihang { get; set; }

    public virtual Yeucautrahang? Yeucautrahang { get; set; }
}
