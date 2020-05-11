using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_empleado_venta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BTN_BuscarClien_Click(object sender, EventArgs e)
    {
        GV_Clientes.DataSourceID = "ODS_ClientesCedu";
    }

    protected void BTN_buscarTodos_Click(object sender, EventArgs e)
    {
        GV_Clientes.DataSourceID = "ODS_Clientes";
    }

    protected void BTN_RegistrarCliente_Click(object sender, EventArgs e)
    {
        Response.Redirect("registrarCliente.aspx");
    }
}