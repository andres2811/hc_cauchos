using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_domiciliario_domiciliario : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        L_nombreAdmin.Text = ((EncapUsuario)Session["Valido"]).Nombre;
        L_nombreAdmin0.Text = ((EncapUsuario)Session["Valido"]).Nombre;
    }

    protected void BTN_cerrar_Sesion_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("../home.aspx");
    }
}
