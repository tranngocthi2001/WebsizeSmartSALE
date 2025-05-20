using System;
using System.Collections.Generic;

namespace DEMOwebAPI.Entities;

public partial class Nhanvien
{
    public int Id { get; set; }

    public string TenTaiKhoan { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Sdt { get; set; }

    public string DiaChi { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public string VaiTro { get; set; } = null!;

    public DateTime NgayTao { get; set; }

    public DateTime NgayCapNhat { get; set; }

    public short TrangThai { get; set; }

    public virtual ICollection<Baocaothongke> Baocaothongkes { get; set; } = new List<Baocaothongke>();

    public virtual ICollection<Donhang> Donhangs { get; set; } = new List<Donhang>();

    public virtual ICollection<Phieuxuathang> Phieuxuathangs { get; set; } = new List<Phieuxuathang>();
}
