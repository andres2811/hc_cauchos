using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de EncapObjetivo
/// </summary>
[Serializable]
[Table("objetivo", Schema = "mision_vision")]
public class EncapObjetivo
{
    private int id;
    private string objetivo;

    [Key]
    [Column("id")]
    public int Id { get => id; set => id = value; }
    [Column("objetivo")]
    public string Objetivo { get => objetivo; set => objetivo = value; }
}