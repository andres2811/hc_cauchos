using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_empleado_facturar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EncapUsuario User = new EncapUsuario();
        User = new DAOAdmin().UsuarioActivo((string)Session["Nombre"]);
        if (User.Sesion == null)
        {
            Response.Redirect("../home.aspx");
        }
        //obtengo el usuario que esta en session en el momento 
        int iduser = ((EncapUsuario)Session["Valido"]).User_id;
        Session["userid"] = iduser;
        //numero de cantidad en el carrito 
        LB_cantidad.Text = new DAOEmpleado().ObtenerCantidadxProductoCarritoxEmple(iduser).ToString();

    }


    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        //se obtiene el item del inventario    
        int precio = int.Parse(((Label)e.Item.FindControl("PrecioLabel")).Text);
        int stock = int.Parse(((Label)e.Item.FindControl("Ca_actualLabel")).Text);
        int cantidadSolicitada = int.Parse(((TextBox)e.Item.FindControl("TB_cantidad")).Text);
        int cantidadDisponible = new DAOUser().ObtenerCantidadxProductoCarrito(int.Parse(e.CommandArgument.ToString()));
        //primero buscar el control y validar que sea diferente de NULL 
        if (e.Item.FindControl("TB_cantidad") != null || cantidadSolicitada > cantidadDisponible)
        {
            //obtengo los valores de los controles y verifico cantidad de pedir a existente
            if (cantidadSolicitada > stock)
            {
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('Cantidad no disponible.');</script>");
                return;
            }

            EncapCarrito verificarPedido = new EncapCarrito();
            verificarPedido.User_id = ((EncapUsuario)Session["Valido"]).User_id;
            var verificar1 = new DAOUser().verificarUsuarioTienePedido(verificarPedido);
            //verifica si el vendedor esta atendiendo pedido 
            if (verificar1 != null)
            {
                EncapCarrito verificarItem = new EncapCarrito();
                verificarItem.Producto_id = int.Parse(e.CommandArgument.ToString());
                verificarItem.User_id = ((EncapUsuario)Session["Valido"]).User_id;
                //verifico si el item agregado existe en el carrito 
                var verificar2 = new DAOUser().verificarArticuloEnCarrito(verificarItem);
                //si existe se suma  al item en el carrito 
                if (verificar2 != null)
                {
                    //actualizo cantidad de item existente en base de datos 
                    EncapCarrito carrito = new EncapCarrito();
                    carrito.Producto_id = int.Parse(e.CommandArgument.ToString());
                    carrito.User_id = ((EncapUsuario)Session["Valido"]).User_id;
                    carrito.Cantidad = cantidadSolicitada;
                    carrito.Fecha = DateTime.Now;
                    carrito.Precio = precio;
                    carrito.Total = precio * cantidadSolicitada;
                    new DAOUser().ActualizarCarritoItems(carrito);
                }
                else
                {
                    //si no existe se agrega a la lista del carrito 
                    EncapCarrito carrito = new EncapCarrito();
                    carrito.Producto_id = int.Parse(e.CommandArgument.ToString());
                    carrito.User_id = ((EncapUsuario)Session["Valido"]).User_id;
                    carrito.Cantidad = cantidadSolicitada;
                    carrito.Fecha = DateTime.Now;
                    carrito.Precio = precio;
                    carrito.Total = precio * cantidadSolicitada;
                    carrito.Estadocar = 1;
                    carrito.Id_pedido = verificar1.Id_pedido;
                    new DAOUser().InsertarCarrito(carrito);
                }

            }
            //////////////////////////////////////////////////////////////////////////////////////////////////
            else
            {
                EncapCarrito verificarItem = new EncapCarrito();
                verificarItem.Producto_id = int.Parse(e.CommandArgument.ToString());
                verificarItem.User_id = ((EncapUsuario)Session["Valido"]).User_id;
                //verifico si el item agregado existe en el carrito 
                var verificar2 = new DAOUser().verificarArticuloEnCarrito(verificarItem);
                //si existe se suma  al item en el carrito 
                if (verificar2 != null)
                {
                    //actualizo cantidad de item existente en base de datos 
                    EncapCarrito carrito = new EncapCarrito();
                    carrito.Producto_id = int.Parse(e.CommandArgument.ToString());
                    carrito.User_id = ((EncapUsuario)Session["Valido"]).User_id;
                    carrito.Cantidad = cantidadSolicitada;
                    carrito.Fecha = DateTime.Now;
                    carrito.Precio = precio;
                    carrito.Total = precio * cantidadSolicitada;
                    new DAOUser().ActualizarCarritoItems(carrito);
                }
                else
                {
                    //si no existe se agrega a la lista del carrito 
                    EncapCarrito carrito = new EncapCarrito();
                    carrito.Producto_id = int.Parse(e.CommandArgument.ToString());
                    carrito.User_id = ((EncapUsuario)Session["Valido"]).User_id;
                    carrito.Cantidad = cantidadSolicitada;
                    carrito.Fecha = DateTime.Now;
                    carrito.Precio = precio;
                    carrito.Total = precio * cantidadSolicitada;
                    carrito.Estadocar = 1;
                    new DAOUser().InsertarCarrito(carrito);
                }

            }

            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('Producto agregado a carrito');</script>");
            Response.Redirect("facturar.aspx");
            return;
        }
    }


    protected void Btn_Buscar_Click(object sender, EventArgs e)
    {
        //filtros Marca y categoria
        if (DD_Categoria.SelectedIndex != 0)
        {
            Repeater1.DataSourceID = "ODS_catalogoCategoria";

        }
        if (DD_Marca.SelectedIndex != 0)
        {
            Repeater1.DataSourceID = "ODS_catalogoMarca";
        }
        if (DD_Marca.SelectedIndex != 0 && DD_Categoria.SelectedIndex != 0)
        {
            Repeater1.DataSourceID = "ODS_catalogoCombinado";
        }
        //validaciones Precio marca y categoria
        if (DDL_Precio.SelectedIndex != 0)
        {
            Repeater1.DataSourceID = "ODS_catalogoPrecio";
        }
        if (DD_Categoria.SelectedIndex != 0 && DDL_Precio.SelectedIndex != 0)
        {
            Repeater1.DataSourceID = "ODS_catalogoPrecioCategoria";
        }
        if (DD_Marca.SelectedIndex != 0 && DDL_Precio.SelectedIndex != 0)
        {
            Repeater1.DataSourceID = "ODS_catalogoPrecioMarca";
        }
        if (DD_Categoria.SelectedIndex != 0 && DD_Marca.SelectedIndex != 0 && DDL_Precio.SelectedIndex != 0)
        {
            Repeater1.DataSourceID = "ODS_catalogoPrecioCombinado";
        }
    }

    protected void Btn_Todos_Click(object sender, EventArgs e)
    {
        Repeater1.DataSourceID = "ODS_catalogo";
        DDL_Precio.SelectedIndex = 0;
        DD_Marca.SelectedIndex = 0;
        DD_Categoria.SelectedIndex = 0;
    }
}
