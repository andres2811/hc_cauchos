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
        PanelMensaje.Visible = false;
        PanelMensaje1.Visible = false;
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
            MostrarMensaje($"Correo o Contraseña incorrecta");
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
            MostrarMensaje1($"Por favor verificar sus sessiones abiertas para poder ingresar");
            return;
        }
        


            if (ecUser.Estado_id == 1 || ecUser.Estado_id == 4)
            {

                Session["Aux"] = "";
                Session["Cont"] = 0;
                
            

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
                MostrarMensaje1($"Su cuenta se encuentra en estado de recuperacion");
            }
            if (ecUser.Estado_id == 3)
            {
                MostrarMensaje($"Su cuenta ha sido inhabilitada, comuniquese el con el administrador");
                return;
            }
       
    }

    private void MostrarMensaje(string mensaje)
    {
        LblMensaje.Text = mensaje;
        PanelMensaje.Visible = true;
    }

    private void MostrarMensaje1(string mensaje)
    {
        LblMensaje1.Text = mensaje;
        PanelMensaje1.Visible = true;
    }

    protected void LButton_Recuperar_Click(object sender, EventArgs e)
    {
        Response.Redirect("administrador/RecuperarContraseña.aspx");
    }

    protected void B_cerrar_mensaje_Click(object sender, EventArgs e)
    {
        PanelMensaje.Visible = false;
    }

    protected void B_cerrar_mensaje1_Click(object sender, EventArgs e)
    {
        PanelMensaje1.Visible = false;
    }
}