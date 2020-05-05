using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_usuario_Carrito : System.Web.UI.Page
{

    private String valor;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void ODS_Carrito_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {

    }

    protected void GV_carrito_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewRow row = GV_carrito.Rows[e.NewEditIndex];
        var act = row.FindControl("Cant_Actual") as Label;
        valor = act.Text;
        //Label2.Text = valor;

        //var act1 = row.FindControl("validarCantidad") as RangeValidator;
        //act1.MaximumValue =Label2.Text;
        //act1.MinimumValue = ("1");
    }

    protected void GV_carrito_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    protected void GV_carrito_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {

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
        //creo objeto para realizar facturacion
        EncapPedido pedido = new EncapPedido();
        pedido.Fecha_pedido = DateTime.Now;
        pedido.User_id= ((EncapUsuario)Session["Valido"]).User_id;
        pedido.Atendido_id = 5;
        //creo una lista en la cual traigo todos los productos de carrito
        List<EncapCarrito> listCarrito = new DAOUser().ObtenerCarritoxUsuario(pedido.User_id);
        //se suma el valor total de todos los productos para obtener el valor final del pedido 
        pedido.Valor_total = listCarrito.Sum(x => x.Precio * x.Cantidad).Value;
        //agreago la lista de productos a Json
        pedido.Productos = JsonConvert.SerializeObject(listCarrito, Formatting.Indented, new JsonSerializerSettings
        {
            NullValueHandling=NullValueHandling.Ignore
        }) ;

        //obtengo id de pedido
        int facturaid= new DAOUser().InsertarPedido(pedido);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "myAlert", "alert('Se genero la factua No.00" + facturaid.ToString() + "');", true);
        //Metodo para limpiar del carrito los elementos que se facturaron
        new DAOUser().limpiarCarrito(pedido.User_id);
        GV_carrito.DataBind();
        
    }
}