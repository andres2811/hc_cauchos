<%@ Page Title="" Language="C#" MasterPageFile="~/Views/administrador/admin.master" AutoEventWireup="true" CodeFile="~/Controllers/administrador/cambiosEmpleado.aspx.cs" Inherits="Views_administrador_cambiosEmpleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="container">
        <div class="row">
            <div class="col-6">

            </div>
            <div class="col-2">
                   <div class="text-center">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ODS_mostrarEmpleados" ForeColor="#333333" GridLines="None" Width="970px">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombres" SortExpression="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellidos" SortExpression="Apellido" />
                    <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
                    <asp:BoundField DataField="Fecha_nacimiento" HeaderText="Fecha nacimiento" SortExpression="Fecha_nacimiento" />
                    <asp:BoundField DataField="Identificacion" HeaderText="Identificacion" SortExpression="Identificacion" />
                    <asp:BoundField DataField="RolNombre" HeaderText="Rol" SortExpression="RolNombre" />
                    <asp:BoundField DataField="EstadoNombre" HeaderText="Estado" SortExpression="EstadoNombre" />
                    <asp:CommandField ShowDeleteButton="True" />
                    <asp:CommandField CancelText="" DeleteText="" ShowEditButton="True" />
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
        <asp:ObjectDataSource ID="ODS_mostrarEmpleados" runat="server" SelectMethod="ObtenerEmpleados" TypeName="DAOAdmin"></asp:ObjectDataSource>
            </div>
            <div class="col-4">

            </div>
        </div>
    </div>
     
    
</asp:Content>

