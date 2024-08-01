using System;
using System.Collections.Generic;

namespace kuranmealuygulaması.Models;

public partial class Mealler
{
    public int MealId { get; set; }

    public string Cevrimen { get; set; } = null!;

    public string? CevirmenHakinda { get; set; }

    public string? Resmi { get; set; }

    public string? Meal { get; set; }
}
