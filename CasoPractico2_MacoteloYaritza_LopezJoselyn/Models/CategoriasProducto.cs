using System;
using System.Collections.Generic;

namespace CasoPractico2_MacoteloYaritza_LopezJoselyn.Models;

public partial class CategoriasProducto
{
    public string NombreCategoria { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
