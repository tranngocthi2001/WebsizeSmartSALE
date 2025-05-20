using System;
using System.Collections.Generic;

namespace DEMOwebAPI.Entities;

public partial class Donhang
{
    public int Id { get; set; }

    public string TenKhachHang { get; set; } = null!;

    public DateTime NgayDatHang { get; set; }

    public decimal TongTien { get; set; }

    public string TrangThai { get; set; } = null!;

    public string DiaChiGiaoHang { get; set; } = null!;

    public int Sdt { get; set; }

    public int? NhanvienId { get; set; }

    public int KhachhangId { get; set; }

    public DateOnly UpdatedBy { get; set; }

    public string PhuongThucThanhToan { get; set; } = null!;

    public string? MaVanChuyen { get; set; }

    public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; } = new List<Chitietdonhang>();

    public virtual Khachhang Khachhang { get; set; } = null!;

    public virtual ICollection<Magiamgium> Magiamgia { get; set; } = new List<Magiamgium>();

    public virtual Nhanvien? Nhanvien { get; set; }

    public virtual ICollection<Phieuxuathang> Phieuxuathangs { get; set; } = new List<Phieuxuathang>();

    public virtual ICollection<Thanhtoan> Thanhtoans { get; set; } = new List<Thanhtoan>();
}
