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
        EncapUsuario User = new EncapUsuario();
        User = new DAOAdmin().UsuarioActivo2((string)Session["Correo"]);
        if (User == null)
        {
            Response.Redirect("../home.aspx");
        }
        if (User.Rol_id != 1)
        {
            Response.Redirect("../home.aspx");
        }
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
        /*string SQl = @"SELECT date_part('year', pp.fecha_pedido) as año, date_part('month'::text, pp.fecha_pedido) as mes, sum(pp.total) as total_mes, Count(*) as Facturas FROM pedidos.pedidos pp WHERE pp.estado_pedido = 6 GROUP BY date_part('year', pp.fecha_pedido), date_part('month'::text, pp.fecha_pedido)";
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
        }*/



        //Prueba Por entity

        List<EncapVenta> listVentas = new DAOUser().ConsultarVentasMesAMes();

        DataTable datos2 = informe.VentaMes;//del data set tome el datatable inventario
        DataRow fila2;

        foreach (EncapVenta registro in listVentas)
        {
            fila2 = datos2.NewRow();
            fila2["Mes"] = registro.Mes;
            fila2["Ano"] = registro.Ano;

            fila2["total"] = registro.Total;
            fila2["Facturas"] = registro.Facturas;
           
            datos2.Rows.Add(fila2);
        }


        return informe;

    }
}