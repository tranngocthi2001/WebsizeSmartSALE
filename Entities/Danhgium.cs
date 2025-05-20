using System;
using System.Collections.Generic;

namespace DEMOwebAPI.Entities;

public partial class Danhgium
{
    public int Id { get; set; }

    public int SoSao { get; set; }

    public string? NoiDung { get; set; }

    public DateTime NgayTao { get; set; }

    public int SanphamId { get; set; }

    public int KhachhangId { get; set; }

    public virtual Khachhang Khachhang { get; set; } = null!;
}
