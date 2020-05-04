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
    private string productos;
    private double valor_total;

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
    [Column("productos")]
    public string Productos { get => productos; set => productos = value; }
    [Column("valor_total")]
    public double Valor_total { get => valor_total; set => valor_total = value; }
}