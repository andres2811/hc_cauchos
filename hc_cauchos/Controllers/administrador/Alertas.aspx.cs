﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_administrador_Alertas : System.Web.UI.Page
{
    protected int cont = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        EncapUsuario User = new EncapUsuario();
        User = new DAOAdmin().UsuarioActivo2((string)Session["Correo"]);
        if (User == null)
        {
            Response.Redirect("../home.aspx");
        }
        if (User.Rol_id != 1)
        {
            Response.Redirect("../home.aspx");
        }

    }

    protected void RepeaterAlerta_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //var id_refe = e.Item.FindControl("LB_id") as Label;
        //var BTN = e.Item.FindControl("BT_Alerta") as Button;
        //var db = new Mapeo();
        //int aux = Convert.ToInt32(id_refe.Text);
        /*var consulta1 = (from x in db.pedido_proveedor where x.Id_producto.Equals(aux) select x.Id_producto).Count();

        //si referencia ya existe

        if (consulta1 == 1)
        {
            BTN.Enabled = false;
        }
        */
    }

    protected void RepeaterAlerta_ItemCommand(object source, RepeaterCommandEventArgs e)
    {


        var refere = e.Item.FindControl("LB_Referencia") as Label;
        
       

        Response.Redirect("CatalogoProveedor.aspx");

    }
}