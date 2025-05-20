using System;
using System.Collections.Generic;

namespace DEMOwebAPI.Entities;

public partial class Magiamgium
{
    public int Id { get; set; }

    public float GiaTri { get; set; }

    public DateTime NgayBatDau { get; set; }

    public DateTime NgayKetThuc { get; set; }

    public string TrangThai { get; set; } = null!;

    public int SoLuong { get; set; }

    public int DonhangId { get; set; }

    public virtual Donhang Donhang { get; set; } = null!;
}
