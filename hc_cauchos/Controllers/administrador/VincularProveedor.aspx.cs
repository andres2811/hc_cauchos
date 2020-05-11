using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_administrador_VincularProveedor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        EncapUsuario User = new EncapUsuario();
        User = new DAOAdmin().UsuarioActivo((string)Session["Nombre"]);
        if (User.Sesion == null)
        {
            Response.Redirect("../home.aspx");
        }
        
        DDL_proveedores.Attributes.Add("SelectedIndexChanged", " disable() ");
    }

    protected void BTN_vincular_Click(object sender, EventArgs e)
    {


        ClientScriptManager cm = this.ClientScript;
        EncapProductoProveedor producto = new EncapProductoProveedor();
        producto.Proveedor_id = Convert.ToInt32(DDL_proveedores.SelectedValue);
        producto.Producto_id = Convert.ToInt32(DDL_producto.SelectedValue);
        producto.Precio = Convert.ToInt32(TB_precio.Text);
        producto.Session = (string)Session["Nombre"].ToString();
        producto.Cantidad = 0;
        producto.Last_modify = DateTime.Now;

        EncapInventario inventario_id = new EncapInventario();
        inventario_id = new DAOAdmin().BuscarId(inventario_id, producto.Producto_id);



        Mapeo db = new Mapeo();
        //valido que no haya la misma referencia con el mismo producto.Proveedor_id
        var cont = (from x in db.producto_proveedor where x.Proveedor_id == producto.Proveedor_id && x.Producto_id == inventario_id.Id select x.Id).Count();

        if(cont == 1)
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('Producto ya vinculado');</script>");
            return;
        }

        new DAOAdmin().InsertarProductoProveedor(producto);

        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('Producto vinculado correctamente.');</script>");
       
        TB_precio.Text = "";
        


    }

    protected void DDL_proveedores_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}