using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_usuario_index_usuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Valido"] != null && ((EncapUsuario)Session["Valido"]).Rol_id == 4)
        {

        }
        else
        {
            Response.Redirect("../login.aspx");
        }
    }
}