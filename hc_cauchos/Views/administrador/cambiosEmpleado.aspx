<%@ Page Title="" Language="C#" MasterPageFile="~/Views/administrador/admin.master" AutoEventWireup="true" CodeFile="~/Controllers/administrador/cambiosEmpleado.aspx.cs" Inherits="Views_administrador_cambiosEmpleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <h1 class="text-center"><strong>Ver - Editar - Inhabilitar Empleados</strong></h1>
    <br />
    <asp:TextBox ID="TB_Buscar" runat="server" CssClass="form-control-static" placeholder="Nombre Empleado A Buscar"></asp:TextBox>
    <asp:Button ID="BTN_buscarNombre" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="BTN_buscarNombre_Click" />
    <asp:Button ID="BTN_buscarTodos" runat="server" Text="Todos" CssClass="btn btn-primary" OnClick="BTN_buscarTodos_Click"/>
    <br />

      <div class="row">
        <div class=" col-lg-12 col-md-offset-0.5">
             <div style="overflow-x: auto;">  
            <asp:GridView ID="GV_empleados" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ODS_mostrarEmpleados" ForeColor="#333333" CssClass="table table-responsive table-striped" GridLines="None" DataKeyNames="User_id" HorizontalAlign="Justify" Width="104%" OnRowDataBound="GridView1_RowDataBound" OnRowUpdating="GV_empleados_RowUpdating" AllowPaging="True" PageSize="5">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="Nombres" SortExpression="Nombre">
                        <EditItemTemplate>
                            <asp:TextBox ID="TB_Nombre" runat="server" Text='<%# Bind("Nombre") %>' ClientIDMode="Predictable"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="text-danger" ErrorMessage="*" ControlToValidate="TB_Nombre"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Apellidos" SortExpression="Apellido">
                        <EditItemTemplate>
                            <asp:TextBox ID="TB_Apellido" runat="server" Text='<%# Bind("Apellido") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="text-danger" ErrorMessage="*" ControlToValidate="TB_Apellido" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Apellido") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" ReadOnly="true"/>


                    <asp:TemplateField HeaderText="Fecha nacimiento" SortExpression="Fecha_nacimiento">
                        <EditItemTemplate>
                            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" SelectedDate='<%# Bind("Fecha_nacimiento") %>' Width="200px">
                                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                <NextPrevStyle VerticalAlign="Bottom" />
                                <OtherMonthDayStyle ForeColor="#808080" />
                                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                <SelectorStyle BackColor="#CCCCCC" />
                                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                <WeekendDayStyle BackColor="#FFFFCC" />
                            </asp:Calendar>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Fecha_nacimiento") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:BoundField DataField="Identificacion" HeaderText="Identificacion" SortExpression="Identificacion" ReadOnly="true" />


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
        <asp:ObjectDataSource ID="ODS_mostrarEmpleados" runat="server" SelectMethod="ObtenerEmpleados" TypeName="DAOAdmin" DataObjectTypeName="EncapUsuario" UpdateMethod="ActualizarUsuario"></asp:ObjectDataSource>
             <asp:ObjectDataSource ID="ODS_mostrarEmpleNombre" runat="server" SelectMethod="ObtenerEmpleadosNombre" TypeName="DAOAdmin" DataObjectTypeName="EncapUsuario" UpdateMethod="ActualizarUsuario">
                 <SelectParameters>
                     <asp:ControlParameter ControlID="TB_Buscar" Name="nombre" PropertyName="Text" Type="String" />
                 </SelectParameters>
             </asp:ObjectDataSource>
     </div>
</div>
</asp:Content>

