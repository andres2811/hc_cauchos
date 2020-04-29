using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de EncapMarca
/// </summary>
/// 
[Serializable]
[Table("marca_carro", Schema = "productos")]
public class EncapMarca
{
    private int id;
    private string marca;

    [Key]
    [Column("id")]
    public int Id { get => id; set => id = value; }
    [Column("nombre")]
    public string Marca { get => marca; set => marca = value; }

}