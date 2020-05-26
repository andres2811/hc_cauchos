<%@ Page Title="" Language="C#" MasterPageFile="~/Views/empleado/empleado.master" AutoEventWireup="true" CodeFile="~/Controllers/empleado/pedidos_atender.aspx.cs" Inherits="Views_empleado_pedidos_atender" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h1 class="text-center text-primary"><strong>PEDIDOS PARA ALISTAR</strong></h1>
    <br />

        <asp:Repeater ID="R_pedido" runat="server" DataSourceID="ODS_pedidos" OnItemCommand="R_pedido_ItemCommand" >
        <ItemTemplate>
            <div class="card text-center bg-primary fa-border border-dark mb-5">
              <div class="card-header">
                  <strong><h1>Pedido No.<asp:Label ID="Id" runat="server" Text='<%# Eval("Id") %>' class="card-text" /></h1></strong>        
              </div>
              <div class="card-body">
                  <h3  class="card-text">Realizado: <asp:Label ID="Label1" runat="server" Text='<%# Eval("Fecha_pedido") %>' class="card-text" /></h3>
                  <h3  class="card-text">Cliente: <asp:Label ID="Label2" runat="server" Text='<%# Eval("Usuario") %>' class="card-text" /></h3>
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

    <asp:ObjectDataSource ID="ODS_Productos" runat="server" SelectMethod="ObtenerProductos" TypeName="DAOEmpleado">
        <SelectParameters>
            <asp:SessionParameter Name="pedido" SessionField="idpedido" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <div class="text-center center-block" style=" width:50%;">
        <asp:Panel runat="server" ID="PanelMensaje2" Visible="false" CssClass="alert alert-success shadow" role="alert">
	        <strong>
	        <asp:Label ID="LblMensaje2" runat="server" />
	        </strong>
	        <asp:LinkButton Text="<span aria-hidden='true'>&times;</span>" runat="server" CssClass="close" ID="LinkButton2" OnClick="LinkButton2_Click"/>
        </asp:Panel>
    </div>

    <br />  
    <h1 class="text-center text-primary"><strong>TABLA DE PRODUCTOS</strong></h1>
    <br />

    <div class="row">
        <div class=" col-lg-12 col-md-offset-0.5">
             <div style="overflow-x: auto;">  
                  <table class="table table-striped">
                      <thead>
                        <tr>
                          <th scope="col">#</th>
                          <th scope="col"><h3>Nombre Producto</h3></th>
                          <th scope="col"><h3>Referencia</h3></th>
                          <th scope="col"><h3>Cantidad solicitada</h3></th>
                          <th scope="col"><h3>Total</h3></th>
                        </tr>
                      </thead>
                      <tbody>
                          <asp:Repeater ID="R_pro" runat="server" DataSourceID="ODS_pro">
                            <ItemTemplate>
                                <tr>
                                  <th scope="row">1</th>
                                  <td><asp:Label ID="Nom_produc" runat="server" Text='<%# Eval("Nombre_producto") %>' class="card-text" /></td>
                                  <td><asp:Label ID="Referencia" runat="server" Text='<%# Eval("Referencia") %>' class="card-text" /></td>
                                  <td><asp:Label ID="Cantidad" runat="server" Text='<%# Eval("Cantidad") %>' class="card-text" /></td>
                                  <td><asp:Label ID="Total" runat="server" Text='<%# Eval("Total") %>' class="card-text" /></td>
                                </tr> 
                            </ItemTemplate>
                        </asp:Repeater>             
                      </tbody>
                    </table>
             </div>
        </div>
    </div>
           
    

    <div class="center-block">
        <asp:TextBox ID="TB_novedad" runat="server" TextMode="MultiLine"  class="form-group" placeholder="Ingrese novedades del pedido" Width="37%"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="TB_novedad" ValidationGroup="novedad"></asp:RequiredFieldValidator>
        <br />
         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Solo de admiten letras y numeros" ControlToValidate="TB_novedad" ValidationExpression="^[0-9a-zA-Z]+$" ForeColor="Red" Font-Size=""></asp:RegularExpressionValidator>
        &nbsp;<br />
        <asp:Button ID="BTN_confirmar" runat="server" Text="Confirmar Alistamiento" class="btn btn-primary" ValidationGroup="novedad" OnClick="BTN_confirmar_Click" /> 
        <br />
        <br />
        
        <asp:ObjectDataSource ID="ODS_pro" runat="server" SelectMethod="ObtenerProductos" TypeName="DAOEmpleado">
            <SelectParameters>
                <asp:SessionParameter Name="pedido" SessionField="idpedido" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
    </div>
    
<asp:ObjectDataSource ID="ODS_pedidos" runat="server" SelectMethod="ObtenerPedidos" TypeName="DAOEmpleado">
    <SelectParameters>
        <asp:SessionParameter Name="user" SessionField="empleid" Type="Int32" DefaultValue="" />
    </SelectParameters>
</asp:ObjectDataSource>
</asp:Content>

