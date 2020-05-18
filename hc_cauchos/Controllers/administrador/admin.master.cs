﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_administrador_admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //VALIDACION PARA SABER SI LA SESSION EXISTE PONER EN TODOS LOA PAGE LOAD 
        if (Session["Valido"] != null && ((EncapUsuario)Session["Valido"]).Rol_id == 1)
        {

        }
        else
        {
            Response.Redirect("../login.aspx");
        }
        //obtengo nombre de la sesion y pongo en html
        L_nombreAdmin.Text =((EncapUsuario)Session["Valido"]).Nombre;
        L_nombreAdmin0.Text= ((EncapUsuario)Session["Valido"]).Nombre;

        Mapeo db = new Mapeo();

        var alertas = (from x in db.inventario where x.Ca_actual <= x.Ca_minima select x.Ca_actual).Count();
        LB_Alertas.Text = alertas.ToString();

    }

    protected void BTN_cerrar_Sesion_Click(object sender, EventArgs e)
    {
        //Elimino ip y mac
        EncapUsuario User = new EncapUsuario();
        User = new DAOAdmin().UsuarioActivo((string)Session["Nombre"]);
        User.Ip_ = null;
        User.Mac_ = null;
        User.Sesion = null;
        new DAOAdmin().ActualizarUsuario(User);
        Response.Redirect("../home.aspx");
        Session["Valido"] = -1;
        Session.Abandon();
        Session.RemoveAll();
        

    }
}
