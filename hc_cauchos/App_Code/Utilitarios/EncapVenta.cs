using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
/// <summary>
/// Descripción breve de EncapVenta
/// </summary>
/// 
[Serializable]
[Table("pedidos", Schema = "pedidos")]
public class EncapVenta
{
    
        private double mes;
        private double año;
        private double total;
        private int facturas;
        private int id;

        public double Mes { get => mes; set => mes = value; }
        public double Ano { get => año; set => año = value; }
        public double Total { get => total; set => total = value; }
        public int Facturas { get => facturas; set => facturas = value; }
}