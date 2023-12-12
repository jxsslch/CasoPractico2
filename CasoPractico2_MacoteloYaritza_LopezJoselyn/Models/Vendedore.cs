using System;
using System.Collections.Generic;

namespace CasoPractico2_MacoteloYaritza_LopezJoselyn.Models;

public partial class Vendedore
{
    public string NombreVendedor { get; set; } = null!;

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
