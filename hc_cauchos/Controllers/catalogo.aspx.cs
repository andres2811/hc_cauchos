using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_catalogo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       

    }


    protected void Btn_Buscar_Click(object sender, EventArgs e)
    {
        //filtros Marca y categoria
        if (DD_Categoria.SelectedIndex != 0)
        {
            Repeater1.DataSourceID = "ODS_catalogoCategoria";

        }
        if (DD_Marca.SelectedIndex != 0)
        {
            Repeater1.DataSourceID = "ODS_catalogoMarca";
        }
        if (DD_Marca.SelectedIndex != 0 && DD_Categoria.SelectedIndex != 0)
        {
            Repeater1.DataSourceID = "ODS_catalogoCombinado";
        }
        //validaciones Precio marca y categoria
        if (DDL_Precio.SelectedIndex != 0)
        {
            Repeater1.DataSourceID = "ODS_catalogoPrecio";
        }
        if (DD_Categoria.SelectedIndex != 0 && DDL_Precio.SelectedIndex != 0)
        {
            Repeater1.DataSourceID = "ODS_catalogoPrecioCategoria";
        }
        if (DD_Marca.SelectedIndex != 0 && DDL_Precio.SelectedIndex != 0)
        {
            Repeater1.DataSourceID = "ODS_catalogoPrecioMarca";
        }
        if (DD_Categoria.SelectedIndex != 0 && DD_Marca.SelectedIndex != 0 && DDL_Precio.SelectedIndex != 0)
        {
            Repeater1.DataSourceID = "ODS_catalogoPrecioCombinado";
        }
    }

    protected void Btn_Todos_Click(object sender, EventArgs e)
    {
        Repeater1.DataSourceID = "ODS_catalogo";
        DDL_Precio.SelectedIndex = 0;
        DD_Marca.SelectedIndex = 0;
        DD_Categoria.SelectedIndex = 0;
    }
}