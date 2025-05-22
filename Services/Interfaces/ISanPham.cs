using DEMOwebAPI.DTO;
using DEMOwebAPI.Entities;

namespace DEMOwebAPI.Services.Interfaces
{
    public interface ISanPham
    {
        // Define methods for product service
        // For example:
        Task<List<Sanpham>> GetAllSanPham();
        Task<SanPhamDTO> GetSanPhamById(int id);
        Task<SanPhamDTO> CreateAsync(SanPhamCreateFormDTO sanPham);
        //Task<SanPhamDTO> UpdateAsync(SanPhamDTO sanPham);
        Task DeleteAsync(int id);
        Task UpdateAsync(SanPhamUpdateFormDTO dto);
        
    }
}
