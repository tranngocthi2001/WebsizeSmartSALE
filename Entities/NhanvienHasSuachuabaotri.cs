using System;
using System.Collections.Generic;

namespace DEMOwebAPI.Entities;

public partial class NhanvienHasSuachuabaotri
{
    public int SuachuabaotriId { get; set; }

    public int NhanvienId { get; set; }

    public virtual Nhanvien Nhanvien { get; set; } = null!;

    public virtual Suachuabaotri Suachuabaotri { get; set; } = null!;
}
