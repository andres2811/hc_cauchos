using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_domiciliario_index_domiciliario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Valido"] != null && ((EncapUsuario)Session["Valido"]).Rol_id == 3)
        {

        }
        else
        {
            Response.Redirect("../login.aspx");
        }
    }
}