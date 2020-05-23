using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de EncapVenta
/// </summary>
public class EncapVenta
{
    
        private double mes;
        private double año;
        private double total;
        private int facturas;

       
        public double Mes { get => mes; set => mes = value; }
        public double Ano { get => año; set => año = value; }
        public double Total { get => total; set => total = value; }
        public int Facturas { get => facturas; set => facturas = value; }
}