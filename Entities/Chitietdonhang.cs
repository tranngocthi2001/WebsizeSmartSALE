using System;
using System.Collections.Generic;

namespace DEMOwebAPI.Entities;

public partial class Chitietdonhang
{
    public int Id { get; set; }

    public int SoLuong { get; set; }

    public decimal Gia { get; set; }

    public int DonhangId { get; set; }

    public virtual ICollection<Chitietphieuxuat> Chitietphieuxuats { get; set; } = new List<Chitietphieuxuat>();

    public virtual Donhang Donhang { get; set; } = null!;
}
