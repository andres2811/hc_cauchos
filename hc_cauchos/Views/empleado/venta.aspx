<%@ Page Title="" Language="C#" MasterPageFile="~/Views/empleado/empleado.master" AutoEventWireup="true" CodeFile="~/Controllers/empleado/venta.aspx.cs" Inherits="Views_empleado_venta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <h1 class="text-center"><strong>VENTA</strong></h1>

    <asp:TextBox ID="TB_NomCliente" runat="server" CssClass="form-control-static" placeholder="Cedula Cliente A Buscar"></asp:TextBox>
    <asp:Button ID="BTN_BuscarClien" runat="server" Text="Buscar" class="btn btn-primary" OnClick="BTN_BuscarClien_Click"/>
    <asp:Button ID="BTN_buscarTodos" runat="server" Text="Todos" CssClass="btn btn-primary" OnClick="BTN_buscarTodos_Click"/>
    <asp:Button ID="BTN_RegistrarCliente" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClick="BTN_RegistrarCliente_Click"/>
    <br />
    <br />


    <div class="row">
        <div class=" col-lg-12 col-md-offset-0.5">
             <div style="overflow-x: auto;">  
                <asp:GridView ID="GV_Clientes" class="table table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="User_id" DataSourceID="ODS_Clientes" Width="100%" AllowPaging="True" PageSize="5" ForeColor="#333333" CellPadding="4" GridLines="None">
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

    <h1 class="text-center"><strong>PRODUCTOS REGISTRADOS</strong></h1>
    <asp:TextBox ID="TB_Iduser" runat="server" placeholder="Agrege el ID del usuario" CssClass="form-control-static"></asp:TextBox>
     <div class="row">
        <div class=" col-lg-12 col-md-offset-0.5">
             <div style="overflow-x: auto;">  
                 <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" class="table table-hover" Width="100%">
                     <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
    
    <asp:Button ID="BTN_ConfirmarVenta" runat="server" Text="Vender" Class="btn btn-primary" />

&nbsp;&nbsp;&nbsp; 

</asp:Content>

