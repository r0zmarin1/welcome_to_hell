﻿using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace hell_is_closed;

public partial class Rack
{
    public int Id { get; set; }

    /// <summary>
    /// название &quot;стеллажа&quot;
    /// </summary>
    public string Title { get; set; } = null!;

    public int IdDevil { get; set; }

    public int YearBuy { get; set; }

    /// <summary>
    /// макс кол-во применений
    /// </summary>
    public int UseCount { get; set; }

    /// <summary>
    /// кол-во применений
    /// </summary>
    public int CurrentCount { get; set; }

    public virtual Devil IdDevilNavigation { get; set; } 

    public override string ToString()
    {
        return $" {Title}, ответственный {IdDevilNavigation?.Nick}, дата покупки {YearBuy}, макс кол-во применений {UseCount}, использовано {CurrentCount} раз";
    }

    public static explicit operator RackBl (Rack rack)
    {
        return new RackBl { CurrentCount = rack.CurrentCount, Id = rack.Id, IdDevil = rack.IdDevil,
            Title = rack.Title, UseCount = rack.UseCount, YearBuy = rack.YearBuy };
    }

}


public partial class RackBl
{
    public int Id { get; set; }

    /// <summary>
    /// название &quot;стеллажа&quot;
    /// </summary>
    public string Title { get; set; } = null!;

    public int IdDevil { get; set; }

    public int YearBuy { get; set; }

    /// <summary>
    /// макс кол-во применений
    /// </summary>
    public int UseCount { get; set; }

    /// <summary>
    /// кол-во применений
    /// </summary>
    public int CurrentCount { get; set; }


 
}