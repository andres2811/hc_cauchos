using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_usuario_pedidos_finalizados : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EncapUsuario User = new EncapUsuario();
        User = new DAOAdmin().UsuarioActivo2((string)Session["Correo"]);
        if (User == null)
        {
            Response.Redirect("../home.aspx");
        }
        if (User.Rol_id != 4)
        {
            Response.Redirect("../home.aspx");
        }
        //obtengo el id del domiciliario y lo almaceno en una session
        int idusu = ((EncapUsuario)Session["Valido"]).User_id;
        Session["clienid"] = idusu;
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        var btn_factura = e.Item.FindControl("Btn_factura") as Button;
        var lb_idfac = e.Item.FindControl("Id") as Label;
        Session["Id_fac"] = Convert.ToInt32(lb_idfac.Text);
        Response.Redirect("Factura.aspx");
    }
}