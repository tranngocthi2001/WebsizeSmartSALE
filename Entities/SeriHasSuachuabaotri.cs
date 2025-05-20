using System;
using System.Collections.Generic;

namespace DEMOwebAPI.Entities;

public partial class SeriHasSuachuabaotri
{
    public int SuachuabaotriId { get; set; }

    public int SeriId { get; set; }

    public virtual Seri Seri { get; set; } = null!;

    public virtual Suachuabaotri Suachuabaotri { get; set; } = null!;
}
