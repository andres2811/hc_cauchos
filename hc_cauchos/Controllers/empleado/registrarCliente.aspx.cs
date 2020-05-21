﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_empleado_registrarCliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EncapUsuario User = new EncapUsuario();
        User = new DAOAdmin().UsuarioActivo2((string)Session["Correo"]);
        if (User == null)
        {
            Response.Redirect("../home.aspx");
        }
        if (User.Rol_id != 2)
        {
            Response.Redirect("../home.aspx");
        }

    }

    protected void BTN_registrar_cliente_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        //creo objeto para verificar correo 
        EncapUsuario verificar = new EncapUsuario();
        verificar.Correo = TB_correo.Text;
        //apunto a verificar el correo #si es null no existe#
        verificar = new DAOAdmin().verificarCorreo(verificar);
        EncapUsuario verificarIdentificacion = new EncapUsuario();
        verificarIdentificacion.Identificacion = TB_identificacion.Text;
        verificarIdentificacion = new DAOUser().verificarIdentificacion(verificarIdentificacion);

        if (verificar == null && verificarIdentificacion == null)
        {
            //traigo valores de los texbox
            EncapUsuario clien= new EncapUsuario();
            clien.Nombre = TB_nombres.Text;
            clien.Apellido = TB_apellidos.Text;
            clien.Correo = TB_correo.Text;
            clien.Fecha_nacimiento = DateTime.Parse(TB_fecha_nacimiento.Text);
            clien.Identificacion = TB_identificacion.Text;
            clien.Rol_id = 4;
            clien.Estado_id = 2;

            //apunto a metodo de insert 
            new DAOEmpleado().InsertarCliente(clien);
            new DAOAdmin().InsertarEmpleado(clien);
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ( 'El cliente se ha registrado satisfactoriamente' );</script>");

            //resect para componentes
            TB_nombres.Text = "";
            TB_apellidos.Text = "";
            TB_correo.Text = "";
            TB_fecha_nacimiento.Text = "";
            TB_identificacion.Text = "";
        }
        else
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ( 'El correo o contraseña ya se encuentran registrados' );</script>");
            return;
        }
    }

    protected void BTN_Regresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("ventas.aspx");
    }
}