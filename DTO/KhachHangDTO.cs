namespace DEMOwebAPI.DTO
{
    public class KhachHangDTO
    {
        public int Id { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public int Sdt { get; set; }
        public string DiaChi { get; set; }
        public string HoTen { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public short TrangThai { get; set; }
        // Collections are excluded as DTOs typically avoid navigation properties
    }
}

