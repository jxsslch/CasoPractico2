using System;
using System.Collections.Generic;

namespace CasoPractico2_MacoteloYaritza_LopezJoselyn.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? CorreoElectronico { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
