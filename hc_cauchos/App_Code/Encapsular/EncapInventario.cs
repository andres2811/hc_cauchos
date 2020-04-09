using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
/// <summary>
/// Descripción breve de EncapInventario
/// </summary>
/// 
[Serializable]
[Table("inventario", Schema = "administrador")]
public class EncapInventario
{
    private int id;
    private byte[] imagen;
    private string titulo;
    private string referencia;
    private int precio;
    private int ca_actual;
    private int ca_minima;
    private int id_marca;
    private int id_categoria;
    private int id_estado;
    private string nombre_marca;
    private string nombre_categoria;

    private string estado;

    [Key]
    [Column("id")]
    public int Id { get => id; set => id = value; }
    [Column("imagen")]
    public byte[] Imagen { get => imagen; set => imagen = value; }
    [Column("titulo")]
    public string Titulo { get => titulo; set => titulo = value; }
    [Column("referencia")]
    public string Referencia { get => referencia; set => referencia = value; }
    [Column("precio")]
    public int Precio { get => precio; set => precio = value; }
    [Column("cant_actual")]
    public int Ca_actual { get => ca_actual; set => ca_actual = value; }
    [Column("cant_minima")]
    public int Ca_minima { get => ca_minima; set => ca_minima = value; }
    [Column("id_marca")]
    public int Id_marca { get => id_marca; set => id_marca = value; }
    [Column("id_categoria")]
    public int Id_categoria { get => id_categoria; set => id_categoria = value; }
    [Column("id_estado")]
    public int Id_estado { get => id_estado; set => id_estado = value; }
    [NotMapped]
    public string Nombre_marca { get => nombre_marca; set => nombre_marca = value; }
    [NotMapped]
    public string Nombre_categoria { get => nombre_categoria; set => nombre_categoria = value; }
    [NotMapped]
    public string Estado { get => estado; set => estado = value; }
}