<%@ Page Title="" Language="C#" MasterPageFile="~/Views/administrador/admin.master" AutoEventWireup="true" CodeFile="~/Controllers/administrador/cambiosEmpleado.aspx.cs" Inherits="Views_administrador_cambiosEmpleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <h1 class="text-center"><strong>Ver - Editar - Inhabilitar Empleados</strong></h1>
    <br />
    <br />

      <div class="row">
        <div class=" col-lg-12 col-md-offset-0.5">
             <div style="overflow-x: auto;">  
            <asp:GridView ID="GV_empleados" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ODS_mostrarEmpleados" ForeColor="#333333" CssClass="table table-responsive table-striped" GridLines="None" DataKeyNames="User_id" HorizontalAlign="Justify" Width="104%" OnRowDataBound="GridView1_RowDataBound" OnRowUpdating="GV_empleados_RowUpdating">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombres" SortExpression="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellidos" SortExpression="Apellido" />
                    <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
                    <asp:BoundField DataField="Fecha_nacimiento" HeaderText="Fecha nacimiento" SortExpression="Fecha_nacimiento" />
                    <asp:BoundField DataField="Identificacion" HeaderText="Identificacion" SortExpression="Identificacion" />
                    <asp:TemplateField HeaderText="Rol" SortExpression="RolNombre">
                        <EditItemTemplate>
                            <asp:DropDownList ID="DDL_roles" runat="server" DataSourceID="ODS_obtenerRoles" DataTextField="Nombre" DataValueField="Id">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ODS_obtenerRoles" runat="server" SelectMethod="ObtenerRoles" TypeName="DAOAdmin"></asp:ObjectDataSource>
                        </EditItemTemplate>
                       
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("RolNombre") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado" SortExpression="EstadoNombre">
                        <EditItemTemplate>
                            <asp:DropDownList ID="DDL_estados" runat="server" DataSourceID="ODS_obtenerEstados" DataTextField="Nombre" DataValueField="Id">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ODS_obtenerEstados" runat="server" SelectMethod="ObtenerEstados" TypeName="DAOAdmin"></asp:ObjectDataSource>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("EstadoNombre") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" />
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
        <asp:ObjectDataSource ID="ODS_mostrarEmpleados" runat="server" SelectMethod="ObtenerEmpleados" TypeName="DAOAdmin" DataObjectTypeName="EncapUsuario" UpdateMethod="actualizarEmpleado"></asp:ObjectDataSource>
     </div>
</div>
</asp:Content>

