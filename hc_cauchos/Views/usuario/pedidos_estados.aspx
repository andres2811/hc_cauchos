﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/usuario/usuario.master" AutoEventWireup="true" CodeFile="~/Controllers/usuario/pedidos_estados.aspx.cs" Inherits="Views_usuario_pedidos_estados" %>

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
    <h1 class="text-center text-primary"><strong>PEDIDOS ACTIVOS</strong></h1>
    <br />

    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="OBS_pedidos_activos" OnItemCommand="Repeater1_ItemCommand">
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
                  <asp:Button ID="BTN_factura"  class="btn btn-primary center-block" runat="server" Text="Ver factura" />
              </div>
            </div>          
        </ItemTemplate>
         <FooterTemplate>
                <h3 class="text-center">
                <asp:Label CssClass="alert-danger" ID="defaultItem" runat="server" 
                Visible='<%# Repeater1.Items.Count == 0 %>' Text="NO TIENE PEDIDOS EN PROCESO" /></h3>
         </FooterTemplate>
    </asp:Repeater>
    <asp:ObjectDataSource ID="OBS_pedidos_activos" runat="server" SelectMethod="ObtenerPedidosActivo" TypeName="DAOUser">
        <SelectParameters>
            <asp:SessionParameter Name="usu" SessionField="clienid" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>

