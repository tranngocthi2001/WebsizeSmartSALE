using DEMOwebAPI.DTO;

namespace DEMOwebAPI.Interfaces
{
    public interface IKhachhangService
    {
        // Define methods for customer service
        // For example:
        Task<List<KhachHangDTO>> GetAllKhachHang();
        Task<KhachHangDTO> GetKhachHangById(int id);
        Task<KhachHangDTO> CreateAsyncs(KhachHangDTO khachHang);
        //Task<KhachHangDTO> UpdateAsync(KhachHangDTO khachHang);
        Task DeleteAsync(int id);
        
    }
}
