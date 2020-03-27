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
        L_nombreAdmin.Text =((EncapUsuario)Session["Valido"]).Nombre;
        L_nombreAdmin0.Text= ((EncapUsuario)Session["Valido"]).Nombre;


    }
}
