using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Descripción breve de EncapCategoria
/// </summary>
/// 
[Serializable]
[Table("categoria", Schema = "productos")]
public class EncapCategoria
{
    private int id;
    private string categoria;

    [Key]
    [Column("id")]
    public int Id { get => id; set => id = value; }
    [Column("nombre")]
    public string Categoria { get => categoria; set => categoria = value; }
}