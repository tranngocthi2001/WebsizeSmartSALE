using System;
using System.Collections.Generic;

namespace DEMOwebAPI.Entities;

public partial class Danhmuc
{
    public int Id { get; set; }

    public string TenDanhMuc { get; set; } = null!;

    public string? MoTa { get; set; }

    public DateTime NgayTao { get; set; }

    public DateTime NgayCapNhat { get; set; }

    public short TrangThai { get; set; }
}
