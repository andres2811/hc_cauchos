 <%@ Page Title="" Language="C#" MasterPageFile="~/Views/administrador/admin.master" AutoEventWireup="true" CodeFile="~/Controllers/administrador/ConsultarInventario.aspx.cs" Inherits="Views_administrador_ConsultarInventario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            margin-right: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="row">
        <div class=" col-lg-12 col-md-offset-0.5">
             <div style="overflow-x: auto;">  
            
            <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="ODS_Inventario" OnRowDataBound="GridView1_RowDataBound" AllowPaging="True" CssClass="auto-style1" DataKeyNames="Id"  >
                <Columns>
                    <asp:BoundField DataField="Titulo" HeaderText="Titulo" SortExpression="Titulo" />
                     <asp:TemplateField HeaderText="Imagen">

                        <ItemTemplate>
                          <asp:Image ID="IdInventario" runat="server" CssClass="img-responsive" Width="100" ImageUrl=""/>
                    
                        </ItemTemplate>


                      </asp:TemplateField>
                    <asp:BoundField DataField="Referencia" HeaderText="Referencia" SortExpression="Referencia" />
                   
                    <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" />
                    <asp:BoundField DataField="Ca_actual" HeaderText="Ca_actual" SortExpression="Ca_actual" />
                    <asp:BoundField DataField="Ca_minima" HeaderText="Ca_minima" SortExpression="Ca_minima" />
                    <asp:TemplateField HeaderText="Nombre_marca" SortExpression="Nombre_marca">
                        <EditItemTemplate>
                            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ODS_Marca" DataTextField="Marca" DataValueField="Id" SelectedValue='<%# Bind("Id_marca") %>'>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ODS_Marca" runat="server" SelectMethod="ColsultarMarca" TypeName="DAOAdmin"></asp:ObjectDataSource>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Nombre_marca") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre_categoria" SortExpression="Nombre_categoria">
                        <EditItemTemplate>
                            <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="ODS_Categoria" DataTextField="Categoria" DataValueField="Id" SelectedValue='<%# Bind("Id_categoria") %>'>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ODS_Categoria" runat="server" SelectMethod="ColsultarCategoria" TypeName="DAOAdmin"></asp:ObjectDataSource>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Nombre_categoria") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado" SortExpression="Estado">
                        <EditItemTemplate>
                            <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="ODS_Estado" DataTextField="Estado_item" DataValueField="Id" SelectedValue='<%# Bind("Id_estado") %>'>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ODS_Estado" runat="server" SelectMethod="ColsultarEstado" TypeName="DAOAdmin"></asp:ObjectDataSource>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Estado") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField HeaderText="Editar" ShowEditButton="True" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
                
            </asp:GridView>
               
                 <asp:ObjectDataSource ID="ODS_Inventario" runat="server" DataObjectTypeName="EncapInventario" SelectMethod="ConsultarInventario" TypeName="DAOAdmin" UpdateMethod="ActualizarInventario"></asp:ObjectDataSource>
            </div>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ConsultarInventario" TypeName="DAOAdmin" DataObjectTypeName="EncapInventario" UpdateMethod="ActualizarInventario"></asp:ObjectDataSource>
            
           </div>
        </div>
    
</asp:Content>

