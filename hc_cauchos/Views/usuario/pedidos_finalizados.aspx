<%@ Page Title="" Language="C#" MasterPageFile="~/Views/usuario/usuario.master" AutoEventWireup="true" CodeFile="~/Controllers/usuario/pedidos_finalizados.aspx.cs" Inherits="Views_usuario_pedidos_finalizados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        #carta:hover{
            background:rgba(0, 148, 255,0.4);
            color:black;
            border:solid 1px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <h1 class="text-center text-primary"><strong>PEDIDOS FINALIZADOS <br />
        <small>la lista se reiniciara mensualmente</small></strong></h1>
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ODS_pedidos_fin" OnItemCommand="Repeater1_ItemCommand">
        <ItemTemplate>
            <div id="carta" class="card text-center bg-primary fa-border border-dark mb-5 col-sm-6">
              <div class="card-header">
                  <strong><h1>Pedido No.<asp:Label ID="Id" runat="server" Text='<%# Eval("Id") %>' class="card-text" /></h1></strong>        
              </div>
              <div class="card-body">

                  <h4  class="card-text"><strong>Realizado el dia: </strong><asp:Label ID="Label1" runat="server" Text='<%# Eval("Fecha_pedido") %>' class="card-text" /></h4>
                  <h4  class="card-text"><strong>Lugar de entrega: <asp:Label ID="Label3" runat="server" Text='<%# Eval("Ciudad_dep") %> ' class="card-text" /></h4>
                  <h4  class="card-text"><strong>Direccion: </strong><asp:Label ID="Label5" runat="server" Text='<%# Eval("Direccion") %>' class="card-text" /></h4>  
                  <h4  class="card-text"><strong>Estado: </strong><asp:Label ID="Label6" runat="server" Text='<%# Eval("Estado") %>' class="card-text" /></h4>
                  <h4  class="card-text"><strong>Empleados: </strong>EMPLEADO(<asp:Label ID="Label8" runat="server" Text='<%# Eval("Empleado") %>' class="card-text" />) DOMICILIARIO(<asp:Label ID="Label7" runat="server" Text='<%# Eval("Domiciliaro") %>' class="card-text" />)</h4>
                  <h4  class="card-text"><strong>Fecha de entrega: </strong><asp:Label ID="Label2" runat="server" Text='<%# Eval("Fecha_pedido_fin") %>' class="card-text" /></h4>
                  <h4  class="card-text"><strong>Novedad: </strong><asp:Label ID="Label4" runat="server" Text='<%# Eval("Novedad") %>' class="card-text" /></h4>
                  <asp:Button ID="BTN_factura"  class="btn btn-primary center-block" runat="server" Text="Ver factura" />
              </div>
            </div> 
        </ItemTemplate>
         <FooterTemplate>
                <h3 class="text-center">
                <asp:Label CssClass="alert-danger" ID="defaultItem" runat="server" 
                Visible='<%# Repeater1.Items.Count == 0 %>' Text="NO TIENE PEDIDOS FINALIZADOS" /></h3>
            </FooterTemplate>
    </asp:Repeater>
    <asp:ObjectDataSource ID="ODS_pedidos_fin" runat="server" SelectMethod="ObtenerPedidosFin" TypeName="DAOUser">
        <SelectParameters>
            <asp:SessionParameter Name="usu" SessionField="clienid" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
</asp:Content>

