using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class Views_administrador_PedidosProveedor : System.Web.UI.Page
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
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var lb_elemenetos = e.Row.FindControl("LB_elementos") as Label;
            string aux = lb_elemenetos.Text;
            //Deserealizo el Json y lo asigno al grid view
            var elementos = JsonConvert.DeserializeObject<List<producto>>(aux);
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(aux, typeof(DataTable));
            //remover la columna
            dt.Columns.Remove("Id");
            
            var gv = e.Row.FindControl("GV_Elementos") as GridView;
            gv.DataSource = dt;
            //
            
            
            gv.DataBind();
           
        }

           
      
        
    }
}