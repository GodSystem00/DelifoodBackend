using System;
using System.Collections.Generic;
namespace Delifood.Models
{
 public class Compra
 {
 public int CompraID { get; set; }
 public string codigo { get; set; }
 public float Importe { get; set; }
public Boolean ConFactura { get; set; }
public Boolean ConBoleta { get; set; }
public Boolean SoloEfectivo { get; set; }
public int ClienteID{get;set;}
 public Cliente Cliente{get;set;}

}
}