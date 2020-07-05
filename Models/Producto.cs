using System;
using System.Collections.Generic;
namespace Delifood.Models
{
 public class Producto
 {
 public int ProductoID { get; set; }
 public string Nombre { get; set; }
 public string categoria { get; set; }
public double Precio { get; set; }
public int Stock { get; set; }
public int VendedorID{ get; set; }
public Vendedor Vendedor { get; set; }
}
}