using System;

namespace DEMOwebAPI.DTO
{
    public class SanPhamDTO
    {
        public int Id { get; set; }
        public string TenSanPham { get; set; } = null!;
        public string MoTa { get; set; } = null!;
        public decimal Gia { get; set; }
        public string HinhAnh { get; set; } = null!;
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public int SoLuong { get; set; }
        public short TrangThai { get; set; }
        public int DanhmucId { get; set; }
    }
}
