using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_domiciliario_entregas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int iddomi = ((EncapUsuario)Session["Valido"]).User_id;
        Session["domiid"] = iddomi;

    }

    protected void R_pedido_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        int id_pedido = int.Parse(((Label)e.Item.FindControl("Id")).Text);
        new DAODomiciliario().ActualizarNovedadPedido(id_pedido);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "myAlert", "alert('Se ha realizado la entrega satisfactoria del pedido No.00" + id_pedido.ToString() + "');", true);
        Response.Redirect("entregas.aspx");


    }
}