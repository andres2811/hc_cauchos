using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class Views_reportes_ReporteMesAMes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //CRS_Mes.ReportDocument.SetDataSource(informacionReporte());
        //CRV_Mes.ReportSource = CRS_Mes;
        Mapeo db = new Mapeo();
        var resultado = db.pedidos.GroupBy(x => x.Fecha_pedido).Select(x => new { x.Key, Total = x.Max(y => y.Total) }).ToList();
        var rec = db.pedidos.SqlQuery("SELECT date_part('year', pp.fecha_pedido) as año, date_part('month'::text, pp.fecha_pedido) as mes, sum(pp.total) as total_mes, Count(*) as Facturas FROM pedidos.pedidos pp " +
                                                        "WHERE pp.estado_pedido = 6 " +
                                                        "GROUP BY date_part('year', pp.fecha_pedido), date_part('month'::text, pp.fecha_pedido)");




       

        // Create a table from the query.
        //DataTable boundTable = .CopyToDataTable<DataRow>();
    }

    protected DataSet informacionReporte()
    {
        Inventario informe = new Inventario();//instanciamos el data set
        List<EncapPedido> listPedido = new DAOAdmin().ConsultarVentas();

        DataTable datos = informe.VentaEmpleado;//del data set tome el datatable inventario


        Mapeo db = new Mapeo();

        //Hago una consulta y agrupo por fecha pedido
        var resultado = db.pedidos.GroupBy(x => x.Fecha_pedido).Select(x => new { x.Key, Total =x.Max(y => y.Total)}).ToList();
        




        return informe;

    }
}