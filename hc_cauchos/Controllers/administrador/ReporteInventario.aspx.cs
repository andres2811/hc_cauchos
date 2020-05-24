using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_reportes_ReporteInventario : System.Web.UI.Page
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
        CRS_Inventario.ReportDocument.SetDataSource(informacionReporte());
        CRV_Inventario.ReportSource = CRS_Inventario;
    }
    protected DataSet informacionReporte()
    {
        Inventario informe = new Inventario ();//instanciamos el data set
        List<EncapInventario> listInventario = new DAOAdmin().ConsultarInventario();

        DataTable datos = informe._Inventario;//del data set tome el datatable inventario
        DataRow fila;

        foreach (EncapInventario registro in listInventario)
        {
            fila = datos.NewRow();
            fila["Id"] = registro.Id;
            fila["Titulo"] = registro.Titulo;
           
            fila["Precio"] = registro.Precio;
            fila["Ca_actual"] = registro.Ca_actual;
            fila["Ca_minima"] = registro.Ca_minima;
            fila["Referencia"] = registro.Referencia;
            fila["Estado"] = registro.Estado;
            fila["Categoria"] = registro.Nombre_categoria;
            fila["Marca"] = registro.Nombre_marca;
            fila["Imagen"] = obtenerImagen(registro.Imagen);
            datos.Rows.Add(fila);
        }

        return informe;
    }

    protected byte[] obtenerImagen(string url)
    {
        //Convercion de la imagen
        string urlImagen = Server.MapPath(url);
        if (!System.IO.File.Exists(urlImagen))
        {
            urlImagen = Server.MapPath("~\\Inventario\\" + "NoDisponible.jpg");
        }
        byte[] fileBytes = System.IO.File.ReadAllBytes(urlImagen);
        return fileBytes;
    }

    protected void CRV_Inventario_Init(object sender, EventArgs e)
    {

    }
}