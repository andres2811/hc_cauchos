﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/empleado/empleado.master" AutoEventWireup="true" CodeFile="~/Controllers/empleado/configurarEmple.aspx.cs" Inherits="Views_empleado_configurarEmple" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1 class="text-center text-primary"><strong>Mi cuenta</strong></h1>
    <div align="center">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/ima/configurar.png" align="center" />
    </div>
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                            <br /> <br />     
                <div class="form-group">
                    Nombre:
                    <asp:Label ID="LB_nombre" runat="server" class="form-control" ></asp:Label>
                    Apellido:
                    <asp:Label ID="LB_apellido" runat="server" Text="Label" class="form-control"></asp:Label>
                    Correo:
                    <asp:Label ID="LB_correo" runat="server" Text="Label" class="form-control"></asp:Label>
                    <asp:TextBox ID="TB_editCorreo" runat="server" class="form-control" placeholder="Ingrese el nuevo correo"  TextMode="Email" ValidationGroup="grupocorreo"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TB_editCorreo" ErrorMessage="*" ValidationGroup="grupocorreo"></asp:RequiredFieldValidator>
                    <asp:Button ID="BTN_editarCorreo" runat="server" Text="Cambiar" class="btn btn-primary" ValidationGroup="grupocorreo" OnClick="BTN_editarCorreo_Click" />
                    <asp:Button ID="BTN_cancelar" runat="server" Text="Cancelar" class="btn btn-primary" OnClick="BTN_cancelar_Click"/>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Inventario/engranaje.png" OnClick="ImageButton1_Click" Width="16px" />
                    <br />
                    Contraseña:
                    <asp:Label ID="LB_contraseña" runat="server" Text="Label" class="form-control"></asp:Label>
                    <asp:TextBox ID="TB_editarPass" runat="server" class="form-control" ValidationGroup="grupopass" placeholder="Ingrese la nueva contraseña"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="TB_editarPass" ValidationGroup="grupopass"></asp:RequiredFieldValidator>
                    <asp:Button ID="BTN_editarPass" runat="server" Text="Cambiar" class="btn btn-primary" ValidationGroup="grupopass" OnClick="BTN_editarPass_Click"/>
                    <asp:Button ID="BTN_cancelar2" runat="server" Text="Cancelar" Class="btn btn-primary" OnClick="BTN_cancelar2_Click" />
                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Inventario/engranaje.png" OnClick="ImageButton2_Click"/>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Se requiere entre 8 - 16 caracteres tanto letras,numeros,mayusculas y minusculas" ControlToValidate="TB_editarPass" ValidationExpression="^(?=\w*\d)(?=\w*[A-Z])(?=\w*[a-z])\S{8,16}$" ValidationGroup="grupopass"></asp:RegularExpressionValidator>
                </div>   
                <div>                 
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

            </div>
        </div>       
</asp:Content>

