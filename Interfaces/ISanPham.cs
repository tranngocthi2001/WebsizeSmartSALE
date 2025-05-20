using DEMOwebAPI.DTO;
using DEMOwebAPI.Entities;

namespace DEMOwebAPI.Interfaces
{
    public interface ISanPham
    {
        // Define methods for product service
        // For example:
        Task<List<Sanpham>> GetAllSanPham();
        Task<SanPhamDTO> GetSanPhamById(int id);
        Task<SanPhamDTO> CreateAsync(SanPhamDTO sanPham);
        Task<SanPhamDTO> UpdateAsync(SanPhamDTO sanPham);
        Task DeleteAsync(int id);
    }
}
