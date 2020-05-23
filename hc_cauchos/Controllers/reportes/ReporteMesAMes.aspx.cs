using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Npgsql;

public partial class Views_reportes_ReporteMesAMes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CRS_Mes.ReportDocument.SetDataSource(informacionReporte());
        CRV_Mes.ReportSource = CRS_Mes;
        


       

    }

    protected DataSet informacionReporte()
    {
        Inventario informe = new Inventario();//instanciamos el data set
        
          
        DataTable datos = informe.VentaMes;//del data set tome el datatable inventario

       
        DataRow fila;


        //------------------------------------------------------------
        //SQL agrupo mes a mes las ventas
        string SQl = @"SELECT date_part('year', pp.fecha_pedido) as año, date_part('month'::text, pp.fecha_pedido) as mes, sum(pp.total) as total_mes, Count(*) as Facturas FROM pedidos.pedidos pp WHERE pp.estado_pedido = 6 GROUP BY date_part('year', pp.fecha_pedido), date_part('month'::text, pp.fecha_pedido)";
        var con = new NpgsqlConnection("Host= localhost; Database=hc_cauchos; UserId=postgres; Password=12345; Port= 5432;");
        //Creamos la conexiom

        using (var command = new NpgsqlCommand(SQl , con))
        {
            con.Open();
            using (var reader = command.ExecuteReader())
            {
                var list = new List<EncapVenta>();
                while (reader.Read()) { 
                   
                    fila = datos.NewRow();
                    fila["Ano"] = Convert.ToString( reader.GetDouble(0));
                    fila["Mes"] = Convert.ToInt32( reader.GetDouble(1));
                    fila["Total"] = reader.GetDouble(2);
                    fila["facturas"] = reader.GetInt32(3);
                    datos.Rows.Add(fila);
                }
            }
        }
    

        





        return informe;

    }
}