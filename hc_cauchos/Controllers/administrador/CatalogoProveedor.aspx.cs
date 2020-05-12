using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class Views_administrador_CatalogoProveedor : System.Web.UI.Page
{
    private int contador = 0;
    private string aux = null;
    private int c = 0;
    private float total_producto = 0;
    public List<producto> Elementos = new List<producto>();

    protected void Page_Load(object sender, EventArgs e)

    {

        EncapUsuario User = new EncapUsuario();
        User = new DAOAdmin().UsuarioActivo((string)Session["Nombre"]);
        if (User.Sesion == null)
        {
            Response.Redirect("../home.aspx");
        }

        DDL_Proveedor.Attributes.Add("SelectedIndexChanged", "changes");
       
       
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DDL_Proveedor.SelectedIndex != 0)
        {
            Repeater1.DataSourceID = "ODS_productos";
        }
       
    }

    protected void DDL_Proveedor_SelectedIndexChanged(object sender, EventArgs e)
    {
        new DAOAdmin().LimpiarAux();//limpio la tabla si la persona tiene un producto pero no da click sobre enviar
        Btn_Cancelar.Visible = true;
        Btn_Enviar.Visible = true;
        Lb_total.Visible = true;
    }



    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        var tb_cantidad = e.Item.FindControl("TB_Cantidad") as TextBox;
        var lb_precio = e.Item.FindControl("Lb_Precio") as Label;
        var lb_producto_id = e.Item.FindControl("LB_id_producto") as Label;
        var lb_referencia = e.Item.FindControl("Lb_Referencia") as Label;
        var lb_precio_Producto = e.Item.FindControl("Lb_Total_Producto") as Label;
        var lb_cantidad = e.Item.FindControl("Lb_Cantidad") as Label;
        var lb_aux = e.Item.FindControl("Lb_aux") as Label;
        var btn = e.Item.FindControl("Btn_Agregar") as Button;
        var btn_c = e.Item.FindControl("Btn_Cancelar") as Button;



        if (tb_cantidad.Text != "")
        {
            int total = (Convert.ToInt32(tb_cantidad.Text)) * (Convert.ToInt32(lb_precio.Text));
         
            
           
            lb_precio_Producto.Text = total.ToString();

            if ((int)Session["Cont"] == 0)
            {

                Session["Cont"] = total;
                Lb_total.Text = Session["Cont"].ToString();
            }
            else
            {
                Session["Cont"] = (int)Session["Cont"] + total;
                Lb_total.Text = Session["Cont"].ToString();
            }

            //creo el objeto que voy a guardar en el json
            producto producto = new producto();
            producto.Referencia = lb_referencia.Text;
            producto.Cantidad = (Convert.ToInt32(tb_cantidad.Text));
            producto.Valor = total;


            new DAOAdmin().InsertarAux(producto);

            /*
            if (Session["Aux"].ToString() == "") {


                Session["Aux"] = JsonConvert.SerializeObject(producto);

            }
            else
            {
                Elementos.Add(producto);

                Session["Aux"] = Session["Aux"].ToString() + " , " + JsonConvert.SerializeObject(producto);
            }
            */




            btn.Enabled = false;
            tb_cantidad.Text = "";
            

        }




    }






    protected void Btn_Enviar_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        
        Mapeo db = new Mapeo();
        var consulta = (from aa in db.aux select aa.Id).Count();


        //enviamos los datos
        //valido que existan datos para hacer un pedido

        if (consulta != 0) {
            EncapPedidoProveedor pedidoProveedor = new EncapPedidoProveedor();
            pedidoProveedor.Id_estado = 1;
            pedidoProveedor.Id_proveedor = Convert.ToInt32(DDL_Proveedor.SelectedValue);
            pedidoProveedor.Valor = Convert.ToDouble(Lb_total.Text);
            pedidoProveedor.Session = (string)Session["Nombre"].ToString();
            pedidoProveedor.Last_modify = DateTime.Now;
            
            //obtenemos tiempo que tarda el proveedor
            var horas = (from x in db.proveedor.Where(x => x.Id == pedidoProveedor.Id_proveedor) select x.Tiempo_envio).FirstOrDefault();
            pedidoProveedor.T_entrega = DateTime.Now.AddHours((horas));


            Elementos = new DAOAdmin().ColsultarAux();




            


            pedidoProveedor.Elementos = JsonConvert.SerializeObject(Elementos, Formatting.Indented, new JsonSerializerSettings
            {

                NullValueHandling = NullValueHandling.Ignore
            });


            new DAOAdmin().InsertarPedidoProveedor(pedidoProveedor);
            new DAOAdmin().LimpiarAux();


            Session["Cont"] = 0;
            this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Pedido Enviado');window.location=\"CatalogoProveedor.aspx\"</script>");


        }else
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('No hay productos para hacer un pedido ' );</script>");
            return;

        }






    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {

            var tb_ = e.Item.FindControl("TB_Cantidad") as TextBox;

          

        }

    }

    protected void Btn_Cancelar_Click1(object sender, EventArgs e)
    {
        //limpio y reinicio repeater 
        Repeater1.DataSourceID = "ODS_productos";
        Repeater1.DataBind();
        Session["Cont"] = 0;
        Lb_total.Text = "";
        new DAOAdmin().LimpiarAux();
    }
    public void ActivarBotones()
    {
        Btn_Enviar.Visible = true;
        Btn_Cancelar.Visible = false;
    }
    public void DesactivarBotones()
    {
        Btn_Enviar.Visible = true;
        Btn_Cancelar.Visible = false;
    }
}