using System;
using System.Collections.Generic;

namespace DEMOwebAPI.Entities;

public partial class Baocaothongke
{
    public int Id { get; set; }

    public string Loai { get; set; } = null!;

    public DateTime NgayTao { get; set; }

    public DateTime ThoiGianBatDau { get; set; }

    public DateTime ThoiGianKetThuc { get; set; }

    public int TongSoDonHang { get; set; }

    public int SoLuongSanPhamNhapRa { get; set; }

    public decimal TongDoanhThu { get; set; }

    public int NhanvienId { get; set; }

    public virtual Nhanvien Nhanvien { get; set; } = null!;
}
