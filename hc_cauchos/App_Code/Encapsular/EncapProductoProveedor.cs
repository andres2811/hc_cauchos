using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Descripción breve de EncapProductoProveedor
/// </summary>
/// 
[Serializable]
[Table("producto_proveedor", Schema = "proveedores")]
public class EncapProductoProveedor
{
    private int id;
    private int proveedor_id;
    private int producto_id;
    private int cantidad;
    private int precio;
    private string session;
    private Nullable<DateTime> last_modify;
    private string referencia;
    private string nombre_producto;

    [Key]
    [Column("id")]
    public int Id { get => id; set => id = value; }
    [Column("id_proveedor")]
    public int Proveedor_id { get => proveedor_id; set => proveedor_id = value; }
    [Column("id_producto")]
    public int Producto_id { get => producto_id; set => producto_id = value; }
    [Column("cantidad")]
    public int Cantidad { get => cantidad; set => cantidad = value; }
    [Column("precio")]
    public int Precio { get => precio; set => precio = value; }
    [Column("session")]
    public string Session { get => session; set => session = value; }
    [Column("last_modify")]
    public DateTime? Last_modify { get => last_modify; set => last_modify = value; }
    [NotMapped]
    public string Referencia { get => referencia; set => referencia = value; }
    [NotMapped]
    public string Nombre_producto { get => nombre_producto; set => nombre_producto = value; }

    


}