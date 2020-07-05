using System;
using System.Collections.Generic;
namespace Delifood.Models
{
 public class Vendedor
 {
 public int VendedorID { get; set; }
 public string Nombre { get; set; }
 public string DNI { get; set; }
 public ICollection<Producto> Productos{get;set;}
 public int MercadoID{ get; set; }

}
}