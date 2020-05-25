<%@ Page Title="" Language="C#" MasterPageFile="~/Views/administrador/admin.master" AutoEventWireup="true" CodeFile="~/Controllers/administrador/EditarProveedor.aspx.cs" Inherits="Views_administrador_EditarProveedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 91%
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1 class="text-center text-primary"><strong>Editar - Proveedores </strong></h1>
    <br />
  <div class="row">
        <div class=" col-lg-12 col-md-offset-0.5">
             <div style="overflow-x: auto;"> 
                  <asp:GridView ID="Gv_proveedor" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ODS_Provedor" ForeColor="#333333" GridLines="None" Width="100%" DataKeyNames="Id" OnRowUpdating="GridView1_RowUpdating" OnRowEditing="Gv_proveedor_RowEditing" AllowPaging="True" PageSize="5">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="Nombre" SortExpression="Nombre_pro">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TB_Nombre" runat="server" Text='<%# Bind("Nombre_pro") %>' Width="179px" MaxLength="25"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TB_Nombre" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LB_Nombre" runat="server" Text='<%# Bind("Nombre_pro") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contacto" SortExpression="Contacto">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TB_Contacto" runat="server" Text='<%# Bind("Contacto") %>' Width="161px" ControlToValidate="TB_Contacto" MaxLength="10" TextMode="Number"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="TB_Contacto"></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Contacto") %>'></asp:Label>
                                   
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" ReadOnly="True"/>
                            <asp:TemplateField HeaderText="Tiempo Envio (Hrs)" SortExpression="Tiempo_envio" >
                                <EditItemTemplate>
                                    <asp:TextBox ID="TB_Horas" runat="server" Text='<%# Bind("Tiempo_envio") %>' Width="113px" MaxLength="3" TextMode="Number"></asp:TextBox>
                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TB_Horas" ErrorMessage="Rango de hora invalido recuerde entre 1-200 Hrs" MaximumValue="200" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Tiempo_envio") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Nid" HeaderText="Nid" SortExpression="Nid" ReadOnly="True"/>
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
                    <asp:Label ID="LB_aux" runat="server" Text="Label" Visible="False"></asp:Label>
                    <br />
                    <asp:ObjectDataSource ID="ODS_Provedor" runat="server" SelectMethod="ColsultarProveedor2" TypeName="DAOAdmin" DataObjectTypeName="EncapProveedor" UpdateMethod="ActualizarProveedor" DeleteMethod="EliminarProveedor"></asp:ObjectDataSource>
             </div>
        </div>
    </div>

                   
</asp:Content>

