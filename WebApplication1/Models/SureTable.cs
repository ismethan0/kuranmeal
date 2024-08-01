using System;
using System.Collections.Generic;

namespace kuranmealuygulaması.Models;

public partial class SureTable
{
    public int SureId { get; set; }

    public int AyetSayisi { get; set; }

    public int KuranSirasi { get; set; }

    public string NuzulSirasi { get; set; } = null!;

    public string Sureler { get; set; } = null!;

    public virtual ICollection<AnadoluTurkcesi> AnadoluTurkcesis { get; set; } = new List<AnadoluTurkcesi>();

    public virtual ICollection<Anonim> Anonims { get; set; } = new List<Anonim>();

    public virtual ICollection<Arapca> Arapcas { get; set; } = new List<Arapca>();

    public virtual ICollection<AzeriTurkcesi> AzeriTurkcesis { get; set; } = new List<AzeriTurkcesi>();

    public virtual ICollection<DiyanetEski> DiyanetEskis { get; set; } = new List<DiyanetEski>();

    public virtual ICollection<DiyanetYeni> DiyanetYenis { get; set; } = new List<DiyanetYeni>();

    public virtual ICollection<Edipyuksel> Edipyuksels { get; set; } = new List<Edipyuksel>();

    public virtual ICollection<ElmaliHamdiOrginal> ElmaliHamdiOrginals { get; set; } = new List<ElmaliHamdiOrginal>();

    public virtual ICollection<ElmaliHamdi> ElmaliHamdis { get; set; } = new List<ElmaliHamdi>();

    public virtual ICollection<Esed> Eseds { get; set; } = new List<Esed>();

    public virtual ICollection<Suleymaniye> Suleymaniyes { get; set; } = new List<Suleymaniye>();

    public virtual ICollection<YasarNuriInısAyetler> YasarNuriInısAyetlers { get; set; } = new List<YasarNuriInısAyetler>();
}
