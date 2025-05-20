using System;
using System.Collections.Generic;
using DEMOwebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace DEMOwebAPI;

public partial class DoantotnghiepContext : DbContext
{
    public DoantotnghiepContext()
    {
    }

    public DoantotnghiepContext(DbContextOptions<DoantotnghiepContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Baocaothongke> Baocaothongkes { get; set; }

    public virtual DbSet<Chitietdoihang> Chitietdoihangs { get; set; }

    public virtual DbSet<Chitietdonhang> Chitietdonhangs { get; set; }

    public virtual DbSet<Chitietgiohang> Chitietgiohangs { get; set; }

    public virtual DbSet<Chitietphieuxuat> Chitietphieuxuats { get; set; }

    public virtual DbSet<ChitietphieuxuatHasSuachuabaotri> ChitietphieuxuatHasSuachuabaotris { get; set; }

    public virtual DbSet<Chitiettrahang> Chitiettrahangs { get; set; }

    public virtual DbSet<Danhgium> Danhgia { get; set; }

    public virtual DbSet<Danhmuc> Danhmucs { get; set; }

    public virtual DbSet<Donhang> Donhangs { get; set; }

    public virtual DbSet<Giohang> Giohangs { get; set; }

    public virtual DbSet<Khachhang> Khachhangs { get; set; }

    public virtual DbSet<Magiamgium> Magiamgia { get; set; }

    public virtual DbSet<Nhanvien> Nhanviens { get; set; }

    public virtual DbSet<NhanvienHasSuachuabaotri> NhanvienHasSuachuabaotris { get; set; }

    public virtual DbSet<Phieuxuathang> Phieuxuathangs { get; set; }

    public virtual DbSet<Sanpham> Sanphams { get; set; }

    public virtual DbSet<SanphamHasChitietdonhang> SanphamHasChitietdonhangs { get; set; }

    public virtual DbSet<SanphamHasChitietgiohang> SanphamHasChitietgiohangs { get; set; }

    public virtual DbSet<SanphamHasSukien> SanphamHasSukiens { get; set; }

    public virtual DbSet<Seri> Seris { get; set; }

    public virtual DbSet<SeriHasSuachuabaotri> SeriHasSuachuabaotris { get; set; }

    public virtual DbSet<Suachuabaotri> Suachuabaotris { get; set; }

    public virtual DbSet<Sukien> Sukiens { get; set; }

    public virtual DbSet<Thanhtoan> Thanhtoans { get; set; }

    public virtual DbSet<Thongbao> Thongbaos { get; set; }

    public virtual DbSet<ThongbaoHasKhachhang> ThongbaoHasKhachhangs { get; set; }

    public virtual DbSet<ThongbaoHasNhanvien> ThongbaoHasNhanviens { get; set; }

    public virtual DbSet<Yeucaudoihang> Yeucaudoihangs { get; set; }

    public virtual DbSet<Yeucautrahang> Yeucautrahangs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=doantotnghiep;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Baocaothongke>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_baocaothongke_id");

            entity.ToTable("baocaothongke");

            entity.HasIndex(e => e.NhanvienId, "fk_baocaothongke_nhanvien_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Loai)
                .HasMaxLength(50)
                .HasColumnName("loai");
            entity.Property(e => e.NgayTao)
                .HasPrecision(0)
                .HasColumnName("ngayTao");
            entity.Property(e => e.NhanvienId).HasColumnName("nhanvien_id");
            entity.Property(e => e.SoLuongSanPhamNhapRa).HasColumnName("soLuongSanPhamNhapRa");
            entity.Property(e => e.ThoiGianBatDau)
                .HasPrecision(0)
                .HasColumnName("thoiGianBatDau");
            entity.Property(e => e.ThoiGianKetThuc)
                .HasPrecision(0)
                .HasColumnName("thoiGianKetThuc");
            entity.Property(e => e.TongDoanhThu)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("tongDoanhThu");
            entity.Property(e => e.TongSoDonHang).HasColumnName("tongSoDonHang");

            entity.HasOne(d => d.Nhanvien).WithMany(p => p.Baocaothongkes)
                .HasForeignKey(d => d.NhanvienId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("baocaothongke$fk_baocaothongke_nhanvien");
        });

        modelBuilder.Entity<Chitietdoihang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_chitietdoihang_id");

            entity.ToTable("chitietdoihang");

            entity.HasIndex(e => e.YeucaudoihangId, "yeucaudoihang_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.HinhAnh).HasColumnName("hinhAnh");
            entity.Property(e => e.SanPhamDoiId).HasColumnName("sanPhamDoiID");
            entity.Property(e => e.SoLuong).HasColumnName("soLuong");
            entity.Property(e => e.YeucaudoihangId).HasColumnName("yeucaudoihang_id");
        });

        modelBuilder.Entity<Chitietdonhang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_chitietdonhang_id");

            entity.ToTable("chitietdonhang");

            entity.HasIndex(e => e.DonhangId, "fk_donhang");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DonhangId).HasColumnName("donhang_id");
            entity.Property(e => e.Gia)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("gia");
            entity.Property(e => e.SoLuong).HasColumnName("soLuong");

            entity.HasOne(d => d.Donhang).WithMany(p => p.Chitietdonhangs)
                .HasForeignKey(d => d.DonhangId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chitietdonhang$fk_donhang");
        });

        modelBuilder.Entity<Chitietgiohang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_chitietgiohang_id");

            entity.ToTable("chitietgiohang");

            entity.HasIndex(e => e.GiohangId, "fk_chitietgiohang_giohang1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Gia)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("gia");
            entity.Property(e => e.GiohangId).HasColumnName("giohang_id");
            entity.Property(e => e.SoLuong).HasColumnName("soLuong");

            entity.HasOne(d => d.Giohang).WithMany(p => p.Chitietgiohangs)
                .HasForeignKey(d => d.GiohangId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chitietgiohang$fk_chitietgiohang_giohang1");
        });

        modelBuilder.Entity<Chitietphieuxuat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_chitietphieuxuat_id");

            entity.ToTable("chitietphieuxuat");

            entity.HasIndex(e => e.ChitietdonhangId, "fk_chitietphieuxuat_chitietdonhang1_idx");

            entity.HasIndex(e => e.PhieuxuathangId, "fk_chitietphieuxuat_phieuxuathang1_idx");

            entity.HasIndex(e => e.YeucaudoihangId, "fk_chitietphieuxuat_yeucaudoihang1_idx");

            entity.HasIndex(e => e.YeucautrahangId, "fk_chitietphieuxuat_yeucautrahang1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BaoHanh)
                .HasPrecision(0)
                .HasColumnName("baoHanh");
            entity.Property(e => e.ChitietdonhangId).HasColumnName("chitietdonhang_id");
            entity.Property(e => e.GhiChu).HasColumnName("ghiChu");
            entity.Property(e => e.PhieuxuathangId).HasColumnName("phieuxuathang_id");
            entity.Property(e => e.SoLuong).HasColumnName("soLuong");
            entity.Property(e => e.YeucaudoihangId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("yeucaudoihang_id");
            entity.Property(e => e.YeucautrahangId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("yeucautrahang_id");

            entity.HasOne(d => d.Chitietdonhang).WithMany(p => p.Chitietphieuxuats)
                .HasForeignKey(d => d.ChitietdonhangId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chitietphieuxuat$fk_chitietphieuxuat_chitietdonhang1");

            entity.HasOne(d => d.Phieuxuathang).WithMany(p => p.Chitietphieuxuats)
                .HasForeignKey(d => d.PhieuxuathangId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chitietphieuxuat$fk_chitietphieuxuat_phieuxuathang1");

            entity.HasOne(d => d.Yeucaudoihang).WithMany(p => p.Chitietphieuxuats)
                .HasForeignKey(d => d.YeucaudoihangId)
                .HasConstraintName("chitietphieuxuat$fk_chitietphieuxuat_yeucaudoihang1");

            entity.HasOne(d => d.Yeucautrahang).WithMany(p => p.Chitietphieuxuats)
                .HasForeignKey(d => d.YeucautrahangId)
                .HasConstraintName("chitietphieuxuat$fk_chitietphieuxuat_yeucautrahang1");
        });

        modelBuilder.Entity<ChitietphieuxuatHasSuachuabaotri>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("chitietphieuxuat_has_suachuabaotri");

            entity.HasIndex(e => e.ChitietphieuxuatId, "fk_chitietphieuxuat_has_suachuabaotri_chitietphieuxuat1_idx");

            entity.HasIndex(e => e.SuachuabaotriId, "fk_chitietphieuxuat_has_suachuabaotri_suachuabaotri1_idx");

            entity.Property(e => e.ChitietphieuxuatId).HasColumnName("chitietphieuxuat_id");
            entity.Property(e => e.SuachuabaotriId).HasColumnName("suachuabaotri_id");

            entity.HasOne(d => d.Chitietphieuxuat).WithMany()
                .HasForeignKey(d => d.ChitietphieuxuatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chitietphieuxuat_has_suachuabaotri$fk_chitietphieuxuat_has_suachuabaotri_chitietphieuxuat1");

            entity.HasOne(d => d.Suachuabaotri).WithMany()
                .HasForeignKey(d => d.SuachuabaotriId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chitietphieuxuat_has_suachuabaotri$fk_chitietphieuxuat_has_suachuabaotri_suachuabaotri1");
        });

        modelBuilder.Entity<Chitiettrahang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_chitiettrahang_id");

            entity.ToTable("chitiettrahang");

            entity.HasIndex(e => e.YeucautrahangId, "fk_chitiettrahang_yeucautrahang");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.HinhAnh).HasColumnName("hinhAnh");
            entity.Property(e => e.SanPhamTraId).HasColumnName("sanPhamTraID");
            entity.Property(e => e.SoLuong).HasColumnName("soLuong");
            entity.Property(e => e.YeucautrahangId).HasColumnName("yeucautrahang_id");

            entity.HasOne(d => d.Yeucautrahang).WithMany(p => p.Chitiettrahangs)
                .HasForeignKey(d => d.YeucautrahangId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chitiettrahang$fk_chitiettrahang_yeucautrahang");
        });

        modelBuilder.Entity<Danhgium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_danhgia_id");

            entity.ToTable("danhgia");

            entity.HasIndex(e => e.KhachhangId, "fk_danhgia_khachhang1_idx");

            entity.HasIndex(e => e.SanphamId, "fk_danhgia_sanpham1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.KhachhangId).HasColumnName("khachhang_id");
            entity.Property(e => e.NgayTao)
                .HasPrecision(0)
                .HasColumnName("ngayTao");
            entity.Property(e => e.NoiDung).HasColumnName("noiDung");
            entity.Property(e => e.SanphamId).HasColumnName("sanpham_id");
            entity.Property(e => e.SoSao).HasColumnName("soSao");

            entity.HasOne(d => d.Khachhang).WithMany(p => p.Danhgia)
                .HasForeignKey(d => d.KhachhangId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("danhgia$fk_danhgia_khachhang1");
        });

        modelBuilder.Entity<Danhmuc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_danhmuc_id");

            entity.ToTable("danhmuc");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MoTa).HasColumnName("moTa");
            entity.Property(e => e.NgayCapNhat)
                .HasPrecision(0)
                .HasColumnName("ngayCapNhat");
            entity.Property(e => e.NgayTao)
                .HasPrecision(0)
                .HasColumnName("ngayTao");
            entity.Property(e => e.TenDanhMuc)
                .HasMaxLength(100)
                .HasColumnName("tenDanhMuc");
            entity.Property(e => e.TrangThai).HasColumnName("trangThai");
        });

        modelBuilder.Entity<Donhang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_donhang_id");

            entity.ToTable("donhang");

            entity.HasIndex(e => e.KhachhangId, "fk_donhang_khachhang1_idx");

            entity.HasIndex(e => e.NhanvienId, "fk_donhang_nhanvien1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DiaChiGiaoHang).HasColumnName("diaChiGiaoHang");
            entity.Property(e => e.KhachhangId).HasColumnName("khachhang_id");
            entity.Property(e => e.MaVanChuyen)
                .HasMaxLength(50)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("maVanChuyen");
            entity.Property(e => e.NgayDatHang)
                .HasPrecision(0)
                .HasColumnName("ngayDatHang");
            entity.Property(e => e.NhanvienId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("nhanvien_id");
            entity.Property(e => e.PhuongThucThanhToan)
                .HasMaxLength(45)
                .HasColumnName("phuongThucThanhToan");
            entity.Property(e => e.Sdt).HasColumnName("sdt");
            entity.Property(e => e.TenKhachHang)
                .HasMaxLength(100)
                .HasColumnName("tenKhachHang");
            entity.Property(e => e.TongTien)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("tongTien");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .HasColumnName("trangThai");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Khachhang).WithMany(p => p.Donhangs)
                .HasForeignKey(d => d.KhachhangId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("donhang$fk_donhang_khachhang1");

            entity.HasOne(d => d.Nhanvien).WithMany(p => p.Donhangs)
                .HasForeignKey(d => d.NhanvienId)
                .HasConstraintName("donhang$fk_donhang_nhanvien1");
        });

        modelBuilder.Entity<Giohang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_giohang_id");

            entity.ToTable("giohang");

            entity.HasIndex(e => e.KhachhangId, "fk_giohang_khachhang1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.KhachhangId).HasColumnName("khachhang_id");
            entity.Property(e => e.TongSoLuong).HasColumnName("tongSoLuong");
            entity.Property(e => e.TongTien)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("tongTien");

            entity.HasOne(d => d.Khachhang).WithMany(p => p.Giohangs)
                .HasForeignKey(d => d.KhachhangId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("giohang$fk_giohang_khachhang1");
        });

        modelBuilder.Entity<Khachhang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_khachhang_id");

            entity.ToTable("khachhang");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DiaChi).HasColumnName("diaChi");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.HoTen)
                .HasMaxLength(100)
                .HasColumnName("hoTen");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(200)
                .HasColumnName("matKhau");
            entity.Property(e => e.NgayCapNhat)
                .HasPrecision(0)
                .HasColumnName("ngayCapNhat");
            entity.Property(e => e.NgayTao)
                .HasPrecision(0)
                .HasColumnName("ngayTao");
            entity.Property(e => e.Sdt).HasColumnName("sdt");
            entity.Property(e => e.TenTaiKhoan)
                .HasMaxLength(100)
                .HasColumnName("tenTaiKhoan");
            entity.Property(e => e.TrangThai).HasColumnName("trangThai");
        });

        modelBuilder.Entity<Magiamgium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_magiamgia_id");

            entity.ToTable("magiamgia");

            entity.HasIndex(e => e.DonhangId, "fk_magiamgia_donhang1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DonhangId).HasColumnName("donhang_id");
            entity.Property(e => e.GiaTri).HasColumnName("giaTri");
            entity.Property(e => e.NgayBatDau)
                .HasPrecision(0)
                .HasColumnName("ngayBatDau");
            entity.Property(e => e.NgayKetThuc)
                .HasPrecision(0)
                .HasColumnName("ngayKetThuc");
            entity.Property(e => e.SoLuong).HasColumnName("soLuong");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .HasColumnName("trangThai");

            entity.HasOne(d => d.Donhang).WithMany(p => p.Magiamgia)
                .HasForeignKey(d => d.DonhangId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("magiamgia$fk_magiamgia_donhang1");
        });

        modelBuilder.Entity<Nhanvien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_nhanvien_id");

            entity.ToTable("nhanvien");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DiaChi).HasColumnName("diaChi");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.HoTen)
                .HasMaxLength(100)
                .HasColumnName("hoTen");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(255)
                .HasColumnName("matKhau");
            entity.Property(e => e.NgayCapNhat)
                .HasPrecision(0)
                .HasColumnName("ngayCapNhat");
            entity.Property(e => e.NgayTao)
                .HasPrecision(0)
                .HasColumnName("ngayTao");
            entity.Property(e => e.Sdt).HasColumnName("sdt");
            entity.Property(e => e.TenTaiKhoan)
                .HasMaxLength(100)
                .HasColumnName("tenTaiKhoan");
            entity.Property(e => e.TrangThai).HasColumnName("trangThai");
            entity.Property(e => e.VaiTro)
                .HasMaxLength(50)
                .HasColumnName("vaiTro");
        });

        modelBuilder.Entity<NhanvienHasSuachuabaotri>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("nhanvien_has_suachuabaotri");

            entity.HasIndex(e => e.NhanvienId, "fk_nhanvien_has_suachuabaotri_nhanvien1_idx");

            entity.HasIndex(e => e.SuachuabaotriId, "fk_nhanvien_has_suachuabaotri_suachuabaotri1_idx");

            entity.Property(e => e.NhanvienId).HasColumnName("nhanvien_id");
            entity.Property(e => e.SuachuabaotriId).HasColumnName("suachuabaotri_id");

            entity.HasOne(d => d.Nhanvien).WithMany()
                .HasForeignKey(d => d.NhanvienId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("nhanvien_has_suachuabaotri$fk_nhanvien_has_suachuabaotri_nhanvien1");

            entity.HasOne(d => d.Suachuabaotri).WithMany()
                .HasForeignKey(d => d.SuachuabaotriId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("nhanvien_has_suachuabaotri$fk_nhanvien_has_suachuabaotri_suachuabaotri1");
        });

        modelBuilder.Entity<Phieuxuathang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_phieuxuathang_id");

            entity.ToTable("phieuxuathang");

            entity.HasIndex(e => e.NhanvienId, "fk_nhanvien");

            entity.HasIndex(e => e.DonhangId, "fk_phieuxuathang_donhang1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DonhangId).HasColumnName("donhang_id");
            entity.Property(e => e.NgayXuat)
                .HasPrecision(0)
                .HasColumnName("ngayXuat");
            entity.Property(e => e.NhanvienId).HasColumnName("nhanvien_id");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .HasColumnName("trangThai");

            entity.HasOne(d => d.Donhang).WithMany(p => p.Phieuxuathangs)
                .HasForeignKey(d => d.DonhangId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("phieuxuathang$fk_phieuxuathang_donhang1");

            entity.HasOne(d => d.Nhanvien).WithMany(p => p.Phieuxuathangs)
                .HasForeignKey(d => d.NhanvienId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("phieuxuathang$fk_nhanvien");
        });

        modelBuilder.Entity<Sanpham>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.DanhmucId }).HasName("PK_sanpham_id");

            entity.ToTable("sanpham");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.DanhmucId).HasColumnName("danhmuc_id");
            entity.Property(e => e.Gia)
                .HasColumnType("decimal(15, 0)")
                .HasColumnName("gia");
            entity.Property(e => e.HinhAnh).HasColumnName("hinhAnh");
            entity.Property(e => e.MoTa).HasColumnName("moTa");
            entity.Property(e => e.NgayCapNhat)
                .HasPrecision(0)
                .HasColumnName("ngayCapNhat");
            entity.Property(e => e.NgayTao)
                .HasPrecision(0)
                .HasColumnName("ngayTao");
            entity.Property(e => e.SoLuong).HasColumnName("soLuong");
            entity.Property(e => e.TenSanPham)
                .HasMaxLength(255)
                .HasColumnName("tenSanPham");
            entity.Property(e => e.TrangThai).HasColumnName("trangThai");
        });

        modelBuilder.Entity<SanphamHasChitietdonhang>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("sanpham_has_chitietdonhang");

            entity.HasIndex(e => e.ChitietdonhangId, "fk_sanpham_has_chitietdonhang_chitietdonhang1_idx");

            entity.HasIndex(e => e.SanphamId, "fk_sanpham_has_chitietdonhang_sanpham1_idx");

            entity.Property(e => e.ChitietdonhangId).HasColumnName("chitietdonhang_id");
            entity.Property(e => e.SanphamId).HasColumnName("sanpham_id");
            entity.Property(e => e.SoLuong).HasColumnName("soLuong");

            entity.HasOne(d => d.Chitietdonhang).WithMany()
                .HasForeignKey(d => d.ChitietdonhangId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sanpham_has_chitietdonhang$fk_sanpham_has_chitietdonhang_chitietdonhang1");
        });

        modelBuilder.Entity<SanphamHasChitietgiohang>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("sanpham_has_chitietgiohang");

            entity.HasIndex(e => e.ChitietgiohangId, "fk_sanpham_has_chitietgiohang_chitietgiohang1_idx");

            entity.HasIndex(e => e.SanphamId, "fk_sanpham_has_chitietgiohang_sanpham1_idx");

            entity.Property(e => e.ChitietgiohangId).HasColumnName("chitietgiohang_id");
            entity.Property(e => e.SanphamId).HasColumnName("sanpham_id");
            entity.Property(e => e.SoLuong)
                .HasDefaultValue(0)
                .HasColumnName("soLuong");

            entity.HasOne(d => d.Chitietgiohang).WithMany()
                .HasForeignKey(d => d.ChitietgiohangId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sanpham_has_chitietgiohang$fk_sanpham_has_chitietgiohang_chitietgiohang1");
        });

        modelBuilder.Entity<SanphamHasSukien>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("sanpham_has_sukien");

            entity.HasIndex(e => e.SanphamId, "fk_sanpham_has_sukien_sanpham1_idx");

            entity.HasIndex(e => e.SukienId, "fk_sanpham_has_sukien_sukien1_idx");

            entity.Property(e => e.SanphamId).HasColumnName("sanpham_id");
            entity.Property(e => e.SukienId).HasColumnName("sukien_id");

            entity.HasOne(d => d.Sukien).WithMany()
                .HasForeignKey(d => d.SukienId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sanpham_has_sukien$fk_sanpham_has_sukien_sukien1");
        });

        modelBuilder.Entity<Seri>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_seri_id");

            entity.ToTable("seri");

            entity.HasIndex(e => e.ChitietphieuxuatId, "fk_seri_chitietphieuxuat1_idx");

            entity.HasIndex(e => e.YeucaudoihangId, "fk_seri_yeucaudoihang1_idx");

            entity.HasIndex(e => e.YeucautrahangId, "fk_seri_yeucautrahang1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChitietphieuxuatId).HasColumnName("chitietphieuxuat_id");
            entity.Property(e => e.MaSeri).HasColumnName("maSeri");
            entity.Property(e => e.YeucaudoihangId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("yeucaudoihang_id");
            entity.Property(e => e.YeucautrahangId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("yeucautrahang_id");

            entity.HasOne(d => d.Chitietphieuxuat).WithMany(p => p.Seris)
                .HasForeignKey(d => d.ChitietphieuxuatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("seri$fk_seri_chitietphieuxuat1");

            entity.HasOne(d => d.Yeucaudoihang).WithMany(p => p.Seris)
                .HasForeignKey(d => d.YeucaudoihangId)
                .HasConstraintName("seri$fk_seri_yeucaudoihang1");

            entity.HasOne(d => d.Yeucautrahang).WithMany(p => p.Seris)
                .HasForeignKey(d => d.YeucautrahangId)
                .HasConstraintName("seri$fk_seri_yeucautrahang1");
        });

        modelBuilder.Entity<SeriHasSuachuabaotri>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("seri_has_suachuabaotri");

            entity.HasIndex(e => e.SeriId, "fk_seri_has_suachuabaotri_seri1_idx");

            entity.HasIndex(e => e.SuachuabaotriId, "fk_seri_has_suachuabaotri_suachuabaotri1_idx");

            entity.Property(e => e.SeriId).HasColumnName("seri_id");
            entity.Property(e => e.SuachuabaotriId).HasColumnName("suachuabaotri_id");

            entity.HasOne(d => d.Seri).WithMany()
                .HasForeignKey(d => d.SeriId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("seri_has_suachuabaotri$fk_seri_has_suachuabaotri_seri1");

            entity.HasOne(d => d.Suachuabaotri).WithMany()
                .HasForeignKey(d => d.SuachuabaotriId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("seri_has_suachuabaotri$fk_seri_has_suachuabaotri_suachuabaotri1");
        });

        modelBuilder.Entity<Suachuabaotri>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_suachuabaotri_id");

            entity.ToTable("suachuabaotri");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChiPhi)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("chiPhi");
            entity.Property(e => e.MoTaLoi).HasColumnName("moTaLoi");
            entity.Property(e => e.NgayDuKienHoanThanh)
                .HasPrecision(0)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ngayDuKienHoanThanh");
            entity.Property(e => e.NgayHoanThanh)
                .HasPrecision(0)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ngayHoanThanh");
            entity.Property(e => e.NgayNhan)
                .HasPrecision(0)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ngayNhan");
            entity.Property(e => e.TinhTrangKhiNhanSanPham)
                .HasMaxLength(100)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("tinhTrangKhiNhanSanPham");
            entity.Property(e => e.TrangThai)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("trangThai");
        });

        modelBuilder.Entity<Sukien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_sukien_id");

            entity.ToTable("sukien");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LoaiSuKien)
                .HasMaxLength(50)
                .HasColumnName("loaiSuKien");
            entity.Property(e => e.MoTaSuKien).HasColumnName("moTaSuKien");
            entity.Property(e => e.TenSuKien)
                .HasMaxLength(100)
                .HasColumnName("tenSuKien");
            entity.Property(e => e.ThoiGianBatDau)
                .HasPrecision(0)
                .HasColumnName("thoiGianBatDau");
            entity.Property(e => e.ThoiGianKetThuc)
                .HasPrecision(0)
                .HasColumnName("thoiGianKetThuc");
            entity.Property(e => e.TrangThai).HasColumnName("trangThai");
        });

        modelBuilder.Entity<Thanhtoan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_thanhtoan_id");

            entity.ToTable("thanhtoan");

            entity.HasIndex(e => e.DonhangId, "fk_thanhtoan_donhang1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DonhangId).HasColumnName("donhang_id");
            entity.Property(e => e.MaGiaoDichNganHang)
                .HasMaxLength(100)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("maGiaoDichNganHang");
            entity.Property(e => e.MaGiaoDichVnpay)
                .HasMaxLength(100)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("maGiaoDichVnpay");
            entity.Property(e => e.NgayGiaoDich)
                .HasPrecision(0)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ngayGiaoDich");
            entity.Property(e => e.PhuongThuc)
                .HasMaxLength(50)
                .HasColumnName("phuongThuc");
            entity.Property(e => e.SoTien)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("soTien");
            entity.Property(e => e.TrangThaiGiaoDich)
                .HasMaxLength(50)
                .HasColumnName("trangThaiGiaoDich");

            entity.HasOne(d => d.Donhang).WithMany(p => p.Thanhtoans)
                .HasForeignKey(d => d.DonhangId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("thanhtoan$fk_thanhtoan_donhang1");
        });

        modelBuilder.Entity<Thongbao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_thongbao_id");

            entity.ToTable("thongbao");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NgayTao)
                .HasPrecision(0)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ngayTao");
            entity.Property(e => e.NoiDung).HasColumnName("noiDung");
            entity.Property(e => e.TieuDe)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("tieuDe");
            entity.Property(e => e.TrangThai)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("trangThai");
        });

        modelBuilder.Entity<ThongbaoHasKhachhang>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("thongbao_has_khachhang");

            entity.HasIndex(e => e.KhachhangId, "fk_thongbao_has_khachhang_khachhang1_idx");

            entity.HasIndex(e => e.ThongbaoId, "fk_thongbao_has_khachhang_thongbao1_idx");

            entity.Property(e => e.KhachhangId).HasColumnName("khachhang_id");
            entity.Property(e => e.ThongbaoId).HasColumnName("thongbao_id");

            entity.HasOne(d => d.Khachhang).WithMany()
                .HasForeignKey(d => d.KhachhangId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("thongbao_has_khachhang$fk_thongbao_has_khachhang_khachhang1");

            entity.HasOne(d => d.Thongbao).WithMany()
                .HasForeignKey(d => d.ThongbaoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("thongbao_has_khachhang$fk_thongbao_has_khachhang_thongbao1");
        });

        modelBuilder.Entity<ThongbaoHasNhanvien>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("thongbao_has_nhanvien");

            entity.HasIndex(e => e.NhanvienId, "fk_thongbao_has_nhanvien_nhanvien1_idx");

            entity.HasIndex(e => e.ThongbaoId, "fk_thongbao_has_nhanvien_thongbao1_idx");

            entity.Property(e => e.NhanvienId).HasColumnName("nhanvien_id");
            entity.Property(e => e.ThongbaoId).HasColumnName("thongbao_id");

            entity.HasOne(d => d.Nhanvien).WithMany()
                .HasForeignKey(d => d.NhanvienId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("thongbao_has_nhanvien$fk_thongbao_has_nhanvien_nhanvien1");

            entity.HasOne(d => d.Thongbao).WithMany()
                .HasForeignKey(d => d.ThongbaoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("thongbao_has_nhanvien$fk_thongbao_has_nhanvien_thongbao1");
        });

        modelBuilder.Entity<Yeucaudoihang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_yeucaudoihang_id");

            entity.ToTable("yeucaudoihang");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LyDo)
                .HasMaxLength(255)
                .HasColumnName("lyDo");
            entity.Property(e => e.NgayYeuCau)
                .HasPrecision(0)
                .HasColumnName("ngayYeuCau");
            entity.Property(e => e.TrangThai).HasColumnName("trangThai");
        });

        modelBuilder.Entity<Yeucautrahang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_yeucautrahang_id");

            entity.ToTable("yeucautrahang");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GiaTriTra)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("giaTriTra");
            entity.Property(e => e.LyDo).HasColumnName("lyDo");
            entity.Property(e => e.NgayHoanTien)
                .HasPrecision(0)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ngayHoanTien");
            entity.Property(e => e.NgayYeuCau)
                .HasPrecision(0)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ngayYeuCau");
            entity.Property(e => e.SoLuongTra)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("soLuongTra");
            entity.Property(e => e.SoTienHoanTra)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("soTienHoanTra");
            entity.Property(e => e.TrangThai)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("trangThai");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
