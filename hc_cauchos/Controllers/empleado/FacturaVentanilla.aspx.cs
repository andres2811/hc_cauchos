using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_empleado_FacturaVentanilla : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        pintarReporte();
    }
    protected void pintarReporte()
    {

        //Asignamos a CRS un CRS Que Esta aputando a un reporte En Reportes
        CRS_FacturaVentanilla.ReportDocument.SetDataSource(informacionReporte());
        CRV_FacturaVentanilla.ReportSource = CRS_FacturaVentanilla;
    }
    protected DataSet informacionReporte()
    {
        Inventario informe = new Inventario();//instanciamos el data set
        List<EncapProducto_pedido> list = new DAOUser().ConsultarProductosPedido((int)Session["pedido_Id"]);

        DataTable datos = informe.FacturaVentanilla;//del data set tome el datatable inventario
        DataRow fila;

        foreach (EncapProducto_pedido registro in list)
        {
            fila = datos.NewRow();
          
            fila["Producto"] = registro.Nombre_producto;
            fila["Referencia"] = registro.Referencia;
            fila["Precio"] = registro.Precio;
            fila["Cantidad"] = registro.Cantidad;
            fila["Total"] = registro.Total;
            fila["Id_Pedido"] = (int)Session["pedido_Id"];
            datos.Rows.Add(fila);
        }

        return informe;
    }

}