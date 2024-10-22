﻿using System;
using System.Collections.Generic;

namespace hell_is_closed;

public partial class Devil
{
    public int Id { get; set; }

    /// <summary>
    /// погоняло
    /// </summary>
    public string Nick { get; set; } = null!;

    /// <summary>
    /// кол-во душ
    /// </summary>
    public int Rank { get; set; }

    public int Year { get; set; }

    public virtual ICollection<Rack> Racks { get; set; } = new List<Rack>();

    public override string ToString()
    {
        return $" Раб {Nick}, Ранг {Rank}, года {Year}";
    }
}
