using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_usuario_catalogoUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //obtengo el usuario que esta en session en el momento 
        int iduser = ((EncapUsuario)Session["Valido"]).User_id;
        Session["userid"] = iduser;
        //numero de cantidad en el carrito 
        LB_cantidad.Text = new DAOUser().ObtenerCantidadxProductoCarritoxUser(iduser).ToString();
    }

    protected void BTNI_carritoAdd_Click(object sender, ImageClickEventArgs e)
    { 

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
            if ( cantidadSolicitada > stock )
            {          
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('Cantidad no disponible.');</script>");
                return;
            }


            EncapCarrito verificar = new EncapCarrito();
            verificar.Producto_id= int.Parse(e.CommandArgument.ToString());
            verificar.User_id = ((EncapUsuario)Session["Valido"]).User_id;
            //verifico si el item agregado existe en el carrito 
           var veri2= new DAOUser().verificarArticuloEnCarrito(verificar);
            //si existe se suma  al item en el carrito 
            if (veri2 != null)
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
                new DAOUser().InsertarCarrito(carrito);        
            }
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('Producto agregado a carrito');</script>");
            Response.Redirect("catalogoUsuario.aspx");
            return;
        }
    }
}