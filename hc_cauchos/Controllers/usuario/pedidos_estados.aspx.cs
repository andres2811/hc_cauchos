using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_usuario_pedidos_estados : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //obtengo el id del domiciliario y lo almaceno en una session
        int idusu = ((EncapUsuario)Session["Valido"]).User_id;
        Session["clienid"] = idusu;
    }
}