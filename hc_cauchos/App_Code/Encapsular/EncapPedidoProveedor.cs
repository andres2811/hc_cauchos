using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

/// <summary>
/// Descripción breve de EncapPedidoProveedor
/// </summary>
/// 
[Serializable]
[Table("pedido_proveedor", Schema = "proveedores")]
public class EncapPedidoProveedor
{
    private int id;
    private int id_proveedor;
    private int id_estado;
    private double valor;
    private string session;
    private string elementos;
    private Nullable<DateTime> t_entrega;
    private Nullable<DateTime> last_modify;
    private string nombre_proveedor;
    private string estado;

    [Key]
    [Column("id")]
    public int Id { get => id; set => id = value; }
    
    [Column("proveedor_id")]
    public int Id_proveedor { get => id_proveedor; set => id_proveedor = value; }
    [Column("id_estado_pedido")]
    public int Id_estado { get => id_estado; set => id_estado = value; }
    [Column("valor_total")]
    public double Valor { get => valor; set => valor = value; }
    [Column("session")]
    public string Session { get => session; set => session = value; }
    [Column("last_modify")]
    public DateTime? Last_modify { get => last_modify; set => last_modify = value; }
    [Column("tiempo_entrega")]
    public DateTime? T_entrega { get => t_entrega; set => t_entrega = value; }
    [Column("elementos")]
    public string Elementos { get => elementos; set => elementos = value; }
    [NotMapped]
    public string Estado { get => estado; set => estado = value; }
    [NotMapped]
    public string Nombre_proveedor { get => nombre_proveedor; set => nombre_proveedor = value; }
    
}
