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

         
                <br />
                <br />
                <asp:TextBox ID="TB_Buscar" runat="server" placeholder="Referencia a buscar" CssClass="form-control-static"></asp:TextBox>
                &nbsp;<asp:Button ID="BT_Buscar" runat="server" CssClass="form-control-static" Text="Buscar" OnClick="BT_Buscar_Click" />
                <br />
                <br />
             <div style="overflow-x: auto;">  
            
            <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False" CellPadding="4"  OnRowDataBound="GridView1_RowDataBound" AllowPaging="True" CssClass="auto-style1" DataKeyNames="Id" ForeColor="#333333" GridLines="None" Width="1322px"  >
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                
            </asp:GridView>
               
                 <asp:ObjectDataSource ID="ODS_Inventario" runat="server" DataObjectTypeName="EncapInventario" SelectMethod="ConsultarInventario" TypeName="DAOAdmin" UpdateMethod="ActualizarInventario"></asp:ObjectDataSource>
            </div>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ConsultarInventario" TypeName="DAOAdmin" DataObjectTypeName="EncapInventario" UpdateMethod="ActualizarInventario"></asp:ObjectDataSource>
            
               <asp:ObjectDataSource ID="ODS_Buscar" runat="server" SelectMethod="BuscarReferencia" TypeName="DAOAdmin">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TB_Buscar" Name="a" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            
             <br />
             <br />
            
            
                
            
           </div>
        </div>
    
</asp:Content>

