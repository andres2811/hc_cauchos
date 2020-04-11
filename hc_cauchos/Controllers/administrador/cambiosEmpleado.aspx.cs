
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_administrador_cambiosEmpleado : System.Web.UI.Page
{
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
        if (e.Row.FindControl("DDL_roles") != null)
        {
            EncapUsuario ddlusu = (EncapUsuario)e.Row.DataItem;
            ((DropDownList)e.Row.FindControl("DDL_roles")).SelectedValue = ddlusu.Rol_id.ToString();
        }


        if (e.Row.FindControl("DDL_estados") != null)
        {
            EncapUsuario ddlusu1 = (EncapUsuario)e.Row.DataItem;
            ((DropDownList)e.Row.FindControl("DDL_estados")).SelectedValue = ddlusu1.Estado_id.ToString();
        }
    }

    protected void GV_empleados_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = GV_empleados.Rows[e.RowIndex];
        e.NewValues.Insert(2, "Rol_id", int.Parse(((DropDownList)row.FindControl("DDL_roles")).SelectedValue));

        // PENDIENTE PREGUNTAR 
        e.NewValues.Insert(2, "Estado_id", int.Parse(((DropDownList)row.FindControl("DDL_estados")).SelectedValue));

    }

    protected void BTN_buscarNombre_Click(object sender, EventArgs e)
    {
        GV_empleados.DataSourceID = "ODS_mostrarEmpleNombre";
    }

    protected void BTN_buscarTodos_Click(object sender, EventArgs e)
    {
        GV_empleados.DataSourceID = "ODS_mostrarEmpleados";
    }
}