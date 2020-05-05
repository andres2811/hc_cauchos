using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_administrador_Proveedores : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EncapUsuario User = new EncapUsuario();
        User = new DAOAdmin().UsuarioActivo((string)Session["Nombre"]);
        if (User.Sesion == null)
        {
            Response.Redirect("../home.aspx");
        }


        TB_Refencia.Text = Session["ReferenciaAlerta"].ToString();
        TB_Refencia.Enabled = false;
        EncapInventario invent = new EncapInventario();
        invent = new DAOAdmin().BuscarInventario(invent, Session["ReferenciaAlerta"].ToString()) ;
        DDL_Proveedor.SelectedIndex = invent.Provedor_id;
        DDL_Proveedor.Enabled = false;
       
        TB_resultado.Text = invent.Precio.ToString();
        TB_resultado.Enabled = false;
       
        TB_Cantidad.Attributes.Add("onchange", "multiplicar()");
        TB_Total.Enabled = false;
        
    }

    

    protected void Button1_Click(object sender, EventArgs e)
    {

        EncapPedidoProveedor pedido = new EncapPedidoProveedor();
        EncapInventario inventario = new EncapInventario();
        inventario = new DAOAdmin().BuscarInventario(inventario, TB_Refencia.Text);
        pedido.Id_producto = inventario.Id;
        pedido.Id_estado = 1;
        pedido.Id_proveedor = DDL_Proveedor.SelectedIndex;
        pedido.Last_modify = DateTime.Now;
        var total = Convert.ToInt32(TB_Cantidad.Text)*Convert.ToInt32(TB_resultado.Text);
        pedido.Cant = Convert.ToInt32(TB_Cantidad.Text);
        pedido.Valor = (int)total;
        pedido.Session = (string)Session["Nombre"].ToString();
        pedido.T_entrega = DateTime.Now;

        new DAOAdmin().InsertarPedidoProveedor(pedido);



        this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Pedido Enviado');window.location=\" Alertas.aspx\"</script>");
    }   
}