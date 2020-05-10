using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_empleado_configurarEmple : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EncapUsuario User = new EncapUsuario();
        User = new DAOAdmin().UsuarioActivo((string)Session["Nombre"]);
        if (User.Sesion == null)
        {
            Response.Redirect("../home.aspx");
        }
        //inicio componentes de edit componentes como invisibles
        TB_editCorreo.Visible = false;
        BTN_editarCorreo.Visible = false;
        TB_editarPass.Visible = false;
        BTN_editarPass.Visible = false;
        BTN_cancelar.Visible = false;
        BTN_cancelar2.Visible = false;


        //creo objeto de encap usuario 
        EncapUsuario usuario = new EncapUsuario();
        //envio sesion de usuario activo y valido existencia
        usuario = new DAOAdmin().UsuarioActivo((string)Session["Nombre"]);
        LB_nombre.Text = usuario.Nombre;
        LB_apellido.Text = usuario.Apellido;
        LB_correo.Text = usuario.Correo;
        LB_contraseña.Text = usuario.Clave;
    }


    protected void BTN_editarCorreo_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        //creo objeto para verificar correo 
        EncapUsuario verificar = new EncapUsuario();
        verificar.Correo = TB_editCorreo.Text;
        //apunto a verificar el correo #si es null no existe#
        verificar = new DAOUser().verificarCorreo(verificar);

        // valido si el correo existe
        if (verificar == null)
        {
            //actualizo datos de usuario CORREO
            EncapUsuario nuevo = new EncapUsuario();
            nuevo = new DAOAdmin().UsuarioActivo((string)Session["Nombre"]);
            nuevo.Correo = TB_editCorreo.Text;
            new DAOAdmin().ActualizarUsuario(nuevo);
            TB_editCorreo.Text = "";

        }
        else
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ( 'El correo ya se encuentra registrado' );</script>");
            TB_editCorreo.Text = "";
            return;
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //desoculto elementos para poder editar
        TB_editCorreo.Visible = true;
        BTN_editarCorreo.Visible = true;
        BTN_cancelar.Visible = true;
    }

    protected void BTN_cancelar_Click(object sender, EventArgs e)
    {
        //oculto elementos por cancelacion
        TB_editCorreo.Visible = false;
        BTN_editarCorreo.Visible = false;
    }

    protected void BTN_editarPass_Click(object sender, EventArgs e)
    {
        //actualizo datos de usuario CORREO
        EncapUsuario nuevo = new EncapUsuario();
        nuevo = new DAOAdmin().UsuarioActivo((string)Session["Nombre"]);
        nuevo.Clave = TB_editarPass.Text;
        new DAOAdmin().ActualizarUsuario(nuevo);
        TB_editarPass.Text = "";
    }

    protected void BTN_cancelar2_Click(object sender, EventArgs e)
    {
        TB_editarPass.Visible = false;
        BTN_editarPass.Visible = false;
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        TB_editarPass.Visible = true;
        BTN_editarPass.Visible = true;
        BTN_cancelar2.Visible = true;
    }
}