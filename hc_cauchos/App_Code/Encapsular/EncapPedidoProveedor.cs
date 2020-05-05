using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Descripción breve de EncapPedidoProveedor
/// </summary>
/// 
[Serializable]
[Table("pedido_proveedor", Schema = "proveedores")]
public class EncapPedidoProveedor
{
    private int id;
    private int id_producto;
    private int id_proveedor;
    private int id_estado;
    private int valor;
    private string session;
    private Nullable<DateTime> t_entrega;
    private Nullable<DateTime> last_modify;
    private int cant;
    private string nombre_proveedor;
    private string referencia;
    private string estado;

    [Key]
    [Column("id")]
    public int Id { get => id; set => id = value; }
    [Column("producto_id")]
    public int Id_producto { get => id_producto; set => id_producto = value; }
    [Column("proveedor_id")]
    public int Id_proveedor { get => id_proveedor; set => id_proveedor = value; }
    [Column("id_estado_pedido")]
    public int Id_estado { get => id_estado; set => id_estado = value; }
    [Column("valor_total")]
    public int Valor { get => valor; set => valor = value; }
    [Column("session")]
    public string Session { get => session; set => session = value; }
    [Column("last_modify")]
    public DateTime? Last_modify { get => last_modify; set => last_modify = value; }
    [Column("cantidad")]
    public int Cant { get => cant; set => cant = value; }
    [Column("tiempo_entrega")]
    public DateTime? T_entrega { get => t_entrega; set => t_entrega = value; }

    [NotMapped]
    public string Referencia { get => referencia; set => referencia = value; }
    [NotMapped]
    public string Estado { get => estado; set => estado = value; }
    [NotMapped]
    public string Nombre_proveedor { get => nombre_proveedor; set => nombre_proveedor = value; }
   
}
