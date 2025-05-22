using System;

namespace DEMOwebAPI.DTO
{
    public class SanPhamDTO
    {
        public int Id { get; set; }
        public string TenSanPham { get; set; }
        public string MoTa { get; set; }
        public decimal Gia { get; set; }
        public List<string> HinhAnhs { get; set; } // Đổi sang List<string>
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public int SoLuong { get; set; }
        public short TrangThai { get; set; }
        public int DanhmucId { get; set; }
    }
}
