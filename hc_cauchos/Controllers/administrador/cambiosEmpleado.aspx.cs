
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
        User = new DAOAdmin().UsuarioActivo2((string)Session["Correo"]);
        if (User == null)
        {
            Response.Redirect("../home.aspx");
        }
        if (User.Rol_id != 1)
        {
            Response.Redirect("../home.aspx");
        }

    }



    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        EncapUsuario ddlusu = (EncapUsuario)e.Row.DataItem;
        if (e.Row.FindControl("DDL_roles") != null)
        {         
            ((DropDownList)e.Row.FindControl("DDL_roles")).SelectedValue = ddlusu.Rol_id.ToString();
        }


        if (e.Row.FindControl("DDL_estados") != null)
        {
            ((DropDownList)e.Row.FindControl("DDL_estados")).SelectedValue = ddlusu.Estado_id.ToString();
        }

       
    }

    protected void GV_empleados_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        GridViewRow row = GV_empleados.Rows[e.RowIndex];
        var fecha = row.FindControl("TB_Nacimiento") as TextBox;
        
        EncapUsuario validarIdentificacion = new EncapUsuario();

     
        
      
         

        //e.NewValues.Insert(2, "Rol_id", int.Parse(((DropDownList)row.FindControl("DDL_roles")).SelectedValue)); 
        //e.NewValues.Insert(4, "Estado_id", int.Parse(((DropDownList)row.FindControl("DDL_estados")).SelectedValue));

       



    }

    protected void BTN_buscarNombre_Click(object sender, EventArgs e)
    {
        GV_empleados.DataSourceID = "ODS_mostrarEmpleNombre";
    }

    protected void BTN_buscarTodos_Click(object sender, EventArgs e)
    {
        GV_empleados.DataSourceID = "ODS_mostrarEmpleados";
    }


    protected void GV_empleados_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        
    }

    protected void GV_empleados_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewRow row = GV_empleados.Rows[e.NewEditIndex];
        var lb_fecha = row.FindControl("Label3") as Label;
        var tb_fecha = row.FindControl("TB_Nacimiento") as TextBox;
      
        
    }
}