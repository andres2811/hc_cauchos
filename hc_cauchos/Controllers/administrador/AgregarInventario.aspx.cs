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
        int aux_actual= int.Parse(TB_Cantidad.Text);
        if (auxprecio <=0 || aux_minimo<=0 || aux_actual <=0)
        {

            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('NO SE PERMITE DATOS NEGATIVOS' );</script>");
            return;//Devolverse
        }


        //Propiedades del archivo a subirs

      
        string nombreArchivo = System.IO.Path.GetFileName(FU_Archivo.PostedFile.FileName);
        string extension = System.IO.Path.GetExtension(FU_Archivo.PostedFile.FileName);

        string saveLocationAdmin = Server.MapPath("~\\Archivos_Inventario") + "\\" + nombreArchivo;

        //validar Aechivo de tipo imagen
        if (!(extension.Equals(".jpg") || extension.Equals(".jpeg") || extension.Equals(".png") || extension.Equals(".gif")))
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('tipo de archivo no valido ' );</script>");
            return;//Devolverse
        }
       
        //Validaciones 
        var db = new Mapeo();

        var consulta1 = (from x in db.inventario where x.Referencia.Equals(TB_referencia.Text) select x.Referencia ).Count();
        
        //si referencia ya existe

        if (consulta1 == 1)
        {
            
            
            EncapInventario inven = new EncapInventario();
           
            byte[] ar = null;
            using (BinaryReader reader = new
                 BinaryReader(FU_Archivo.PostedFile.InputStream))
            {
                ar = reader.ReadBytes(FU_Archivo.PostedFile.ContentLength);
            }

           
            inven.Imagen = ar;
            inven.Titulo = TB_Titulo.Text;
            inven.Referencia = TB_referencia.Text;
            inven.Precio = int.Parse(TB_Precio.Text);
            inven.Ca_actual = int.Parse(TB_Cantidad.Text);
            inven.Ca_minima = int.Parse(TB_Minima.Text);
            inven.Id_marca = int.Parse(DDL_Marca.Text);
            inven.Id_categoria = int.Parse(DDL_Categoria.Text);
            inven.Id_estado = 1;
            new DAOAdmin().ActualizarReferencia(inven);
            db.SaveChanges();

            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('LA REFERENCIA es existente item actualizado' );</script>");
            

        }

        else { 
            try
            {
                //String imgUrl64 = "data:image/jpg;base64," + Convert.ToBase64String(ar);


                //Image1.ImageUrl = imgUrl64;

                //Guardar Archivo local
                //FU_Archivo.PostedFile.SaveAs(saveLocationAdmin);


                EncapInventario invent = new EncapInventario();

                //convertir a binario el archivo


                byte[] ar = null;
                using (BinaryReader reader = new
                     BinaryReader(FU_Archivo.PostedFile.InputStream))
                {
                    ar = reader.ReadBytes(FU_Archivo.PostedFile.ContentLength);
                }

                Session["rutaByte"] = ar;
                invent.Imagen = ar;
                invent.Titulo = TB_Titulo.Text;
                invent.Referencia = TB_referencia.Text;
                invent.Precio= int.Parse(TB_Precio.Text);
                invent.Ca_actual = int.Parse(TB_Cantidad.Text);
                invent.Ca_minima = int.Parse(TB_Minima.Text);
                invent.Id_marca = int.Parse(DDL_Marca.Text);
                invent.Id_categoria = int.Parse(DDL_Categoria.Text);
                invent.Id_estado = 1;
         

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
        TB_Cantidad.Text = "";
        TB_Minima.Text = "";
        TB_Precio.Text = "";
        



    }





   
}