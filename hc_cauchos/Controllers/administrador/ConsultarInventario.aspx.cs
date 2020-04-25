using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Views_administrador_ConsultarInventario : System.Web.UI.Page
{

    
  

    protected void Page_Load(object sender, EventArgs e)
    {
        EncapUsuario User = new EncapUsuario();
        User = new DAOAdmin().UsuarioActivo((string)Session["Nombre"]);
        if (User.Sesion == null)
        {
            Response.Redirect("../home.aspx");
        }


        DDL_Categoria2.Enabled = false;
        DDL_Marca2.Enabled = false;
        BT_Inabilitar.Visible = false;
        
       
       
    }




    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {


        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            string referencia = e.Row.Cells[2].Text.ToString();//obtener valor de la celda
            //a = Int32.Parse(id);

            EncapInventario inventario = new EncapInventario();

            inventario = new DAOAdmin().BuscarInventario(inventario, referencia);

            if (inventario != null)
            {
                var image = e.Row.FindControl("IdInventario") as Image;

                String imgUrl64 = (inventario.Imagen);
                image.ImageUrl = imgUrl64;
            }

            


        }
    }

    protected void BT_Buscar_Click(object sender, EventArgs e)
    {
       
        if (TB_Buscar.Text != "")
        {
            GV_inventario.DataSourceID = "ODS_Buscar";
            InabilitarDDLS();
        }else
        if (DDL_Categoria2.SelectedIndex != 0 && DDL_Marca2.SelectedIndex != 0)
        {
            GV_inventario.DataSourceID = "ODS_BuscarMarcaCategoria";
            HabilitarDDLS();
        }else
        if (DDL_Marca2.SelectedIndex != 0)
        {

            GV_inventario.DataSourceID = "ODS_BuscarMarca";
            HabilitarDDLS();
        }
        else
        if (DDL_Categoria2.SelectedIndex != 0)
        {
            GV_inventario.DataSourceID = "ODS_BuscarCategoria";
            HabilitarDDLS();

        }

        
       
      
        

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        GV_inventario.DataSourceID = "ODS_Inventario";

        if (TB_Buscar.Text != "")
        {
           
            InabilitarDDLS();
        }
        else
        if (DDL_Categoria2.SelectedIndex != 0 || DDL_Marca2.SelectedIndex != 0)
        {
            
            HabilitarDDLS();
        }
        







    }


    protected void BT_Filtrar_Click(object sender, EventArgs e)
    {
        HabilitarDDLS();
        
    }

    protected void BT_Inabilitar_Click(object sender, EventArgs e)
    {
        InabilitarDDLS();
        BT_Inabilitar.Visible = false;
      

    }
    private void HabilitarDDLS()
    {
        TB_Buscar.Text = "";
        BT_Filtrar.Visible = false;
        BT_Inabilitar.Visible = true;
        TB_Buscar.Enabled = false;
        DDL_Categoria2.Enabled = true;
        DDL_Marca2.Enabled = true;
    }
    private void InabilitarDDLS()
    {
        DDL_Categoria2.SelectedIndex = 0;
        DDL_Marca2.SelectedIndex= 0;
        BT_Filtrar.Visible = true;
        BT_Inabilitar.Visible = false;
        TB_Buscar.Enabled = true;
        DDL_Categoria2.Enabled = false;
        DDL_Marca2.Enabled = false;
    }
}