using DEMOwebAPI.DTO;
using DEMOwebAPI.Entities;
using DEMOwebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEMOwebAPI.Services
{
    public class SanPhamService : ISanPham
    {
        private readonly DoantotnghiepContext _context;

        public SanPhamService(DoantotnghiepContext context)
        {
            _context = context;
        }

        public async Task<List<Sanpham>> GetAllSanPham()
        {
            return await _context.Sanphams.ToListAsync();
        }


        public async Task<SanPhamDTO> GetSanPhamById(int id, int DanhmucId)
        {
            var sp = await _context.Sanphams.FindAsync(id, DanhmucId);
            if (sp == null) return null;

            return new SanPhamDTO
            {
                Id = sp.Id,
                TenSanPham = sp.TenSanPham,
                Gia = sp.Gia,
                SoLuong = sp.SoLuong
                // Add other properties as needed
            };
        }

        public async Task<SanPhamDTO> CreateAsync(SanPhamCreateFormDTO dto)
        {
            string fileName = null;

            // Upload file
            if (dto.HinhAnh != null && dto.HinhAnh.Length > 0)
            {
                var uploads = Path.Combine("Uploads", "Images");
                Directory.CreateDirectory(uploads); // Tạo thư mục nếu chưa có
                fileName = $"{DateTimeOffset.Now.ToUnixTimeSeconds()}_{dto.HinhAnh.FileName}";
                var filePath = Path.Combine(uploads, fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                await dto.HinhAnh.CopyToAsync(stream);
            }

            var entity = new Sanpham
            {
                TenSanPham = dto.TenSanPham,
                MoTa = dto.MoTa,
                Gia = dto.Gia,
                HinhAnh = "[\"" + fileName + "\"]", // lưu chuỗi JSON chứa ảnh
                NgayTao = dto.NgayTao,
                NgayCapNhat = dto.NgayCapNhat,
                SoLuong = dto.SoLuong,
                TrangThai = (short)dto.TrangThai,
                DanhmucId = dto.DanhmucId
            };

            _context.Sanphams.Add(entity);
            await _context.SaveChangesAsync();

            return new SanPhamDTO
            {
                Id = entity.Id,
                TenSanPham = entity.TenSanPham,
                Gia = entity.Gia,
                SoLuong = entity.SoLuong,
                MoTa = entity.MoTa,
                NgayTao = entity.NgayTao,
                NgayCapNhat = entity.NgayCapNhat,
                TrangThai = entity.TrangThai,
                DanhmucId = entity.DanhmucId,
                HinhAnh = entity.HinhAnh
            };
        }


        public async Task<SanPhamDTO> UpdateAsync(SanPhamDTO sanPham)
        {
            var entity = await _context.Sanphams.FindAsync(sanPham.Id);
            if (entity == null) return null;

            entity.TenSanPham = sanPham.TenSanPham;
            entity.Gia = sanPham.Gia;
            entity.SoLuong = sanPham.SoLuong;
            // Update other properties as needed

            await _context.SaveChangesAsync();
            return sanPham;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Sanphams.FindAsync(id);
            if (entity != null)
            {
                _context.Sanphams.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        
    }
}
