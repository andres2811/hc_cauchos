<%@ Page Title="" Language="C#" MasterPageFile="~/Views/usuario/usuario.master" AutoEventWireup="true" CodeFile="~/Controllers/usuario/Carrito.aspx.cs" Inherits="Views_usuario_Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1 class="text-center"><strong>Mi Carrito</strong></h1>
    <div align="center">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/ima/configurar.png" align="center" />
    </div>
    <div class="row">
        <div class=" col-lg-12 col-md-offset-0.5">
             <div style="overflow-x: auto;">  
                 <asp:gridview runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ODS_carrito" ForeColor="#333333" GridLines="None" Width="649px">
                     <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                     <Columns>
                         <asp:BoundField DataField="Nom_producto" HeaderText="nombre" SortExpression="Nom_producto" />
                         <asp:TemplateField HeaderText="Cantidad" SortExpression="Cantidad">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Cantidad") %>' TextMode="Number"></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label1" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:BoundField DataField="Cant_Actual" HeaderText="stock" SortExpression="Cant_Actual" />
                         <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total"/>
                         <asp:CommandField HeaderText="Eliminar" ShowDeleteButton="True" />
                         <asp:CommandField HeaderText="Editar" ShowEditButton="True" />
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
                 </asp:gridview>
                 <asp:ObjectDataSource ID="ODS_carrito" runat="server" DataObjectTypeName="EncapCarrito" DeleteMethod="EliminarItemCarrito" SelectMethod="ObtenerCarritoxUsuario" TypeName="DAOUser" UpdateMethod="ActualizarCarritoFactura">
                     <SelectParameters>
                         <asp:SessionParameter DefaultValue="0" Name="usu" SessionField="userid" Type="Int32" />
                     </SelectParameters>
                 </asp:ObjectDataSource>
            </div>
        </div>
    </div>
</asp:Content>

