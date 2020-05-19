﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/usuario/usuario.master" AutoEventWireup="true" CodeFile="~/Controllers/usuario/Carrito.aspx.cs" Inherits="Views_usuario_Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">
        .auto-style4 {
            width: 190px;
        }
        .auto-style5 {
            width: 210px;
        }
        .auto-style6 {
            width: 10px;
        }
        .auto-style7 {
            display: block;
/*height:34px;*/padding: 6px 12px;
/*font-size:14px*/;line-height: 1.42857143;
            color: #555;
            background-color: #fff;
            background-image: none;
            border: 1px solid #ccc;
            border-radius: 7px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
        }
        </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1 class="text-center text-primary"><strong>Mi Carrito</strong></h1>
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
                                 <asp:RangeValidator ID="RV_cantidad" runat="server" ErrorMessage="valor invalido" ControlToValidate="TB_Cantidad" MaximumValue='<%# Bind("Cant_Actual") %>' MinimumValue="1" Type="Integer"></asp:RangeValidator>
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
                     <EmptyDataTemplate>
                         <h1 class="text-center text-danger">no hay datos para mostrar</h1>
                     </EmptyDataTemplate>
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
                </asp:ObjectDataSource>
            </td>
            <td class="auto-style5">
                <br />
             
                <asp:DropDownList ID="DDL_Lugar" CssClass="auto-style7" runat="server" AutoPostBack="True" DataSourceID="ODS_Municipio" DataTextField="Nombre" DataValueField="Id" OnSelectedIndexChanged="DDL_Departamento_SelectedIndexChanged" Width="245px">
                </asp:DropDownList>
               
            
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" InitialValue="0" ControlToValidate="DDL_Lugar" ValidationGroup="dire"></asp:RequiredFieldValidator> 
               
            
            </td>
            <td class="auto-style6"> 
               
               
                &nbsp;</td>
            <td class="modal-sm">
                 <br />
                <asp:TextBox ID="TB_Direccion" runat="server" CssClass="form-control" placeholder="Dirreccion" Visible="False" Width="202px" MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="TB_Direccion" ValidationGroup="dire"></asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
           
        </tr>
        <tr>
            <td class="auto-style4">
                &nbsp;</td>
            <td class="auto-style5">
                &nbsp;</td>
            <td class="auto-style6">
                &nbsp;</td>
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

