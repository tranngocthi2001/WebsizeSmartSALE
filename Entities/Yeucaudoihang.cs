using System;
using System.Collections.Generic;

namespace DEMOwebAPI.Entities;

public partial class Yeucaudoihang
{
    public int Id { get; set; }

    public DateTime NgayYeuCau { get; set; }

    public short TrangThai { get; set; }

    public string LyDo { get; set; } = null!;

    public virtual ICollection<Chitietphieuxuat> Chitietphieuxuats { get; set; } = new List<Chitietphieuxuat>();

    public virtual ICollection<Seri> Seris { get; set; } = new List<Seri>();
}
