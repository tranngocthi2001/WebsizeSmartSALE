using Microsoft.AspNetCore.Mvc;

namespace DEMOwebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : Controller
    {
        private readonly DoantotnghiepContext _context;
        private NhanVienController(DoantotnghiepContext context)
        {
            _context = context;
        }
        //[HttpGet]
        //public async Task<ActionResult>
    }
}
