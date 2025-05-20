using System;
using System.Collections.Generic;

namespace DEMOwebAPI.Entities;

public partial class ChitietphieuxuatHasSuachuabaotri
{
    public int SuachuabaotriId { get; set; }

    public int ChitietphieuxuatId { get; set; }

    public virtual Chitietphieuxuat Chitietphieuxuat { get; set; } = null!;

    public virtual Suachuabaotri Suachuabaotri { get; set; } = null!;
}
