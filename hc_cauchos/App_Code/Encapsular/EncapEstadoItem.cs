using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Descripción breve de EncapEstadoItem
/// </summary>
/// 
[Serializable]
[Table("estado_item", Schema = "usuario")]
public class EncapEstadoItem
{
    private int id;
    private string estado_item;

    [Key]
    [Column("id")]
    public int Id { get => id; set => id = value; }
    [Column("estado")]
    public string Estado_item { get => estado_item; set => estado_item = value; }
}