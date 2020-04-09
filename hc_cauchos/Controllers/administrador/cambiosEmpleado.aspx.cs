﻿
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

    }



    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.FindControl("DDL_roles") != null)
        {
            EncapUsuario ddlusu = (EncapUsuario)e.Row.DataItem;
            ((DropDownList)e.Row.FindControl("DDL_roles")).SelectedValue = ddlusu.Rol_id.ToString();
        }
    }

    protected void GV_empleados_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = GV_empleados.Rows[e.RowIndex];
        e.NewValues.Insert(2, "Rol_id", int.Parse(((DropDownList)row.FindControl("DDL_roles")).SelectedValue));


    }
}