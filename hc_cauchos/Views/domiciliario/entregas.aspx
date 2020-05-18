﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/domiciliario/domiciliario.master" AutoEventWireup="true" CodeFile="~/Controllers/domiciliario/entregas.aspx.cs" Inherits="Views_domiciliario_entregas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <h1 class="text-center"><strong>PEDIDOS PARA ENTREGAR</strong></h1>
    <br />

        <asp:Repeater ID="R_pedido" runat="server" DataSourceID="ODS_entregas" OnItemCommand="R_pedido_ItemCommand"  >
        <ItemTemplate>
            <div class="card text-center bg-primary fa-border border-dark mb-5 col-sm-6">
              <div class="card-header">
                  <strong><h1>Pedido No.<asp:Label ID="Id" runat="server" Text='<%# Eval("Id") %>' class="card-text" /></h1></strong>        
              </div>
              <div class="card-body">
                  <h3  class="card-text">Realizado: <asp:Label ID="Label1" runat="server" Text='<%# Eval("Fecha_pedido") %>' class="card-text" /></h3>
                  <h3  class="card-text">Cliente: <asp:Label ID="Label2" runat="server" Text='<%# Eval("Usuario") %>' class="card-text" /></h3>
                  <h3  class="card-text">Ciudad/departamento: <asp:Label ID="Label3" runat="server" Text='<%# Eval("Ciu_dep_id") %> ' class="card-text" /></h3>
                   <h3  class="card-text">Municipio: <asp:Label ID="Label4" runat="server" Text='<%# Eval("Municipio_id") %>' class="card-text" /></h3>
                   <h3  class="card-text">Direccion: <asp:Label ID="Label5" runat="server" Text='<%# Eval("Direccion") %>' class="card-text" /></h3>
                  <asp:Button ID="BTN_Detalles" runat="server" Text="Alistar" class="btn btn-primary" />
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
</asp:Content>
