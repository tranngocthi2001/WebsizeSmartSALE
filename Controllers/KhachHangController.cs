using DEMOwebAPI.DTO;
using DEMOwebAPI.Entities;
using DEMOwebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DEMOwebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly IKhachhangService _khachhangService;

        public KhachHangController(IKhachhangService service)
        {
            _khachhangService = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllKhachHang()
        {
            var khachhangs = await _khachhangService.GetAllKhachHang();
            return Ok(khachhangs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKhachHangById(int id)
        {
            var khachhang = await _khachhangService.GetKhachHangById(id);
            if (khachhang == null)
            {
                return NotFound();
            }
            return Ok(khachhang);
        }
    }
}