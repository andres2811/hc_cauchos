using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class Views_administrador_RecuperarContraseña : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }



    protected void BTN_Recuperar_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;

        EncapUsuario user = new DAOAdmin().BuscarCorreo(TB_CorreoRecuperar.Text);
        if (user == null) { 

            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ( 'Correo no encontrado por favor verifique' );</script>");
            return;

        }else {

            user.Clave = "";
            user.Estado_id = 2; //pasa a segundo estado
            user.Token =  encriptar(JsonConvert.SerializeObject(user.Token));
            user.Tiempo_token = DateTime.Now.AddDays(1);


            new Correo().enviarCorreo(user.Correo, user.Token, "");
            new DAOAdmin().ActualizarUsuario(user);
            this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Token enviado por favor verifique el correo');window.location=\" ../login.aspx\"</script>");
            
        }

    }

    private string encriptar(string input)
    {
        SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

        byte[] inputBytes = Encoding.UTF8.GetBytes(input);
        byte[] hashedBytes = provider.ComputeHash(inputBytes);

        StringBuilder output = new StringBuilder();

        for (int i = 0; i < hashedBytes.Length; i++)
            output.Append(hashedBytes[i].ToString("x2").ToLower());

        return output.ToString();
    }

    protected void BTN_inicio_Click(object sender, EventArgs e)
    {
        Response.Redirect("../home.aspx");
    }
}