<%@ Page Title="" Language="C#" MasterPageFile="~/Views/administrador/admin.master" AutoEventWireup="true" CodeFile="~/Controllers/administrador/agregar_empleado.aspx.cs" Inherits="Views_administrador_agregar_empleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container"> 
        <div class="row">
            <div class="col-2">

            </div>
            <div class="col-8">
                 <asp:TextBox ID="TB_nombres" runat="server" class="form-control" placeholder="nombres"></asp:TextBox>
                 <asp:TextBox ID="TB_apellidos" runat="server" class="form-control" placeholder="apellido"></asp:TextBox>
                 <asp:TextBox ID="TB_correo" runat="server" class="form-control" placeholder="correo" ></asp:TextBox>
                 <asp:TextBox ID="TB_contraseña" runat="server" class="form-control" placeholder="contraseña"></asp:TextBox> 
                 <asp:TextBox ID="TB_confirmar_contra" runat="server" class="form-control" placeholder="confirmar contraseña"></asp:TextBox>
                 <asp:TextBox ID="TB_fecha_nacimiento" runat="server" class="form-control" placeholder="fecha nacimiento"></asp:TextBox>
                 <asp:TextBox ID="TB_identificacion" runat="server" class="form-control" placeholder="identificacion"></asp:TextBox>
                 <asp:Button ID="BTN_registrar" runat="server" Text="Registrar" class="fadeIn fourth"/>
            </div>
            <div class="col-2">

            </div>
        </div>
    </div>
</asp:Content>

