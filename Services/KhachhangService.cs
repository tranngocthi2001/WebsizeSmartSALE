using DEMOwebAPI.DTO;
using DEMOwebAPI.Entities;
using DEMOwebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DEMOwebAPI.Services
{
    public class KhachhangService : IKhachhangService
    {
        private readonly DoantotnghiepContext _context;
        public KhachhangService (DoantotnghiepContext context)
        {
            _context = context;
        }
        public async Task<List<KhachHangDTO>> GetAllKhachHang()
        {
            return await _context.Khachhangs
                .Select(kh => new KhachHangDTO
                {
                    Id = kh.Id,
                    TenTaiKhoan = kh.TenTaiKhoan,
                    MatKhau = kh.MatKhau,
                    Email = kh.Email,
                    Sdt = kh.Sdt,
                    DiaChi = kh.DiaChi,
                    HoTen = kh.HoTen,
                    NgayTao = kh.NgayTao,
                    NgayCapNhat = kh.NgayCapNhat,
                    TrangThai = kh.TrangThai
                })
                .ToListAsync();
        }
        public async Task<KhachHangDTO> GetKhachHangById(int id)
        {
            var kh = await _context.Khachhangs.FindAsync(id);
            if (kh == null) return null;

            return new KhachHangDTO
            {
                Id = kh.Id,
                TenTaiKhoan = kh.TenTaiKhoan,
                MatKhau = kh.MatKhau,
                Email = kh.Email,
                Sdt = kh.Sdt,
                DiaChi = kh.DiaChi,
                HoTen = kh.HoTen,
                NgayTao = kh.NgayTao,
                NgayCapNhat = kh.NgayCapNhat,
                TrangThai = kh.TrangThai
            };
        }
        public async Task<KhachHangDTO> CreateAsyncs(KhachHangDTO dto)
        {
            // Map DTO sang Entity
            var entity = new Khachhang
            {
                TenTaiKhoan = dto.TenTaiKhoan,
                MatKhau = dto.MatKhau,
                Email = dto.Email,
                Sdt = dto.Sdt,
                DiaChi = dto.DiaChi,
                HoTen = dto.HoTen,
                NgayTao = DateTime.Now,
                NgayCapNhat = DateTime.Now,
                TrangThai = dto.TrangThai
            };

            // Thêm vào DB
            _context.Khachhangs.Add(entity);
            await _context.SaveChangesAsync();

            // Map lại Entity sang DTO để trả về
            return new KhachHangDTO
            {
                Id = entity.Id,
                TenTaiKhoan = entity.TenTaiKhoan,
                MatKhau = entity.MatKhau,
                Email = entity.Email,
                Sdt = entity.Sdt,
                DiaChi = entity.DiaChi,
                HoTen = entity.HoTen,
                NgayTao = entity.NgayTao,
                NgayCapNhat = entity.NgayCapNhat,
                TrangThai = entity.TrangThai
            };
        }


        public Task DeleteAsync(int id)
        {
            Khachhang khachHang = _context.Khachhangs.Find(id);
            if (khachHang != null)
            {
                _context.Khachhangs.Remove(khachHang);
                _context.SaveChanges();
            }
            return Task.CompletedTask;
        }

        

        //public Task<KhachHangDTO> UpdateAsync(KhachHangDTO khachHang)
        //{

        //}
    }
}
