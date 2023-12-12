using System;
using System.Collections.Generic;

namespace CasoPractico2_MacoteloYaritza_LopezJoselyn.Models;

public partial class Producto
{
    public string NombreProducto { get; set; } = null!;

    public string? NombreCategoria { get; set; }

    public string? NombreMarca { get; set; }

    public decimal? Precio { get; set; }

    public virtual CategoriasProducto? NombreCategoriaNavigation { get; set; }

    public virtual Marca? NombreMarcaNavigation { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
