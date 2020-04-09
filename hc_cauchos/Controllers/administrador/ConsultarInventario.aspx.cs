﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Views_administrador_ConsultarInventario : System.Web.UI.Page
{
    public int a=0;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataSourceID = "ODS_Inventario";


        EncapUsuario User = new EncapUsuario();
        User = new DAOAdmin().UsuarioActivo((string)Session["Nombre"]);
        if (User.Sesion == null)
        {
            Response.Redirect("../home.aspx");
        }

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
                string imgUrl64 = "data:image/jpg;base64," + Convert.ToBase64String(inventario.Imagen);

                image.ImageUrl = imgUrl64;
            }
            



        }
    }







    protected void BT_Buscar_Click(object sender, EventArgs e)
    {


        GridView1.DataSourceID = "ODS_Buscar";
        


    }
}