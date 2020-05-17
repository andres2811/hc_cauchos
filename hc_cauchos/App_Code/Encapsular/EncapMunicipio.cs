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
    private int municipio_id;


    [Key]
    [Column("id")]
    public int Id { get => id; set => id = value; }
    [Column("nombre")]
    public string Nombre { get => nombre; set => nombre = value; }
    [Column("municipio_id")]
    public int Municipio_id { get => municipio_id; set => municipio_id = value; }
}