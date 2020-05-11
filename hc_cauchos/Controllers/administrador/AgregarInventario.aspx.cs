using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_administrador_AgregarInventario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EncapUsuario User = new EncapUsuario();
        User = new DAOAdmin().UsuarioActivo((string)Session["Nombre"]);
        if (User.Sesion == null){
            Response.Redirect("../home.aspx");
        }

    }




    protected void BTN_subir_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;

        int auxprecio = int.Parse(TB_Precio.Text) ;
        int aux_minimo = int.Parse(TB_Minima.Text); 
        
        if (auxprecio <=0 || aux_minimo<=0 )
        {

            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('NO SE PERMITE DATOS NEGATIVOS' );</script>");
            return;//Devolverse
        }


        //Propiedades del archivo a subirs

      
        string nombreArchivo = System.IO.Path.GetFileName(FU_Archivo.PostedFile.FileName);
        string extension = System.IO.Path.GetExtension(FU_Archivo.PostedFile.FileName);
        
        string saveLocationAdmin = HttpContext.Current.Server.MapPath("~\\Inventario\\") + nombreArchivo;
        string Ruta = "~\\Inventario\\" +nombreArchivo;

        //validar Aechivo de tipo imagen
        if (!(extension.Equals(".jpg") || extension.Equals(".jpeg") || extension.Equals(".png") || extension.Equals(".gif")))
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('tipo de archivo no valido ' );</script>");
            return;//Devolverse
        }

        
        //verificar existencia de un arhivo con el mismo nombre
        if (System.IO.File.Exists(saveLocationAdmin))
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('Imagen Existente' );</script>");
            return;
        }
        //Validaciones 
        var db = new Mapeo();

        var consulta1 = (from x in db.inventario where x.Referencia.Equals(TB_referencia.Text) select x.Referencia ).Count();
        
        //si referencia ya existe

        if (consulta1 == 1)
        {
          
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('La Referencia Ya Existe' );</script>");
                return;
            

        }

        else { 
            try
            {
                


                

                //Guardar Archivo local
                FU_Archivo.PostedFile.SaveAs(saveLocationAdmin);


                EncapInventario invent = new EncapInventario();

              
                invent.Imagen = Ruta;
                invent.Titulo = TB_Titulo.Text;
                invent.Referencia = TB_referencia.Text;
                invent.Precio= int.Parse(TB_Precio.Text);
                
                invent.Ca_minima = int.Parse(TB_Minima.Text);
                invent.Id_marca = int.Parse(DDL_Marca.Text);
                invent.Id_categoria = int.Parse(DDL_Categoria.Text);
                invent.Id_estado = 1;
                invent.Ca_actual = 0;
         

                new DAOAdmin().InsertarItem(invent);
                
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('Item registrado correctamente' );</script>");
            }
            catch (Exception exc)
            {
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('Error' );</script>");
                return;
            }
        }

        TB_Titulo.Text = "";
        TB_referencia.Text = "";
      
        TB_Minima.Text = "";
        TB_Precio.Text = "";
        



    }





   
}