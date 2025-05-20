using System;
using System.Collections.Generic;

namespace DEMOwebAPI.Entities;

public partial class Phieuxuathang
{
    public int Id { get; set; }

    public DateTime NgayXuat { get; set; }

    public string TrangThai { get; set; } = null!;

    public int DonhangId { get; set; }

    public int NhanvienId { get; set; }

    public virtual ICollection<Chitietphieuxuat> Chitietphieuxuats { get; set; } = new List<Chitietphieuxuat>();

    public virtual Donhang Donhang { get; set; } = null!;

    public virtual Nhanvien Nhanvien { get; set; } = null!;
}
