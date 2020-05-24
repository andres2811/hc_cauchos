using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_reportes_ReporteProveedor : System.Web.UI.Page
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
        pintarReporte();
    }
    protected void pintarReporte()
    {
        //Asignamos a CRS un CRS Que Esta aputando a un reporte En Reportes
        CRS_Proveedor.ReportDocument.SetDataSource(informacionReporte());
        CRV_Proveedor.ReportSource = CRS_Proveedor;
    }
    protected DataSet informacionReporte()
    {
        Inventario informe = new Inventario();//instanciamos el data set
        List<EncapPedidoProveedor> listPedido = new DAOAdmin().ConsultarPedidoProveedor();
        
        DataTable datos = informe.PedidoProveedor;//del data set tome el datatable inventario
        
        DataRow fila;
       

        foreach (EncapPedidoProveedor registro in listPedido)
        {
            fila = datos.NewRow();
            fila["Id"] = registro.Id;
            fila["Proveedor"] = registro.Nombre_proveedor;
            fila["Valor"] = registro.Valor;
            fila["TiempoEntrega"] = registro.T_entrega;
            fila["Estado"] = registro.Estado;

          

            datos.Rows.Add(fila);
           
           
            
          
        }

       
        return informe;
        
    }
}