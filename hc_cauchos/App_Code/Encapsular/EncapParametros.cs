using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de EncapParametros
/// </summary>
[Serializable]
[Table("parametros", Schema = "sistema")]
public class EncapParametros
{
    private int id;
    private string nombre;
    private string valor;

    [Key]
    [Column("id")]
    public int Id { get => id; set => id = value; }
    [Column("nombre")]
    public string Nombre { get => nombre; set => nombre = value; }
    [Column("valor")]
    public string Valor { get; set; }



}