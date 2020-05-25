<%@ Page Title="" Language="C#" MasterPageFile="~/Views/empleado/empleado.master" AutoEventWireup="true" CodeFile="~/Controllers/empleado/registrarCliente.aspx.cs" Inherits="Views_empleado_registrarCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <h1 class="text-center"><strong>Agregar Cliente</strong></h1>
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                            <br /> <br />     
                <div class="form-group">
                            <asp:TextBox ID="TB_nombres" runat="server" class="form-control rounded-pill" placeholder="nombres" MaxLength="23"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="Registro" ControlToValidate="TB_nombres" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Solo se permiten letras y minimo 3" ControlToValidate="TB_nombres" ValidationExpression="^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$"  ValidationGroup="Registro" Font-Underline="True" ForeColor="Red"></asp:RegularExpressionValidator>
                            
                            <asp:TextBox ID="TB_apellidos" runat="server" class="form-control rounded-pill" placeholder="apellido" MaxLength="30"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="Registro" ControlToValidate="TB_apellidos" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Solo se permiten letras y minimo 3" ControlToValidate="TB_apellidos" ValidationExpression="^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$"  ValidationGroup="Registro" Font-Underline="True" ForeColor="Red"></asp:RegularExpressionValidator>
        

                            <asp:TextBox ID="TB_correo" runat="server" class="form-control rounded-pill" placeholder="correo"  TextMode="Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="Registro" ControlToValidate="TB_correo" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <br />

                            <asp:TextBox ID="TB_fecha_nacimiento" runat="server" class="form-control rounded-pill" placeholder="fecha nacimiento" TextMode="Date"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="Registro" ControlToValidate="TB_fecha_nacimiento" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                            

                            <asp:TextBox ID="TB_identificacion" runat="server" class="form-control rounded-pill" placeholder="identificacion"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="Registro" ForeColor="Red" ControlToValidate="TB_identificacion" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Cedula invalida" ControlToValidate="TB_identificacion" ForeColor="Red" MaximumValue="1999999999" MinimumValue="10000000" Type="Double"></asp:RangeValidator>
                            <br />  
                            <asp:Button ID="BTN_registrar_cliente" runat="server" Text="Registrar" class="btn btn-primary" ValidationGroup="Registro" OnClick="BTN_registrar_cliente_Click" />
                            <asp:Button ID="BTN_Regresar" runat="server" Text="Facturacion" class="btn btn-primary" OnClick="BTN_Regresar_Click" />
                </div>                        
             </div>                                   
       </div>       
</asp:Content>

