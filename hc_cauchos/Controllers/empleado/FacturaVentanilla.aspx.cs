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
        EncapUsuario User = new EncapUsuario();
        User = new DAOAdmin().UsuarioActivo2((string)Session["Correo"]);
        if (User == null || Session["Valido"] == null)
        {
            Response.Redirect("../home.aspx");
        }
        if (User.Rol_id != 2)
        {
            Response.Redirect("../home.aspx");
        }
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

       
       
        string Cliente = new DAOUser().ConsultarUsuarioPedido((int)Session["pedido_Id"]);
        string Dirrecion = new DAOUser().ConsultarDirrecion((int)Session["pedido_Id"]);

        double aux = 0;
        foreach (EncapProducto_pedido registro in list)
        {
            fila = datos.NewRow();
          
            fila["Producto"] = registro.Nombre_producto;
            fila["Referencia"] = registro.Referencia;
            fila["Precio"] = registro.Precio;
            fila["Cantidad"] = registro.Cantidad;
            fila["Total"] = registro.Total;
            fila["Id_Pedido"] = (int)Session["pedido_Id"];
            aux = aux + registro.Total;
            fila["Total_fin"] = aux;
            fila["Dirreccion"] = Dirrecion;
            fila["Cliente"] = Cliente;
            datos.Rows.Add(fila);
        }

        return informe;
    }

}