using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de EncapMunicipio
/// </summary>
[Serializable]
[Table("municipios", Schema = "lugares")]

public class EncapMunicipio
{
    private int id;
    private string nombre;
    private int id_de;


    [Key]
    [Column("id")]
    public int Id { get => id; set => id = value; }
    [Column("nombre")]
    public string Nombre { get => nombre; set => nombre = value; }
    
}