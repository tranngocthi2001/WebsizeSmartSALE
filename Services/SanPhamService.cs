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


        public async Task<SanPhamDTO> GetSanPhamById(int id)
        {
            var sp = await _context.Sanphams.FindAsync(id);
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

        public async Task<SanPhamDTO> CreateAsync(SanPhamDTO sanPham)
        {
            var entity = new Sanpham
            {
                TenSanPham = sanPham.TenSanPham,
                Gia = sanPham.Gia,
                SoLuong = sanPham.SoLuong
                // Add other properties as needed
            };
            _context.Sanphams.Add(entity);
            await _context.SaveChangesAsync();

            sanPham.Id = entity.Id;
            return sanPham;
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
