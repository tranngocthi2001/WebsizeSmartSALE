using DEMOwebAPI.DTO;
using DEMOwebAPI.Entities;
using DEMOwebAPI.Services.Interfaces;
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


        // In SanPhamService.cs
        public async Task<SanPhamDTO> GetSanPhamById(int id)
        {
            var sp = await _context.Sanphams.FirstOrDefaultAsync(x => x.Id == id);
            if (sp == null) return default;

            var hinhAnhs = new List<string>();
            if (!string.IsNullOrEmpty(sp.HinhAnh))
            {
                var fileNames = System.Text.Json.JsonSerializer.Deserialize<List<string>>(sp.HinhAnh) ?? new List<string>();
                hinhAnhs = fileNames.Select(f => $"/Uploads/Images/{f}").ToList();
            }

            return new SanPhamDTO
            {
                Id = sp.Id,
                TenSanPham = sp.TenSanPham,
                Gia = sp.Gia,
                SoLuong = sp.SoLuong,
                MoTa = sp.MoTa,
                NgayTao = sp.NgayTao,
                NgayCapNhat = sp.NgayCapNhat,
                TrangThai = sp.TrangThai,
                DanhmucId = sp.DanhmucId,
                HinhAnhs = hinhAnhs
            };
        }

        public async Task<SanPhamDTO> CreateAsync(SanPhamCreateFormDTO dto)
        {
            var fileNames = new List<string>();

            if (dto.HinhAnhs != null && dto.HinhAnhs.Count > 0)
            {
                var uploads = Path.Combine("Uploads", "Images");
                Directory.CreateDirectory(uploads);
                foreach (var file in dto.HinhAnhs)
                {
                    var fileName = $"{DateTimeOffset.Now.ToUnixTimeSeconds()}_{file.FileName}";
                    var filePath = Path.Combine(uploads, fileName);
                    using var stream = new FileStream(filePath, FileMode.Create);
                    await file.CopyToAsync(stream);
                    fileNames.Add(fileName);
                }
            }

            var entity = new Sanpham
            {
                TenSanPham = dto.TenSanPham,
                MoTa = dto.MoTa,
                Gia = dto.Gia,
                HinhAnh = System.Text.Json.JsonSerializer.Serialize(fileNames), // Lưu JSON
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
                HinhAnhs = fileNames
            };
        }


        public async Task UpdateAsync(SanPhamUpdateFormDTO dto)
        {
            // Pass both key values: Id and DanhmucId
            var entity = await _context.Sanphams.FindAsync(dto.Id, dto.DanhmucId);
            if (entity == null) return;

            // Lấy danh sách ảnh cũ muốn giữ lại
            var fileNames = dto.OldImages ?? new List<string>();

            // Lưu ảnh mới nếu có
            if (dto.NewImages != null && dto.NewImages.Count > 0)
            {
                var uploads = Path.Combine("Uploads", "Images");
                Directory.CreateDirectory(uploads);
                foreach (var file in dto.NewImages)
                {
                    var fileName = $"{DateTimeOffset.Now.ToUnixTimeSeconds()}_{file.FileName}";
                    var filePath = Path.Combine(uploads, fileName);
                    using var stream = new FileStream(filePath, FileMode.Create);
                    await file.CopyToAsync(stream);
                    fileNames.Add(fileName);
                }
            }

            // Cập nhật thông tin sản phẩm
            entity.TenSanPham = dto.TenSanPham;
            entity.MoTa = dto.MoTa;
            entity.Gia = dto.Gia;
            entity.SoLuong = dto.SoLuong;
            entity.TrangThai = dto.TrangThai;
            entity.DanhmucId = dto.DanhmucId;
            entity.NgayCapNhat = dto.NgayCapNhat;
            entity.HinhAnh = System.Text.Json.JsonSerializer.Serialize(fileNames);

            await _context.SaveChangesAsync();
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
