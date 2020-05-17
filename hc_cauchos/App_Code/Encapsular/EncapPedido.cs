﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de EncapPedido
/// </summary>
[Serializable]
[Table("pedidos", Schema = "pedidos")]
public class EncapPedido
{
    private int id;
    private DateTime fecha_pedido;
    private int user_id;
    private int atendido_id;
    private int domiciliario_id;
    private int estado_pedido;
    private double total;
    private string usuario;
    private string estado;
    private string empleado;
    private string domiciliaro;
    private string novedad;
    private int ciu_dep_id;
    private string direccion;
    private int municipio_id;



    [Key]
    [Column("id")]
    public int Id { get => id; set => id = value; }
    [Column("fecha_pedido")]
    public DateTime Fecha_pedido { get => fecha_pedido; set => fecha_pedido = value; }
    [Column("user_id")]
    public int User_id { get => user_id; set => user_id = value; }
    [Column("atendido_id")]
    public int Atendido_id { get => atendido_id; set => atendido_id = value; }
    [Column("domiciliario_id")]
    public int Domiciliario_id { get => domiciliario_id; set => domiciliario_id = value; }
    [Column("estado_pedido")]
    public int Estado_pedido { get => estado_pedido; set => estado_pedido = value; }
    [Column("total")]
    public Double Total { get => total; set => total = value; }
    [NotMapped]
    public string Usuario { get => usuario; set => usuario = value; }
    [NotMapped]
    public string Estado { get => estado; set => estado = value; }
    [NotMapped]
    public string Empleado { get => empleado; set => empleado = value; }
    [NotMapped]
    public string Domiciliaro { get => domiciliaro; set => domiciliaro = value; }
    [Column("novedad")]
    public string Novedad { get => novedad; set => novedad = value; }
    [Column("ciu_dep_id")]
    public int Ciu_dep_id { get => ciu_dep_id; set => ciu_dep_id = value; }
    [Column("direccion")]
    public string Direccion { get => direccion; set => direccion = value; }
    [Column("municipio_id")]
    public int Municipio_id { get => municipio_id; set => municipio_id = value; }
}