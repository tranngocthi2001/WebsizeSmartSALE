using System;
using System.Collections.Generic;

namespace DEMOwebAPI.Entities;

public partial class Thongbao
{
    public int Id { get; set; }

    public string? TieuDe { get; set; }

    public string? NoiDung { get; set; }

    public DateTime? NgayTao { get; set; }

    public short? TrangThai { get; set; }
}
