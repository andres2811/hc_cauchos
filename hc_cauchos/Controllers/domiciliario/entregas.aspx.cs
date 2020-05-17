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

        //obtengo el id del domiciliario y lo almaceno en una session
        int iddomi = ((EncapUsuario)Session["Valido"]).User_id;
        Session["domiid"] = iddomi;

    }

    protected void R_pedido_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        ClientScriptManager cm = this.ClientScript;
        EncapPedido fin = new EncapPedido();
        fin.Id = int.Parse(((Label)e.Item.FindControl("Id")).Text);
        fin.Fecha_pedido_fin = DateTime.Now;
        //otorgo a pedido fecha de finalizacion y update de estado
        new DAODomiciliario().ActualizarNovedadPedido(fin);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "myAlert", "alert('Se ha realizado la entrega satisfactoria del pedido No.00');", true);
        Response.Redirect("entregas.aspx");


    }
}