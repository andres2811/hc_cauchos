using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_usuario_catalogoUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BTNI_carritoAdd_Click(object sender, ImageClickEventArgs e)
    { 

    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        ClientScriptManager cm = this.ClientScript;
        //se obtiene el item del inventario
        EncapInventario productos = (EncapInventario)e.Item.DataItem;
        //primero buscar el control y validar que sea diferente de NULL 
        if (e.Item.FindControl("TB_cantidad") != null)
        {
            //obtengo los valores de los controles y verifico cantidad de pedir a existente
            if (int.Parse(((TextBox)e.Item.FindControl("TB_cantidad")).Text) > int.Parse(((Label)e.Item.FindControl("Ca_actualLabel")).Text))
            {
               
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('Cantidad no disponible' );</script>");
                return;
            }

        }
    }
}