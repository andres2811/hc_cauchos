using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_empleado_pedidos_atender : System.Web.UI.Page
{
  
    protected void Page_Load(object sender, EventArgs e)
    {
        int idemple = ((EncapUsuario)Session["Valido"]).User_id;
        Session["empleid"] = idemple;
        R_pro.Visible = false;
        BTN_confirmar.Visible = false;
        TB_novedad.Visible = false;

    }

    protected void R_pedido_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        int id_pedido = int.Parse(((Label)e.Item.FindControl("Id")).Text);
        Session["idpedido"] = id_pedido;
        R_pro.Visible = true;
        R_pro.DataSourceID = "ODS_Productos";
        EncapPedido estado2 = new EncapPedido();
        estado2.Id = id_pedido;
        estado2.Estado_pedido = 2;
        new DAOEmpleado().ActualizarEstadoPedido2(estado2);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "myAlert", "alert('Se ha comenzado el alistamiento del pedido No.00" + id_pedido.ToString() + "');", true);
        BTN_confirmar.Visible = true;
        TB_novedad.Visible = true;


    }

    protected void BTN_confirmar_Click(object sender, EventArgs e)
    {
        EncapPedido novedad = new EncapPedido();
        novedad.Id = int.Parse( Session["idpedido"].ToString());
        novedad.Novedad = TB_novedad.Text;
        novedad.Estado_pedido = 3;
        new DAOEmpleado().ActualizarNovedadPedido(novedad);
        new DAOEmpleado().ActualizarEstadoPedido3(novedad);

        EncapUsuario estado = new EncapUsuario();
        estado.User_id= ((EncapUsuario)Session["Valido"]).User_id;
        estado.Estado_id = 1;
        new DAOEmpleado().ActualizarEstadoEmpleado(estado);


        Response.Redirect("pedidos_atender.aspx");

    }

    protected void DDL_Departamento_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDL_Municipio.Visible = true;
    }
}