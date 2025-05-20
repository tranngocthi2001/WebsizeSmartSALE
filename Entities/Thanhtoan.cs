using System;
using System.Collections.Generic;

namespace DEMOwebAPI.Entities;

public partial class Thanhtoan
{
    public int Id { get; set; }

    public string PhuongThuc { get; set; } = null!;

    public string TrangThaiGiaoDich { get; set; } = null!;

    public decimal SoTien { get; set; }

    public string? MaGiaoDichNganHang { get; set; }

    public DateTime? NgayGiaoDich { get; set; }

    public string? MaGiaoDichVnpay { get; set; }

    public int DonhangId { get; set; }

    public virtual Donhang Donhang { get; set; } = null!;
}
