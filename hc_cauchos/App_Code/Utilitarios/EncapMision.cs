using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de EncapMision
/// </summary>
/// {
[Serializable]
[Table("mision", Schema = "mision_vision")]
public class EncapMision
{
    private int id;
    private string mision;
   
    [Key]
    [Column("id")]
    public int Id { get => id; set => id = value; }
    [Column("mision")]
    public string Mision { get => mision; set => mision = value; }
   
}