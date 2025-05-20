using System;
using System.Collections.Generic;

namespace DEMOwebAPI.Entities;

public partial class Giohang
{
    public int Id { get; set; }

    public decimal TongTien { get; set; }

    public int TongSoLuong { get; set; }

    public int KhachhangId { get; set; }

    public virtual ICollection<Chitietgiohang> Chitietgiohangs { get; set; } = new List<Chitietgiohang>();

    public virtual Khachhang Khachhang { get; set; } = null!;
}
