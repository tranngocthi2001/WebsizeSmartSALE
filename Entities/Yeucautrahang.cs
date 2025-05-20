using System;
using System.Collections.Generic;

namespace DEMOwebAPI.Entities;

public partial class Yeucautrahang
{
    public int Id { get; set; }

    public DateTime? NgayYeuCau { get; set; }

    public string? LyDo { get; set; }

    public short? TrangThai { get; set; }

    public int? SoLuongTra { get; set; }

    public decimal? GiaTriTra { get; set; }

    public decimal? SoTienHoanTra { get; set; }

    public DateTime? NgayHoanTien { get; set; }

    public virtual ICollection<Chitietphieuxuat> Chitietphieuxuats { get; set; } = new List<Chitietphieuxuat>();

    public virtual ICollection<Chitiettrahang> Chitiettrahangs { get; set; } = new List<Chitiettrahang>();

    public virtual ICollection<Seri> Seris { get; set; } = new List<Seri>();
}
