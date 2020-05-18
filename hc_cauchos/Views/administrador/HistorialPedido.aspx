﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/administrador/admin.master" AutoEventWireup="true" CodeFile="~/Controllers/administrador/HistorialPedido.aspx.cs" Inherits="Views_administrador_HistorialPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 389px;
        }
        .auto-style3 {
            width: 180px;
        }
        .auto-style4 {
            width: 110%
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <br />
      <br />
    <h1 class="text-center"><strong>Historial De Pedidos</strong></h1>
      <br />
     <br />
     <table class="auto-style4">
         <tr>
             <td class="auto-style2">&nbsp;</td>
             <td class="auto-style3">
                 <asp:DropDownList  ID="DDL_Estado" runat="server"  AutoPostBack="True" CssClass="form-control" DataSourceID="ODS_Estados" DataTextField="Estado" DataValueField="Id" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                     <asp:ListItem>Seleccionar Estado</asp:ListItem>
                 </asp:DropDownList>
                 <asp:ObjectDataSource ID="ODS_Estados" runat="server" SelectMethod="ConsultarEstadoPedidos" TypeName="DAOUser"></asp:ObjectDataSource>
             </td>
             <td>
                 <asp:Button ID="Btn_todos" runat="server" CssClass="btn btn-default" Text="Todos" OnClick="Btn_todos_Click" />
             </td>
         </tr>
     </table>
     <br />
    <div class="row"> 
     <div class="col-md-2 col-md-offset-0.5">
      
            <asp:GridView ID="GV_Pedidos" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ODS_Pedidos" ForeColor="#333333" GridLines="None" OnRowDataBound="GridView1_RowDataBound" AllowPaging="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="4" Width="988px">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="Id" SortExpression="Id" >
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Id") %>' ></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <table class="nav-justified">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Id") %>' Width="35"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Fecha_pedido" HeaderText="Fecha (Creacion)" SortExpression="Fecha_pedido" />
                    <asp:TemplateField HeaderText="Total" SortExpression="Total">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Total") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Total") %>' Width="60"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Usuario" HeaderText="Usuario" SortExpression="Usuario" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                    <asp:BoundField DataField="Empleado" HeaderText="Empleado" SortExpression="Empleado" />
                    <asp:BoundField DataField="Domiciliaro" HeaderText="Domiciliaro" SortExpression="Domiciliaro" />
                    <asp:TemplateField HeaderText="Elementos" SortExpression="Id">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Id") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id") %>' Visible="False"></asp:Label>
                            <br />
                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="ODS_Elementos" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                                <Columns>
                                    <asp:BoundField DataField="Pedido_id" HeaderText="Pedido_id" SortExpression="Pedido_id" />
                                    <asp:BoundField DataField="Producto_id" HeaderText="Producto_id" SortExpression="Producto_id" />
                                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                                    <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" />
                                    <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" />
                                </Columns>
                                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                <SortedDescendingHeaderStyle BackColor="#242121" />
                            </asp:GridView>
                            <asp:ObjectDataSource ID="ODS_Elementos" runat="server" SelectMethod="ObtenerProductos" TypeName="DAOUser">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="Label1" Name="id" PropertyName="Text" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </ItemTemplate>
                    </asp:TemplateField>
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
          </div>
        </div>
            <asp:ObjectDataSource ID="ODS_Pedidos" runat="server" SelectMethod="ConsultarPedidos" TypeName="DAOAdmin"></asp:ObjectDataSource>
     <br />
            <asp:ObjectDataSource ID="ODS_PedidosEstado" runat="server" SelectMethod="ConsultarPedidosEstado" TypeName="DAOAdmin">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DDL_Estado" Name="est" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
     </asp:ObjectDataSource>
</asp:Content>

