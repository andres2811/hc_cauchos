using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_administrador_admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //obtengo nombre de la sesion y pongo en html
        //L_nombreAdmin.Text =((EncapUsuario)Session["Valido"]).Nombre;
        //L_nombreAdmin0.Text= ((EncapUsuario)Session["Valido"]).Nombre;


    }

    protected void BTN_cerrar_Sesion_Click(object sender, EventArgs e)
    {

        Session.Abandon();
        EncapUsuario User = new EncapUsuario();
        User = new DAOAdmin().UsuarioActivo((string)Session["Nombre"]);
        User.Ip_ = null;
        User.Mac_ = null;
        User.Sesion = null;
        new DAOAdmin().ActualizarUsuario(User);
        Response.Redirect("../home.aspx");

    }
}
