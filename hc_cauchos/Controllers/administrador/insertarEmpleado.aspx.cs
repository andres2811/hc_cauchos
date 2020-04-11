using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_administrador_insertarEmpleado : System.Web.UI.Page
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

    protected void BTN_registrar_empleado_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        //creo objeto para verificar correo 
        EncapUsuario verificar = new EncapUsuario();
        verificar.Correo = TB_correo.Text;
        //apunto a verificar el correo #si es null no existe#
        verificar = new DAOAdmin().verificarCorreo(verificar);

        if (verificar == null)
        {
            //traigo valores de los texbox
            EncapUsuario Emple = new EncapUsuario();
            Emple.Nombre = TB_nombres.Text;
            Emple.Apellido = TB_apellidos.Text;
            Emple.Correo = TB_correo.Text;
            Emple.Clave = TB_contraseña.Text;
            Emple.Fecha_nacimiento = DateTime.Parse(TB_fecha_nacimiento.Text);
            Emple.Identificacion = TB_identificacion.Text;
            Emple.Rol_id = int.Parse(DDL_tipo_empleado.SelectedValue);
            Emple.Estado_id = 1;

            //apunto a metodo de insert 
            new DAOAdmin().InsertarEmpleado(Emple);
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ( 'El usuario se ha registrado satisfactoriamente' );</script>");
          
            //resect para componentes
            TB_nombres.Text = "";
            TB_apellidos.Text = "";
            TB_correo.Text = "";
            TB_contraseña.Text = "";
            TB_fecha_nacimiento.Text = "";
            TB_identificacion.Text = "";
            TB_confirmar_contra.Text = "";
        }
        else
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ( 'El correo ya se encuentra registrado' );</script>");
            return;
        }
                 
    }
}