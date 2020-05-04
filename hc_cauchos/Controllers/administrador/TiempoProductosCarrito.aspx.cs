using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_administrador_TiempoProductosCarrito : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BTN_confirmar_T_Click(object sender, ImageClickEventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        EncapParametros tiempocarrito = new EncapParametros();
        tiempocarrito.Id = 1;
        tiempocarrito.Nombre = "tiempocarrito";
        tiempocarrito.Valor = TB_cantidad_T.Text;
        new DAOAdmin().ActualizarTiempoCarrito(tiempocarrito);
        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('Se ha cambiado el parametro correctamente.');</script>");
    }
}