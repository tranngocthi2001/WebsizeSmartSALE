using System;
using System.Collections.Generic;

namespace DEMOwebAPI.Entities;

public partial class ThongbaoHasNhanvien
{
    public int ThongbaoId { get; set; }

    public int NhanvienId { get; set; }

    public virtual Nhanvien Nhanvien { get; set; } = null!;

    public virtual Thongbao Thongbao { get; set; } = null!;
}
