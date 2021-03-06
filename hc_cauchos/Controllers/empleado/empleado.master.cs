﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_empleado_empleado : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EncapUsuario User = new EncapUsuario();
        User = new DAOAdmin().UsuarioActivo2((string)Session["Correo"]);
        if (User == null || Session["Valido"] == null)
        {
            Response.Redirect("../home.aspx");
        }
        if (User.Rol_id != 2)
        {
            Response.Redirect("../home.aspx");
        }
        L_nombreAdmin.Text = ((EncapUsuario)Session["Valido"]).Nombre;
        L_nombreAdmin0.Text = ((EncapUsuario)Session["Valido"]).Nombre;
        int iduser = ((EncapUsuario)Session["Valido"]).User_id;
        LB_pedidos.Text = new DAOEmpleado().ObtenerCantidadPedidos(iduser).ToString();
    }

    protected void BTN_cerrar_Sesion_Click(object sender, EventArgs e)
    {
        //Elimino ip y mac
        EncapUsuario User = new EncapUsuario();
        User = new DAOAdmin().UsuarioActivo((string)Session["Nombre"]);
        User.Ip_ = null;
        User.Mac_ = null;
        User.Sesion = null;
        Session["Correo"] = null;
        new DAOAdmin().ActualizarUsuario(User);
        Session.Abandon();
        Response.Redirect("../home.aspx");
    }
}
