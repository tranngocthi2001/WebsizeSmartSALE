using System;
using System.Collections.Generic;

namespace DEMOwebAPI.Entities;

public partial class Sukien
{
    public int Id { get; set; }

    public string TenSuKien { get; set; } = null!;

    public string MoTaSuKien { get; set; } = null!;

    public DateTime ThoiGianBatDau { get; set; }

    public DateTime ThoiGianKetThuc { get; set; }

    public string LoaiSuKien { get; set; } = null!;

    public short TrangThai { get; set; }
}
