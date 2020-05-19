<%@ Page Title="" Language="C#" MasterPageFile="~/Views/domiciliario/domiciliario.master" AutoEventWireup="true" CodeFile="~/Controllers/domiciliario/entregas.aspx.cs" Inherits="Views_domiciliario_entregas" %>

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
       <h1 class="text-center text-primary"><strong>PEDIDOS PARA ENTREGAR</strong></h1>
    <br />

        <asp:Repeater ID="R_pedido" runat="server" DataSourceID="ODS_entregas" OnItemCommand="R_pedido_ItemCommand"  >
        <ItemTemplate>
            <div id="carta" class="card text-center bg-primary fa-border border-dark mb-5 col-sm-6">
              <div class="card-header">
                  <strong><h1>Pedido No.<asp:Label ID="Id" runat="server" Text='<%# Eval("Id") %>' class="card-text" /></h1></strong>        
              </div>
              <div class="card-body">
                  <h3  class="card-text">Realizado: <asp:Label ID="Label1" runat="server" Text='<%# Eval("Fecha_pedido") %>' class="card-text" /></h3>
                  <h3  class="card-text">Cliente: <asp:Label ID="Label2" runat="server" Text='<%# Eval("Usuario") %>' class="card-text" /></h3>
                   <h3  class="card-text">Ciudad: <asp:Label ID="Label4" runat="server" Text='<%# Eval("Municipio") %>' class="card-text" /></h3>
                   <h3  class="card-text">Direccion: <asp:Label ID="Label5" runat="server" Text='<%# Eval("Direccion") %>' class="card-text" /></h3>
                  <asp:Button ID="BTN_Detalles" runat="server" Text="Entregado" class="btn btn-primary" />
              </div>
            </div>          
        </ItemTemplate>
            <FooterTemplate>
                <h3 class="text-center">
                <asp:Label CssClass="alert-danger" ID="defaultItem" runat="server" 
                Visible='<%# R_pedido.Items.Count == 0 %>' Text="NO HAY PEDIDOS PARA ALISTAR" /></h3>
            </FooterTemplate>
    </asp:Repeater>
       <asp:ObjectDataSource ID="ODS_entregas" runat="server" SelectMethod="ObtenerPedidos" TypeName="DAODomiciliario">
           <SelectParameters>
               <asp:SessionParameter Name="user" SessionField="domiid" Type="Int32" />
           </SelectParameters>
       </asp:ObjectDataSource>

    <br />
    <br />
</asp:Content>

