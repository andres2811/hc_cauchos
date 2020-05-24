using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_empleado_venta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EncapUsuario User = new EncapUsuario();
        User = new DAOAdmin().UsuarioActivo2((string)Session["Correo"]);
        if (User == null)
        {
            Response.Redirect("../home.aspx");
        }
        if (User.Rol_id != 2)
        {
            Response.Redirect("../home.aspx");
        }
    }

    protected void BTN_BuscarClien_Click(object sender, EventArgs e)
    {
        GV_Clientes.DataSourceID = "ODS_ClientesCedu";
    }

    protected void BTN_buscarTodos_Click(object sender, EventArgs e)
    {
        GV_Clientes.DataSourceID = "ODS_Clientes";
    }

    protected void BTN_RegistrarCliente_Click(object sender, EventArgs e)
    {
        Response.Redirect("registrarCliente.aspx");
    }

    protected void BTN_Facturar_Click(object sender, ImageClickEventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;

        if (TB_Iduser.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myAlert", "alert('Debe ingresar el ID asociado al cliente');", true);
        }
        else
        {
            //verifico si el usuario tiene productos en carrito antes de facturar
            List<EncapCarrito> listCarritoV = new DAOUser().ObtenerCarritoxUsuario(((EncapUsuario)Session["Valido"]).User_id);
            if (listCarritoV.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myAlert", "alert('Debe ingresar productos antes de realizar una venta');", true);
            }
            else
            {
                //creo objeto para cambiar el estado luego de facturar
                EncapCarrito carrito = new EncapCarrito();
                carrito.User_id = ((EncapUsuario)Session["Valido"]).User_id;
                carrito.Estadocar = 2;
                new DAOUser().ActualizarCarritoEstado(carrito);

                //agrego a la tabla pedido
                EncapPedido pedido = new EncapPedido();
                pedido.Fecha_pedido = DateTime.Now;
                pedido.User_id = int.Parse(TB_Iduser.Text);
                pedido.Atendido_id = ((EncapUsuario)Session["Valido"]).User_id;
                pedido.Estado_pedido = 6;
                List<EncapCarrito> listCarrito = new DAOUser().ObtenerCarritoxUsuario(pedido.Atendido_id);
                pedido.Total = listCarrito.Sum(x => x.Precio * x.Cantidad).Value;
                int pedido_Id = new DAOUser().InsertarPedido(pedido);

                Session["pedido_Id"] = pedido_Id;

                //agrego a carrito el pedido
                EncapCarrito id_pedido = new EncapCarrito();
                id_pedido.User_id = int.Parse(TB_Iduser.Text);
                id_pedido.Id_pedido = pedido_Id;
                new DAOUser().ActualizarIdpedidoCarrito(id_pedido);


                //recorreo los producto que tiene el usuario en carrito
                foreach (var product in listCarrito)
                {
                    //inserto los productos en productos del pedido
                    EncapProducto_pedido producto = new EncapProducto_pedido();
                    producto.Pedido_id = id_pedido.Id_pedido;
                    producto.Producto_id = product.Producto_id;
                    producto.Cantidad = product.Cantidad.Value;
                    producto.Precio = product.Precio;
                    producto.Total = product.Total;
                    new DAOEmpleado().InsertarProductos(producto);



                    //descuento la cantidad del producto en el inventario
                    EncapInventario descontar = new EncapInventario();
                    descontar.Id = product.Producto_id;
                    descontar.Ca_actual = product.Cantidad.Value;
                    new DAOEmpleado().ActualizarCantidadInventario(descontar);

                }

                //elimino los productos en carrito del usuario 
                int id_user = ((EncapUsuario)Session["Valido"]).User_id;
                new DAOEmpleado().limpiarCarrito(id_user);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myAlert", "alert('Se genero el pedido No.00" + pedido_Id.ToString() + "');", true);
                Response.Redirect("FacturaVentanilla.aspx");
            }

        }
    }

    protected void GV_Clientes_RowUpdated(object sender, GridViewUpdatedEventArgs e)
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

    
}