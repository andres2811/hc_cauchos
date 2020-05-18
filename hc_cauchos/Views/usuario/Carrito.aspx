<%@ Page Title="" Language="C#" MasterPageFile="~/Views/usuario/usuario.master" AutoEventWireup="true" CodeFile="~/Controllers/usuario/Carrito.aspx.cs" Inherits="Views_usuario_Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">
        .auto-style4 {
            width: 190px;
        }
        .auto-style5 {
            width: 210px;
        }
        .auto-style6 {
            width: 52px;
        }
        .auto-style7 {
            width: 54px;
        }
        </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1 class="text-center"><strong>Mi Carrito</strong></h1>
    <div align="center">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/ima/icon.png" align="center" />
    </div>
    <div class="row">
        <div class=" col-lg-12 col-md-offset-0.5">
             <div style="overflow-x: auto;">  
                 <asp:GridView ID="GV_carrito" runat="server" AutoGenerateColumns="False" DataKeyNames="Id_Carrito" DataSourceID="ODS_carrito" OnRowEditing="GV_carrito_RowEditing" OnRowUpdating="GV_carrito_RowUpdating" OnRowUpdated="GV_carrito_RowUpdated" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
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
    <table class="nav-justified">
        <tr>
            <td class="auto-style4">
                <asp:ObjectDataSource ID="ODS_Municipio" runat="server" SelectMethod="ConsultarMunicipio" TypeName="DAOEmpleado">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DDL_Departamento" Name="aux" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
            <td class="auto-style5">
                <br />
                <asp:DropDownList ID="DDL_Departamento" CssClass="form-control" runat="server" AutoPostBack="True" DataSourceID="ODS_Departamento" DataTextField="Nombre" DataValueField="Id" OnSelectedIndexChanged="DDL_Departamento_SelectedIndexChanged" Visible="False">
                </asp:DropDownList>
               
            
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" InitialValue="0" ControlToValidate="DDL_Departamento" ValidationGroup="dire"></asp:RequiredFieldValidator> 
               
            
            </td>
            <td class="auto-style6"> 
               
               
            </td>
            <td class="modal-sm">
                 <asp:Label ID="Lb_municipio" runat="server" Text="Municipio " Visible="False"></asp:Label>
                <asp:DropDownList ID="DDL_Municipio" CssClass="form-control" runat="server" DataSourceID="ODS_Municipio" DataTextField="Nombre" DataValueField="Id" Visible="False">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
           
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:ObjectDataSource ID="ODS_Departamento" runat="server" SelectMethod="ConsultarDepartamento" TypeName="DAOEmpleado"></asp:ObjectDataSource>
            </td>
            <td class="auto-style5">
                &nbsp;</td>
            <td class="auto-style6">
                <asp:TextBox ID="TB_Direccion" runat="server" CssClass="form-control" placeholder="Dirreccion" Visible="False" Width="202px" MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="TB_Direccion" ValidationGroup="dire"></asp:RequiredFieldValidator>
            </td>
            <td class="modal-sm">
               </td>
            
        </tr>
    </table>
    <br />
    <div aling="center">
        <asp:ImageButton ID="BTN_Facturar" runat="server" ImageUrl="~/ima/business-and-finance(1).png" OnClick="BTN_Facturar_Click" ValidationGroup="dire" />
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/ima/compras.png" OnClick="ImageButton1_Click" />
        <br />
            <asp:Label ID="LB_facturar" runat="server" Text="Facturar"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="LB_mas" runat="server" Text="Mas Productos"></asp:Label>
    </div>
            

 
</asp:Content>

