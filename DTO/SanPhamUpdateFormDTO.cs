public class SanPhamUpdateFormDTO
{
    public int Id { get; set; }
    public string TenSanPham { get; set; }
    public string MoTa { get; set; }
    public decimal Gia { get; set; }
    public int SoLuong { get; set; }
    public short TrangThai { get; set; }
    public int DanhmucId { get; set; }
    public DateTime NgayCapNhat { get; set; }
    public List<string> OldImages { get; set; } // Danh sách tên ảnh cũ muốn giữ lại
    public List<IFormFile> NewImages { get; set; } // Danh sách ảnh mới upload
}
