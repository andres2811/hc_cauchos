﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/usuario/usuario.master" AutoEventWireup="true" CodeFile="~/Controllers/usuario/Carrito.aspx.cs" Inherits="Views_usuario_Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1 class="text-center"><strong>Mi Carrito</strong></h1>
    <asp:Button ID="BTN_MasPro" runat="server" Text="Agregar mas productos" class="btn btn-primary" OnClick="BTN_MasPro_Click"/>
    <div class="row">
        <div class=" col-lg-12 col-md-offset-0.5">
             <div style="overflow-x: auto;">  
                 <asp:GridView ID="GV_carrito" runat="server" AutoGenerateColumns="False" DataKeyNames="Id_Carrito" DataSourceID="ODS_carrito" OnRowEditing="GV_carrito_RowEditing" OnRowUpdating="GV_carrito_RowUpdating" OnRowUpdated="GV_carrito_RowUpdated" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1083px">
                     <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                     <Columns>
                         <asp:BoundField DataField="Nom_producto" HeaderText="Producto" SortExpression="Nom_producto" ReadOnly="true"/>
                         <asp:TemplateField HeaderText="Stock" SortExpression="Cant_Actual" >
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Cant_Actual") %>' ReadOnly="true"></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Cant_Actual" runat="server" Text='<%# Bind("Cant_Actual") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Cantidad Pedida" SortExpression="Cantidad">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TB_Cantidad" runat="server" Text='<%# Bind("Cantidad") %>' TextMode="Number"></asp:TextBox>
                                 <asp:RangeValidator ID="RV_cantidad" runat="server" ErrorMessage="valor invalido" ControlToValidate="TB_Cantidad" MaximumValue="1000" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="LB_Cantidad" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" ReadOnly="true" />
                         <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" ReadOnly="true"/>
                         <asp:CommandField HeaderText="editar" ShowEditButton="True" />
                         <asp:CommandField HeaderText="eliminar" ShowDeleteButton="True" />
                     </Columns>
                     <EditRowStyle BackColor="#999999" />
                     <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                     <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                     <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                     <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                     <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                     <SortedAscendingCellStyle BackColor="#E9E7E2" />
                     <SortedAscendingHeaderStyle BackColor="#506C8C" />
                     <SortedDescendingCellStyle BackColor="#FFFDF8" />
                     <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                 </asp:GridView>
                 <asp:ObjectDataSource ID="ODS_carrito" runat="server" DataObjectTypeName="EncapCarrito" SelectMethod="ObtenerCarritoxUsuario" TypeName="DAOUser" UpdateMethod="ActualizarCarritoFactura" DeleteMethod="EliminarItemCarrito">
                     <SelectParameters>
                         <asp:SessionParameter Name="usu" SessionField="userid" Type="Int32" />
                     </SelectParameters>
                 </asp:ObjectDataSource>
            </div>
        </div>
    </div>
    <br />
    <asp:ImageButton ID="BTN_Facturar" runat="server" ImageUrl="~/ima/business-and-finance(1).png" OnClick="BTN_Facturar_Click" />
</asp:Content>

