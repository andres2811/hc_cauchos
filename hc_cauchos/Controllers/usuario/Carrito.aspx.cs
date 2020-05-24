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
        EncapUsuario User = new EncapUsuario();
        User = new DAOAdmin().UsuarioActivo2((string)Session["Correo"]);
        if (User == null || Session["Valido"]== null)
        {
            Response.Redirect("../home.aspx");
        }
        if (User.Rol_id != 4)
        {
            Response.Redirect("../home.aspx");
        }

        EncapCarrito verificarPedido = new EncapCarrito();
        verificarPedido.User_id = ((EncapUsuario)Session["Valido"]).User_id;
        var verificar1 = new DAOUser().verificarUsuarioTienePedido(verificarPedido);
        if (verificar1 != null) {
            BTN_facturar1.Visible = false;
            DDL_Lugar.Visible = false;
        }
        else
        {
            DDL_Lugar.Visible = true;
            BTN_facturar1.Visible = true;
        }

        PanelMensaje.Visible = false;
        PanelMensaje1.Visible = false;
        PanelMensaje2.Visible = false;
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

    protected void BTN_Facturar_Click(object sender, ImageClickEventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;

        List<EncapCarrito> listCarritoC = new DAOUser().ObtenerCarritoxUsuario(((EncapUsuario)Session["Valido"]).User_id);
        if (listCarritoC.Count == 0)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "myAlert", "alert('Debe ingresar productos antes de realizar una compra');", true);
            MostrarMensaje1($"Debe ingresar productos antes de realizar una compra");
            return;
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
            pedido.User_id = ((EncapUsuario)Session["Valido"]).User_id;
            //pedido.Atendido_id = 5;
            //Campos de Direccion
            pedido.Ciu_dep_id = DDL_Lugar.SelectedIndex;
            //pedido.Municipio_id = DDL_Municipio.SelectedIndex;
            pedido.Direccion = TB_Direccion.Text;
            List<EncapCarrito> listCarrito = new DAOUser().ObtenerCarritoxUsuario(pedido.User_id);
            pedido.Total = listCarrito.Sum(x => x.Precio * x.Cantidad).Value;
            int pedido_Id = new DAOUser().InsertarPedido(pedido);


            //agrego a carrito el pedido
            EncapCarrito id_pedido = new EncapCarrito();
            id_pedido.User_id = ((EncapUsuario)Session["Valido"]).User_id;
            id_pedido.Id_pedido = pedido_Id;
            new DAOUser().ActualizarIdpedidoCarrito(id_pedido);

            //obtengo tiempo de inventario
            EncapParametros tiempo = new EncapParametros();
            tiempo.Nombre = "tiempocarrito";
            var time = new DAOUser().ObtenerTiempo(tiempo);
            int tiempoadmin =int.Parse (time.Valor);

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "myAlert", "alert('Se genero el pedido No.00"+ pedido_Id.ToString()+" asdasd ');", true);
            MostrarMensaje2($"Se ha generado el pedido No. "+ pedido_Id.ToString()+"");
            Response.Redirect("Carrito.aspx");
            return;
            
        }
    }


    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("catalogoUsuario.aspx");
    }

    protected void DDL_Departamento_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;

        var db = new Mapeo();

            TB_Direccion.Visible = true;
       
    }

    protected void BTN_facturar1_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;

        List<EncapCarrito> listCarritoC = new DAOUser().ObtenerCarritoxUsuario(((EncapUsuario)Session["Valido"]).User_id);
        if (listCarritoC.Count == 0)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "myAlert", "alert('Debe ingresar productos antes de realizar una compra');", true);
            MostrarMensaje1($"Debe ingresar productos antes de realizar una compra");
            return;
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
            pedido.User_id = ((EncapUsuario)Session["Valido"]).User_id;
            //pedido.Atendido_id = 5;
            //Campos de Direccion
            pedido.Ciu_dep_id = DDL_Lugar.SelectedIndex;
            //pedido.Municipio_id = DDL_Municipio.SelectedIndex;
            pedido.Direccion = TB_Direccion.Text;
            List<EncapCarrito> listCarrito = new DAOUser().ObtenerCarritoxUsuario(pedido.User_id);
            pedido.Total = listCarrito.Sum(x => x.Precio * x.Cantidad).Value;
            int pedido_Id = new DAOUser().InsertarPedido(pedido);


            //agrego a carrito el pedido
            EncapCarrito id_pedido = new EncapCarrito();
            id_pedido.User_id = ((EncapUsuario)Session["Valido"]).User_id;
            id_pedido.Id_pedido = pedido_Id;
            new DAOUser().ActualizarIdpedidoCarrito(id_pedido);

            //obtengo tiempo de inventario
            EncapParametros tiempo = new EncapParametros();
            tiempo.Nombre = "tiempocarrito";
            var time = new DAOUser().ObtenerTiempo(tiempo);
            int tiempoadmin = int.Parse(time.Valor);

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "myAlert", "alert('Se genero el pedido No.00" + pedido_Id.ToString() + " asdasd ');", true);
            //Response.Redirect("Carrito.aspx");
            MostrarMensaje2($"Se ha generado el pedido No. " + pedido_Id.ToString() + "");
            MostrarMensaje1($"Recuerde que tiene un tiempo de " + tiempoadmin.ToString() + " minutos para modificar su pedido y ver su factura.");
            return;
        }
    }

    protected void BTN_mas_Click(object sender, EventArgs e)
    {
        Response.Redirect("catalogoUsuario.aspx");
    }

    protected void B_cerrar_mensaje1_Click(object sender, EventArgs e)
    {
        PanelMensaje.Visible = false;
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        PanelMensaje1.Visible = false;
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        PanelMensaje2.Visible = false;
    }


    private void MostrarMensaje(string mensaje)
    {
        LblMensaje.Text = mensaje;
        PanelMensaje.Visible = true;
    }

    private void MostrarMensaje1(string mensaje)
    {
        LblMensaje1.Text = mensaje;
        PanelMensaje1.Visible = true;
    }

    private void MostrarMensaje2(string mensaje)
    {
        LblMensaje2.Text = mensaje;
        PanelMensaje2.Visible = true;
    }
}
 