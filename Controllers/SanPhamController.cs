using DEMOwebAPI.DTO;
using DEMOwebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DEMOwebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly ISanPham _sanPhamService;

        public SanPhamController(ISanPham sanPhamService)
        {
            _sanPhamService = sanPhamService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSanPham()
        {
            var sanPhams = await _sanPhamService.GetAllSanPham();
            return Ok(sanPhams);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] SanPhamCreateFormDTO dto)
        {
            var result = await _sanPhamService.CreateAsync(dto);
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetSanPhamById(int id)
        {
            var sanPham = await _sanPhamService.GetSanPhamById(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            return Ok(sanPham);
        }
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update([FromForm] SanPhamUpdateFormDTO dto)
        {
            await _sanPhamService.UpdateAsync(dto);
            return Ok(new { Message = "Update successful" });
        }
    }
}
