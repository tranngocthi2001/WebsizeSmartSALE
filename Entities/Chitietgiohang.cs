using System;
using System.Collections.Generic;

namespace DEMOwebAPI.Entities;

public partial class Chitietgiohang
{
    public int Id { get; set; }

    public int SoLuong { get; set; }

    public decimal Gia { get; set; }

    public int GiohangId { get; set; }

    public virtual Giohang Giohang { get; set; } = null!;
}
