using DEMOwebAPI.Entities;
using DEMOwebAPI.Model;
using DEMOwebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DEMOwebAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly DoantotnghiepContext _context;
        private readonly IConfiguration _config;

        public AuthService(DoantotnghiepContext context, IConfiguration config)
        {
            _context = context;
            _config = config;  
        }
        public async Task<LoginResponse?> LoginAsync(LoginRequest request)
        {
            var user = await _context.Nhanviens
                .FirstOrDefaultAsync(u => u.TenTaiKhoan == request.TenTaiKhoan 
                && u.MatKhau == request.MatKhau
                && u.VaiTro=="admin"
                &&u.TrangThai==1);
            if (user == null) return null;
            var token = GenerateJwtToken(user);

            return new LoginResponse
            {
                Token = (string)token,
                HoTen = user.HoTen,
                VaiTro = user.VaiTro
            };
        }

        private object GenerateJwtToken(Nhanvien user)
        {
            var claims = new[]
         {
            new Claim(ClaimTypes.Name, user.TenTaiKhoan),
            new Claim(ClaimTypes.Role, user.VaiTro),
            new Claim("UserId", user.Id.ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
    
}
