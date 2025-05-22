public class SanPhamCreateFormDTO
{
    public string TenSanPham { get; set; }
    public string MoTa { get; set; }
    public decimal Gia { get; set; }
    public List<IFormFile> HinhAnhs { get; set; } // Đổi từ IFormFile sang List<IFormFile>
    public DateTime NgayTao { get; set; }
    public DateTime NgayCapNhat { get; set; }
    public int SoLuong { get; set; }
    public int TrangThai { get; set; }
    public int DanhmucId { get; set; }
}
