using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
/// <summary>
/// Descripción breve de producto
/// </summary>
/// 
[Serializable]
[Table("aux", Schema = "sistema")]
public class producto
{

        private int id;
        private string referencia;
        private int cantidad;
        private float valor;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("referencia")]
        public string Referencia { get => referencia; set => referencia = value; }
        [Column("cantidad")]
        public int Cantidad { get => cantidad; set => cantidad = value; }
        [Column("valor")]
        public float Valor { get => valor; set => valor = value; }
}