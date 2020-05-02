using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_usuario_Carrito : System.Web.UI.Page
{

    private String valor;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void ODS_Carrito_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {

    }

    protected void GV_carrito_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewRow row = GV_carrito.Rows[e.NewEditIndex];
        var act = row.FindControl("Cant_Actual") as Label;
        valor = act.Text;
        //Label2.Text = valor;

        //var act1 = row.FindControl("validarCantidad") as RangeValidator;
        //act1.MaximumValue =Label2.Text;
        //act1.MinimumValue = ("1");
    }

    protected void GV_carrito_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    protected void GV_carrito_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {

    }

    protected void BTN_MasPro_Click(object sender, EventArgs e)
    {
        Response.Redirect("catalogoUsuario.aspx");
    }
}