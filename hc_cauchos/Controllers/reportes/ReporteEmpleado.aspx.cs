using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_reportes_ReporteEmpleado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Asignamos a CRS un CRS Que Esta aputando a un reporte En Reportes
        CRS_Empleado.ReportDocument.SetDataSource(informacionReporte());
        CRV_Empleado.ReportSource = CRS_Empleado;
    }
    protected DataSet informacionReporte()
    {
        Inventario informe = new Inventario();//instanciamos el data set
        List<EncapPedido> listPedido = new DAOAdmin().ConsultarVentas();

        DataTable datos = informe.VentaEmpleado;//del data set tome el datatable inventario

        DataRow fila;


        foreach (EncapPedido registro in listPedido)
        {
            fila = datos.NewRow();
            
            fila["Empleado"] = registro.Empleado;
            fila["Fecha"] = registro.Fecha_pedido;
            fila["Usuario"] = registro.Usuario ;
            fila["Total"] = registro.Total;



            datos.Rows.Add(fila);




        }


        return informe;

    }
}