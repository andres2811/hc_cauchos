using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_usuario_Carrito : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        EncapCarrito verificarPedido = new EncapCarrito();
        verificarPedido.User_id = ((EncapUsuario)Session["Valido"]).User_id;
        var verificar1 = new DAOUser().verificarUsuarioTienePedido(verificarPedido);
        if (verificar1 != null) {
            BTN_Facturar.Visible = false;
        }
        else
        {
            BTN_Facturar.Visible = true;
        }
    }
    protected void ODS_Carrito_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {

    }

    protected void GV_carrito_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void GV_carrito_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    protected void GV_carrito_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {

        //ACTUALIZA VALOR DEL PEDIDO SI MODIFICAN CANTIDADES
        EncapPedido pedido = new EncapPedido();
        pedido.User_id = ((EncapUsuario)Session["Valido"]).User_id;
        List<EncapCarrito> listCarrito2 = new DAOUser().ObtenerCarritoxUsuario(pedido.User_id);
        int first = listCarrito2[0].Id_pedido;
        pedido.Total = listCarrito2.Sum(x => x.Precio * x.Cantidad).Value;
        pedido.Id = first;
        new DAOUser().ActualizarValorpedido(pedido);

    }

    protected void BTN_MasPro_Click(object sender, EventArgs e)
    {
        Response.Redirect("catalogoUsuario.aspx");
    }

    protected void BTN_Facturar_Click(object sender, ImageClickEventArgs e)
    {

        ClientScriptManager cm = this.ClientScript;
        //creo objeto para cambiar el estado luego de facturar
        EncapCarrito carrito = new EncapCarrito();
        carrito.User_id = ((EncapUsuario)Session["Valido"]).User_id;
        carrito.Estadocar = 2;
        new DAOUser().ActualizarCarritoEstado(carrito);


        //agrego a la tabla pedido
        EncapPedido pedido = new EncapPedido();
        pedido.Fecha_pedido = DateTime.Now;
        pedido.User_id= ((EncapUsuario)Session["Valido"]).User_id;
        pedido.Atendido_id = 5;
        pedido.Estado_pedido = 1;
        List<EncapCarrito> listCarrito = new DAOUser().ObtenerCarritoxUsuario(pedido.User_id);
        pedido.Total= listCarrito.Sum(x => x.Precio * x.Cantidad).Value;
        int pedido_Id = new DAOUser().InsertarPedido(pedido);


        //agrego a carrito el pedido
        EncapCarrito id_pedido = new EncapCarrito();
        id_pedido.User_id= ((EncapUsuario)Session["Valido"]).User_id;
        id_pedido.Id_pedido = pedido_Id;
        new DAOUser().ActualizarIdpedidoCarrito(id_pedido);

        ScriptManager.RegisterStartupScript(this, this.GetType(), "myAlert", "alert('Se genero la factua No.00" + pedido_Id.ToString() + "');", true);
        Response.Redirect("Carrito.aspx");
    }

}
 