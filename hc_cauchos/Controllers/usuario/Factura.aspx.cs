using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_usuario_Factura : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EncapUsuario User = new EncapUsuario();
        User = new DAOAdmin().UsuarioActivo2((string)Session["Correo"]);
        if (User == null)
        {
            Response.Redirect("../home.aspx");
        }
        if (User.Rol_id != 4)
        {
            Response.Redirect("../home.aspx");
        }
        pintarReporte();
    }
    protected void pintarReporte()
    {

        //Asignamos a CRS un CRS Que Esta aputando a un reporte En Reportes
        CRS_Factura.ReportDocument.SetDataSource(informacionReporte());
        CRV_Factura.ReportSource = CRS_Factura;
    }
    protected DataSet informacionReporte()
    {
        Inventario informe = new Inventario();//instanciamos el data set
        List<EncapProducto_pedido> list = new DAOUser().ConsultarProductosPedido((int)Session["Id_fac"]);

        DataTable datos = informe.FacturaVentanilla;//del data set tome el datatable inventario
        DataRow fila;
        Mapeo db = new Mapeo();
        string Dirrecion = new DAOUser().ConsultarDirrecion((int)Session["Id_fac"]); 
        string Cliente = new DAOUser().ConsultarUsuarioPedido((int)Session["Id_fac"]);
        double aux = 0;
        foreach (EncapProducto_pedido registro in list)
        {
            fila = datos.NewRow();

            fila["Producto"] = registro.Nombre_producto;
            fila["Referencia"] = registro.Referencia;
            fila["Precio"] = registro.Precio;
            fila["Cantidad"] = registro.Cantidad;
            fila["Total"] = registro.Total;
            fila["Id_Pedido"] = (int)Session["Id_fac"];
            aux = aux + registro.Total;
            fila["Total_fin"] = aux;
            fila["Dirreccion"] = Dirrecion;
            fila["Cliente"] = Cliente;
            datos.Rows.Add(fila);
        }

        return informe;
    }
}