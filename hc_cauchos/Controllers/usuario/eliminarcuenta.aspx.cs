using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_usuario_eliminarcuenta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EncapUsuario User = new EncapUsuario();
        User = new DAOAdmin().UsuarioActivo((string)Session["Nombre"]);
        if (User.Sesion == null)
        {
            Response.Redirect("../home.aspx");
        }
        BTN_si.Visible = false;
        BTN_no.Visible = false;
        LB_Seguro.Visible = false;
    }

    protected void IB_eliminar_Click(object sender, ImageClickEventArgs e)
    {
        BTN_si.Visible = true;
        BTN_no.Visible = true;
        LB_Seguro.Visible = true;
    }

    protected void BTN_si_Click(object sender, EventArgs e)
    {
        int iduser = ((EncapUsuario)Session["Valido"]).User_id;
        EncapUsuario eliminar = new EncapUsuario();
        eliminar.User_id = iduser;
        new DAOUser().EliminarCuenta(eliminar);
        Session["Valido"] = null;
        Response.Redirect("../home.aspx");
    }

    protected void BTN_no_Click(object sender, EventArgs e)
    {
        BTN_si.Visible = false;
        BTN_no.Visible = false;
        LB_Seguro.Visible = false;
    }
}