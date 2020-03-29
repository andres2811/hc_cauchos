
<%@ Page Title="" Language="C#" MasterPageFile="~/Views/administrador/admin.master" AutoEventWireup="true" CodeFile="~/Controllers/administrador/insertarEmpleado.aspx.cs" Inherits="Views_administrador_insertarEmpleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1 class="text-aling-center">Agregar Empleados </h1>
    <div class="container">
        <div class="row">
            <div class="col-5">

            </div>
            <div class="col-2">
                <div class="container">
                    <div class="row">
                        <div class="form-group">
                            <br /> <br />                       
                             <asp:TextBox ID="TB_nombres" runat="server" class="form-control" placeholder="nombres"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="Registro" ControlToValidate="TB_nombres" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="TB_apellidos" runat="server" class="form-control" placeholder="apellido"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="Registro" ControlToValidate="TB_apellidos" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="TB_correo" runat="server" class="form-control" placeholder="correo"  TextMode="Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="Registro" ControlToValidate="TB_correo" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="TB_contraseña" runat="server" class="form-control" placeholder="contraseña"></asp:TextBox>     
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="Registro" ControlToValidate="TB_contraseña" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="TB_confirmar_contra" runat="server" class="form-control" placeholder="confirmar contraseña"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="Registro" ControlToValidate="TB_confirmar_contra" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="TB_fecha_nacimiento" runat="server" class="form-control" placeholder="fecha nacimiento" TextMode="Date"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="Registro" ControlToValidate="TB_fecha_nacimiento" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="TB_identificacion" runat="server" class="form-control" placeholder="identificacion"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="Registro" ControlToValidate="TB_identificacion" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="DDL_tipo_empleado" runat="server" class="form-control">
                                <asp:ListItem Value="2">empleado</asp:ListItem>
                                <asp:ListItem Value="3">domiciliario</asp:ListItem>
                            </asp:DropDownList>
                            <br />  
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="la contraseña debe tener entre 8 - 10 caracteres tanto letra, numeros y caracteres especiales" ControlToValidate="TB_contraseña" ValidationExpression="(?=^.{8,10}$)(?=.*\d)(?=.*[a-zA-Z])(?=.*[!@#$%^&*()_+}{':;'?/>.<,])(?!.*\s).*$"></asp:RegularExpressionValidator>
                            <asp:Button ID="BTN_registrar_empleado" runat="server" Text="Registrar" class="btn btn-primary" ValidationGroup="Registro" OnClick="BTN_registrar_empleado_Click"/> 
                        </div>                    
                    </div>                 
                    </div>             
            </div>
               
            <div class="col-5">

            </div>
       </div>
    </div>
</asp:Content>

