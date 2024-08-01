﻿using System;
using System.Collections.Generic;

namespace kuranmealuygulaması.Models;

public partial class Arapca
{
    public int Index { get; set; }

    public int SureId { get; set; }

    public int AyetId { get; set; }

    public string Ayet { get; set; } = null!;

    public virtual SureTable Sure { get; set; } = null!;
}
