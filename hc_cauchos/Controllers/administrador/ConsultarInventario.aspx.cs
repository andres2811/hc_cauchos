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
        EncapUsuario User = new EncapUsuario();
        User = new DAOAdmin().UsuarioActivo((string)Session["Nombre"]);
        if (User.Sesion == null)
        {
            Response.Redirect("../home.aspx");
        }

    }




    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        EncapInventario ddlinventario = (EncapInventario)e.Row.DataItem;
        if (e.Row.FindControl("DDL_marca") != null)
        {
            ((DropDownList)e.Row.FindControl("DDL_marca")).SelectedValue = ddlinventario.Id_marca.ToString();
        }

        if (e.Row.FindControl("DDL_categoria") != null)
        {
            ((DropDownList)e.Row.FindControl("DDL_categoria")).SelectedValue = ddlinventario.Id_categoria.ToString();
        }

        if (e.Row.FindControl("DDL_estado") != null)
        {
            ((DropDownList)e.Row.FindControl("DDL_estado")).SelectedValue = ddlinventario.Id_estado.ToString();
        }



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
        GV_inventario.DataSourceID = "ODS_Buscar";

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        GV_inventario.DataSourceID = "ODS_Inventario";
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = GV_inventario.Rows[e.RowIndex];
        e.NewValues.Insert(2, "Id_marca", int.Parse(((DropDownList)row.FindControl("DDL_marca")).SelectedValue));
        e.NewValues.Insert(4, "Id_categoria", int.Parse(((DropDownList)row.FindControl("DDL_categoria")).SelectedValue));
        e.NewValues.Insert(6, "Id_estado", int.Parse(((DropDownList)row.FindControl("DDL_estado")).SelectedValue));
    }
}