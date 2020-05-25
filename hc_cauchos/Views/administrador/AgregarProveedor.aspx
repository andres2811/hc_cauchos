<%@ Page Title="" Language="C#" MasterPageFile="~/Views/administrador/admin.master" AutoEventWireup="true" CodeFile="~/Controllers/administrador/AgregarProveedor.aspx.cs" Inherits="Views_administrador_AgregarProveedor" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <br />
    <h1 class="text-center text-primary"><strong>Agregar Proveedor</strong></h1>
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                            <br /> <br />     
                <div class="form-group">
                            <asp:TextBox ID="TB_nombre" runat="server" class="form-control" placeholder="nombre"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="Registro" ControlToValidate="TB_nombre" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            
                            <asp:TextBox ID="TB_contacto" runat="server" class="form-control" placeholder="contacto" TextMode="Number" MaxLength="10" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="Registro" ControlToValidate="TB_contacto" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="# Cel/Tel invalido" ControlToValidate="TB_contacto" MaximumValue="9999999999" MinimumValue="1000000" ValidationGroup="Registro" Type="Double" ForeColor="Red"></asp:RangeValidator>       

                            <asp:TextBox ID="TB_correo" runat="server" class="form-control" placeholder="correo"  TextMode="Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="Registro" ControlToValidate="TB_correo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            
                            <asp:TextBox ID="TB_nid" runat="server" class="form-control" placeholder="nid proveedor" MaxLength="10"></asp:TextBox>     
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="Registro" ControlToValidate="TB_nid" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="NID de empresa invalido" ControlToValidate="TB_nid" MaximumValue="9999999999" MinimumValue="1000000" ValidationGroup="Registro" Type="Double" ForeColor="Red"></asp:RangeValidator>
                            
                            <asp:TextBox ID="TB_Fecha" runat="server" class="form-control" placeholder="tiempo de envio (Horas)" TextMode="Number" MaxLength="3"></asp:TextBox>    
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="Registro" ControlToValidate="TB_nid" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ValidationGroup="Registro"  ControlToValidate="TB_Fecha" ErrorMessage="Rango de hora invalido recuerde entre 1-200 Hrs" MaximumValue="200" MinimumValue="1" Type="Integer" ForeColor="Red"></asp:RangeValidator>
                      
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="BTN_registrar" runat="server" Text="Registrar" class="btn btn-primary" ValidationGroup="Registro" OnClick="BTN_registrar_Click"/>
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

