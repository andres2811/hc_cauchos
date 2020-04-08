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
        //creacion objeto tipo session IVAN CORREGIR
        ClientScriptManager cm = this.ClientScript;
        EncapUsuario ecUser = new EncapUsuario();
        ecUser.Correo = TB_correo.Text;
        ecUser.Clave = TB_contraseña.Text;

        //En estas condiciones se valida el estado del usuario
        ecUser = new DAOAdmin().loginEntity(ecUser);
        if (ecUser == null)
         {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('Usuario o Contraseña incorrecta' );</script>");
            return;
        }
        //Validacion de la iP y la mac
        string ip = new MAC_IP().ip();
        string mac = new MAC_IP().mac();

        if(ecUser.Ip_ == null && ecUser.Mac_ == null)
        {
            ecUser.Ip_ = ip;
            ecUser.Mac_ = mac;
            new DAOAdmin().ActualizarUsuario(ecUser);
        }
        if (mac != ecUser.Mac_ && ip != ecUser.Ip_)
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('Por favor verifica tus sessiones abierta para poder ingresar' );</script>");
            return;
        }
        


            if (ecUser.Estado_id == 1)
            {

                Session["Nombre"] = ecUser.Nombre + " " + ecUser.Apellido;
                //en esta session mando correctamente valores del encapsulado
                Session["Valido"] = ecUser;
                ecUser.Sesion = (string)Session["Nombre"].ToString();

                new DAOAdmin().ActualizarUsuario(ecUser);



                //Dependiendo del rol se envia al Formulario correcto
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
            if (ecUser.Estado_id == 2)
            {
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ( 'Su cuenta esta en espera de recuperar contraseña' );</script>");
                return;
            }
            if (ecUser.Estado_id == 3)
            {
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ( 'Su cuenta ha sido inhabilitada, comuniquese con el administrador' );</script>");
                return;
            }
       
    }

    protected void LButton_Recuperar_Click(object sender, EventArgs e)
    {
        Response.Redirect("administrador/RecuperarContraseña.aspx");
    }
}