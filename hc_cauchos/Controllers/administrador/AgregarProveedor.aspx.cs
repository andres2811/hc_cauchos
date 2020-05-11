﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_administrador_AgregarProveedor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EncapUsuario User = new EncapUsuario();
        User = new DAOAdmin().UsuarioActivo((string)Session["Nombre"]);
        if (User.Sesion == null)
        {
            Response.Redirect("../home.aspx");
        }
    }

    protected void BTN_registrar_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;

        EncapProveedor proveedor = new EncapProveedor();
        proveedor.Nombre_pro = TB_nombre.Text;
        proveedor.Contacto = TB_contacto.Text;
        proveedor.Correo = TB_correo.Text;
        proveedor.Nid = TB_nid.Text;
        proveedor.Session = (string)Session["Nombre"].ToString();
        proveedor.Last_modify = DateTime.Now;
        proveedor.Tiempo_envio = Convert.ToInt32(TB_Fecha.Text);

        Mapeo db = new Mapeo();
        var consulta = (from x in db.proveedor where (x.Nombre_pro == proveedor.Nombre_pro || x.Correo == proveedor.Correo || x.Nid == proveedor.Nid) select x.Id).Count();

        if(consulta == 1)
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('proveedor Existente' );</script>");
            return;
        }

        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('proveedor registrado correctamente' );</script>");
        new DAOAdmin().InsertarProveedor(proveedor);


        TB_nombre.Text = "";
        TB_contacto.Text = "";
        TB_Fecha.Text = "";
        TB_nid.Text = "";
        TB_correo.Text = "";
    }
}