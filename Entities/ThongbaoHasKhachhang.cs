using System;
using System.Collections.Generic;

namespace DEMOwebAPI.Entities;

public partial class ThongbaoHasKhachhang
{
    public int KhachhangId { get; set; }

    public int ThongbaoId { get; set; }

    public virtual Khachhang Khachhang { get; set; } = null!;

    public virtual Thongbao Thongbao { get; set; } = null!;
}
