using System;
using System.Collections.Generic;

namespace CasoPractico2_MacoteloYaritza_LopezJoselyn.Models;

public partial class Venta
{
    public int IdVenta { get; set; }

    public string? NombreVendedor { get; set; }

    public string? NombreProducto { get; set; }

    public DateOnly? FechaVenta { get; set; }

    public int? Cantidad { get; set; }

    public int? IdCliente { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Producto? NombreProductoNavigation { get; set; }

    public virtual Vendedore? NombreVendedorNavigation { get; set; }
}
