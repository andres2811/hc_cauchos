using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de EncapProducto_pedido
/// </summary>
[Serializable]
[Table("productos_pedidos", Schema = "pedidos")]
public class EncapProducto_pedido
{
    private int id;
    private int pedido_id;
    private int producto_id;
    private int cantidad;
    private double precio;
    private double total;

    [Key]
    [Column("id")]
    public int Id { get => id; set => id = value; }
    [Column("pedido_id")]
    public int Pedido_id { get => pedido_id; set => pedido_id = value; }
    [Column("producto_id")]
    public int Producto_id { get => producto_id; set => producto_id = value; }
    [Column("cantidad")]
    public int Cantidad { get => cantidad; set => cantidad = value; }
    [Column("precio")]
    public double Precio { get => precio; set => precio = value; }
    [Column("total")]
    public double Total { get => total; set => total = value; }
}