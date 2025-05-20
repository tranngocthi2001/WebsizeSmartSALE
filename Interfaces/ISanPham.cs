using DEMOwebAPI.DTO;
using DEMOwebAPI.Entities;

namespace DEMOwebAPI.Interfaces
{
    public interface ISanPham
    {
        // Define methods for product service
        // For example:
        Task<List<Sanpham>> GetAllSanPham();
        Task<SanPhamDTO> GetSanPhamById(int id, int DanhmucId);
        Task<SanPhamDTO> CreateAsync(SanPhamCreateFormDTO sanPham);
        Task<SanPhamDTO> UpdateAsync(SanPhamDTO sanPham);
        Task DeleteAsync(int id);


    }
}
