using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_login_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BTN_ingresar_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        EncapUsuario ecUser = new EncapUsuario();
        ecUser.Correo = TB_correo.Text;
        ecUser.Clave = TB_contraseña.Text;

        //
        ecUser = new DAOAdmin().loginEntity(ecUser);
        if (ecUser == null)
         {
             cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('Usuario o Contraseña incorrecta' );</script>");
            return;
        }
        if (ecUser.Estado_id != 1)
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ( 'Su cuenta esta en espera de recuperar contraseña' );</script>");
            return;
        }
        
        
            //Dependiendo del rol se envia al Formulario correcto
            //1 -- Administrador

            Session["Nombre"] = ecUser.Nombre +" " +ecUser.Apellido;
            //en esta session mando correctamente valores del encapsulado
            Session["Valido"] = ecUser;
            ecUser.Sesion = (string)Session["Nombre"].ToString();
            new DAOAdmin().ActualizarUsuario(ecUser);


        switch (ecUser.Rol_id)
        {
            case 1:
                Response.Redirect("administrador/index_admin.aspx");
                break;
            case 2:
                Response.Redirect("empleado/index_empleado.aspx");
                break;
            case 3:
                Response.Redirect("domiciliario/index_domiciliario.aspx");
                break;
            case 4:
                Response.Redirect("usuario/index_usuario.aspx");
                break;
        }
     
    }

    protected void LButton_Recuperar_Click(object sender, EventArgs e)
    {
        Response.Redirect("administrador/RecuperarContraseña.aspx");
    }
}