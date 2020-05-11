<%@ Page Title="" Language="C#" MasterPageFile="~/Views/administrador/admin.master" AutoEventWireup="true" CodeFile="~/Controllers/administrador/PedidosProveedor.aspx.cs" Inherits="Views_administrador_PedidosProveedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="row">
        <div class=" col-lg-12 col-md-offset-0.5">
             <div style="overflow-x: auto;"> 

                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None" Height="239px" Width="895px" OnRowDataBound="GridView1_RowDataBound" AllowPaging="True" PageSize="2">
                     <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                     <Columns>
                         <asp:BoundField DataField="Nombre_proveedor" HeaderText="Nombre proveedor" SortExpression="Nombre_proveedor" />
                         <asp:BoundField DataField="Valor" HeaderText="Valor Total" SortExpression="Valor" />
                         <asp:BoundField DataField="T_entrega" HeaderText="Entrega" SortExpression="T_entrega" />
                         <asp:TemplateField HeaderText="Elementos" SortExpression="Elementos">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Elementos") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                
                                 <asp:Label ID="LB_elementos" runat="server" Text='<%# Eval("Elementos") %>' Visible="False"></asp:Label>
                                 <br />
                                 <br />
                                 <asp:GridView ID="GV_Elementos" runat="server">
                                 </asp:GridView>
                                
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
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
                 <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ConsultarPedidoProveedor" TypeName="DAOAdmin"></asp:ObjectDataSource>
             </div>
        </div>
    </div>
  
</asp:Content>

