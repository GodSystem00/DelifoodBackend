using System;
using System.Collections.Generic;
namespace Delifood.Models
{
 public class CompraMercado
 {
     public int CompraMercadoID{get; set;}
 public int CompraID { get; set; }
 public int MercadoID { get; set; }
public Compra Compra{ get; set; }
public Mercado Mercado { get; set; }
}
}