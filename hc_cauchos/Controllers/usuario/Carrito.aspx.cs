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
        User = new DAOAdmin().UsuarioActivo((string)Session["Nombre"]);
        if (User.Sesion == null)
        {
            Response.Redirect("../home.aspx");
        }

        EncapCarrito verificarPedido = new EncapCarrito();
        verificarPedido.User_id = ((EncapUsuario)Session["Valido"]).User_id;
        var verificar1 = new DAOUser().verificarUsuarioTienePedido(verificarPedido);
        if (verificar1 != null) {
            BTN_Facturar.Visible = false;
            LB_facturar.Visible = false;
            DDL_Departamento.Visible = false;
        }
        else
        {
            DDL_Departamento.Visible = true;
            BTN_Facturar.Visible = true;
            LB_facturar.Visible = true;
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

    protected void BTN_Facturar_Click(object sender, ImageClickEventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;

        List<EncapCarrito> listCarritoC = new DAOUser().ObtenerCarritoxUsuario(((EncapUsuario)Session["Valido"]).User_id);
        if (listCarritoC.Count == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myAlert", "alert('Debe ingresar productos antes de realizar una compra');", true);
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
            pedido.Atendido_id = 5;
            //Campos de Direccion
            pedido.Ciu_dep_id = DDL_Departamento.SelectedIndex;
            pedido.Municipio_id = DDL_Municipio.SelectedIndex;
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

            ScriptManager.RegisterStartupScript(this, this.GetType(), "myAlert", "alert('Se genero el pedido No.00"+ pedido_Id.ToString()+" asdasd ');", true);
            Response.Redirect("Carrito.aspx");
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

        var consulta = (from x in db.municipios.Where(x => x.Id_de == DDL_Departamento.SelectedIndex )select x.Id).Count();
        if (DDL_Departamento.SelectedIndex != 0 &&  consulta != 0 ) {
            Lb_municipio.Visible = true;
            DDL_Municipio.Visible = true;
            TB_Direccion.Visible = true;
        }
        else
        {
            Lb_municipio.Visible = false;
            DDL_Municipio.Visible = false;
            TB_Direccion.Visible = false;
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('No hay municipios vinculados para este departamento ' );</script>");
            return;
        }
       
    }
}
 