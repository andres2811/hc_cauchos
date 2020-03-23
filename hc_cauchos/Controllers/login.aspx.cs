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
            ecUser.Sesion = (string)Session["Nombre"].ToString();
            new DAOAdmin().ActualizarUsuario(ecUser);
            
            if (ecUser.Rol_id == 1)
             {
                 Response.Redirect("administrador/index_admin.aspx");
             }
         

    }

    protected void LButton_Recuperar_Click(object sender, EventArgs e)
    {
        Response.Redirect("administrador/RecuperarContraseña.aspx");
    }
}