using System;
using System.Collections.Generic;
namespace Delifood.Models
{
 public class Cliente
 {
 public int ClienteID { get; set; }
 public string Usuario { get; set; }
 public string Password { get; set; }
public string Correo { get; set; }
 public string Nombre { get; set; }
public string Apellido { get; set; }
 public DateTime FechaNacimiento { get; set; }
public ICollection<Compra> Compras{get;set;}
public ICollection<CompraMercado> CompraMercados{get;set;}
}
}