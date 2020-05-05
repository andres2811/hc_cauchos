using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


/// <summary>
/// Descripción breve de EncapProveedor
/// </summary>
/// 
[Serializable]
[Table("proveedor", Schema = "productos")]
public class EncapProveedor
{
    private int id;
    private string nombre_pro;
    private string contacto;
    private string correo;
    private string tiempo_envio;
    private string nid;
    private string session;
    private Nullable<DateTime> last_modify;
    

    [Key]
    [Column("id_proveedor")]
    public int Id { get => id; set => id = value; }
    [Column("nombre")]
    public string Nombre_pro { get => nombre_pro; set => nombre_pro = value; }
    [Column("contacto")]
    public string Contacto { get => contacto; set => contacto = value; }
    [Column("correo")]
    public string Correo { get => correo; set => correo = value; }
    [Column("tiempo_envio")]
    public string Tiempo_envio { get => tiempo_envio; set => tiempo_envio = value; }
    [Column("nid_proveedor")]
    public string Nid { get => nid; set => nid = value; }
    [Column("session")]
    public string Session { get => session; set => session = value; }
    [Column("last_modify")]
    public DateTime? Last_modify { get => last_modify; set => last_modify = value; }

}