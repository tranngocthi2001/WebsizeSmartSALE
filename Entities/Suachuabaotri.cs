using System;
using System.Collections.Generic;

namespace DEMOwebAPI.Entities;

public partial class Suachuabaotri
{
    public int Id { get; set; }

    public DateTime? NgayNhan { get; set; }

    public DateTime? NgayDuKienHoanThanh { get; set; }

    public DateTime? NgayHoanThanh { get; set; }

    public decimal? ChiPhi { get; set; }

    public string? MoTaLoi { get; set; }

    public string? TinhTrangKhiNhanSanPham { get; set; }

    public short? TrangThai { get; set; }
}
