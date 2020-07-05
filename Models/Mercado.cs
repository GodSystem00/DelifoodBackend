using System;
using System.Collections.Generic;
namespace Delifood.Models
{
 public class Mercado
 {
 public int MercadoID { get; set; }
 public string Nombre { get; set; }
 public string Direccion { get; set; }
public float latitud { get; set; }
 public float longitud { get; set; }
public ICollection<CompraMercado> CompraMercados{get;set;}
}
}