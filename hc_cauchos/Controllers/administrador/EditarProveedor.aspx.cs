using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_administrador_EditarProveedor : System.Web.UI.Page
{
    private string nombre;
    protected void Page_Load(object sender, EventArgs e)
    {

    }





    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        GridViewRow row = Gv_proveedor.Rows[e.RowIndex];
        var tb_nombre = row.FindControl("TB_Nombre") as TextBox;
        //Consulto a la tabla si el nombre ya existe

        Mapeo db = new Mapeo();
        var consulta = (from x in db.proveedor.Where(x => x.Nombre_pro == tb_nombre.Text) select x ).Count();

        if (consulta ==1)
        {
            //si el valorexistente es el mismo
            if (LB_aux.Text == tb_nombre.Text)
            {
                //agrego valor que habia antes 
                e.NewValues["Nombre_pro"] = LB_aux.Text;


            }
            else
            {

                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('Nombre de  proveedor existente' );</script>");
                e.Cancel = true;
            }
        }
    }

    protected void Gv_proveedor_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewRow row = Gv_proveedor.Rows[e.NewEditIndex];
        var lb_nombre = row.FindControl("LB_Nombre") as Label;

        LB_aux.Text = lb_nombre.Text;
    }
}