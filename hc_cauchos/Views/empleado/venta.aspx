<%@ Page Title="" Language="C#" MasterPageFile="~/Views/empleado/empleado.master" AutoEventWireup="true" CodeFile="~/Controllers/empleado/venta.aspx.cs" Inherits="Views_empleado_venta" %>

<%@ Register Src="~/Views/empleado/SectionLevelTutorialListing.ascx" TagPrefix="uc1" TagName="SectionLevelTutorialListing" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <h1 class="text-center text-primary"><strong>VENTA</strong></h1>

    <asp:TextBox ID="TB_NomCliente" runat="server" CssClass="form-control-static" placeholder="Cedula Cliente A Buscar"></asp:TextBox>
    <asp:Button ID="BTN_BuscarClien" runat="server" Text="Buscar" class="btn btn-primary" OnClick="BTN_BuscarClien_Click"/>
    <asp:Button ID="BTN_buscarTodos" runat="server" Text="Todos" CssClass="btn btn-primary" OnClick="BTN_buscarTodos_Click"/>
    <asp:Button ID="BTN_RegistrarCliente" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClick="BTN_RegistrarCliente_Click"/>
    <br />
    <br />


    <div class="row">
        <div class=" col-lg-12 col-md-offset-0.5">
             <div style="overflow-x: auto;">  
                <asp:GridView ID="GV_Clientes" class="table table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="User_id" DataSourceID="ODS_Clientes" Width="100%" AllowPaging="True" PageSize="5" ForeColor="#333333" CellPadding="4" GridLines="None" OnRowUpdated="GV_Clientes_RowUpdated">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                   <Columns>
                        <asp:BoundField DataField="User_id" HeaderText="Identificador" SortExpression="User_id" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                        <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
                        <asp:BoundField DataField="Identificacion" HeaderText="Identificacion" SortExpression="Identificacion" />
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
    </div>            
    <asp:ObjectDataSource ID="ODS_Clientes" runat="server" SelectMethod="ObtenerClientes" TypeName="DAOEmpleado"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODS_ClientesCedu" runat="server" SelectMethod="ObtenerClientesCedula" TypeName="DAOEmpleado">
        <SelectParameters>
            <asp:ControlParameter ControlID="TB_NomCliente" Name="cedula" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <div class="text-center center-block" style=" width:50%;">
        <asp:Panel runat="server" ID="PanelMensaje" Visible="false" CssClass="alert alert-danger shadow" role="alert">
	        <strong>
	        <asp:Label ID="LblMensaje" runat="server" />
	        </strong>
	        <asp:LinkButton Text="<span aria-hidden='true'>&times;</span>" runat="server" CssClass="close" ID="B_cerrar_mensaje1" OnClick="B_cerrar_mensaje1_Click" />
        </asp:Panel>

        <asp:Panel runat="server" ID="PanelMensaje1" Visible="false" CssClass="alert alert-warning shadow" role="alert">
	        <strong>
	        <asp:Label ID="LblMensaje1" runat="server" />
	        </strong>
	        <asp:LinkButton Text="<span aria-hidden='true'>&times;</span>" runat="server" CssClass="close" ID="LinkButton1" OnClick="LinkButton1_Click" />
        </asp:Panel>

        <asp:Panel runat="server" ID="PanelMensaje2" Visible="false" CssClass="alert alert-success shadow" role="alert">
	        <strong>
	        <asp:Label ID="LblMensaje2" runat="server" />
	        </strong>
	        <asp:LinkButton Text="<span aria-hidden='true'>&times;</span>" runat="server" CssClass="close" ID="LinkButton2" OnClick="LinkButton2_Click" />
        </asp:Panel>
    </div>
    <br />
    <hr/>
    <h1 class="text-center"><strong>PRODUCTOS FACTURADOS</strong></h1>
    <asp:TextBox ID="TB_Iduser" runat="server" placeholder="Agrege el identificador del usuario" CssClass="form-control-static"></asp:TextBox>
    <br />
     <div class="row">
        <div class=" col-lg-12 col-md-offset-0.5">
             <div style="overflow-x: auto;">  
                 <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" class="table table-hover" Width="100%" AutoGenerateColumns="False" DataKeyNames="Id_Carrito" DataSourceID="ODS_Ventas">
                     <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                     <Columns>
                         <asp:BoundField DataField="Nom_producto" HeaderText="Producto" SortExpression="Nom_producto"  ReadOnly="true" />
                         <asp:BoundField DataField="Cant_Actual" HeaderText="Stock" SortExpression="Cant_Actual"  ReadOnly="true" />
                         <asp:TemplateField HeaderText="Cantidad Pedida" SortExpression="Cantidad">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox1" runat="server" TextMode="Number" Text='<%# Bind("Cantidad") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label1" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio"   ReadOnly="true"/>
                         <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total"   ReadOnly="true"/>
                         <asp:CommandField HeaderText="Editar" ShowEditButton="True" />
                         <asp:CommandField HeaderText="Eliminar" ShowDeleteButton="True" />
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
                 <asp:ObjectDataSource ID="ODS_Ventas" runat="server" SelectMethod="ObtenerCarritoxUsuario" TypeName="DAOUser" DataObjectTypeName="EncapCarrito" DeleteMethod="EliminarItemCarrito" UpdateMethod="ActualizarCarritoFactura">
                     <SelectParameters>
                         <asp:SessionParameter Name="usu" SessionField="userid" Type="Int32" />
                     </SelectParameters>
                 </asp:ObjectDataSource>
             </div>
        </div>
    </div>  
    
        <asp:ImageButton ID="BTN_Facturar" runat="server" ImageUrl="~/ima/business-and-finance(1).png" OnClick="BTN_Facturar_Click" />
        
        <br />
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="LB_facturar" runat="server" Text="Facturar"></asp:Label>


    <uc1:SectionLevelTutorialListing runat="server" ID="SectionLevelTutorialListing" />


</asp:Content>

