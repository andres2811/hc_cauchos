﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_registro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BTN_registrar_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        //creo objeto para verificar correo 
        EncapUsuario verificar = new EncapUsuario();
        verificar.Correo = TB_correo.Text;
        //apunto a verificar el correo #si es null no existe#
        verificar = new DAOUser().verificarCorreo(verificar);

        if (verificar == null)
        {
            //traigo valores de los texbox
            EncapUsuario User = new EncapUsuario();
            User.Nombre = TB_nombres.Text;
            User.Apellido = TB_apellidos.Text;
            User.Correo = TB_correo.Text;
            User.Clave = TB_contraseña.Text;
            User.Fecha_nacimiento = DateTime.Parse(TB_fecha_nacimiento.Text);
            User.Identificacion = TB_identificacion.Text;
            User.Rol_id = 4;
            User.Estado_id = 1;
            //apunto a metodo de insert 
            new DAOUser().InsertarUsuario(User);
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ( 'El usuario se ha registrado satisfactoriamente' );</script>");
            return;
        }
        else
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ( 'El correo ya se encuentra registrado' );</script>");
            return;
        }

    }
}