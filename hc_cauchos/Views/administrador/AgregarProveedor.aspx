<%@ Page Title="" Language="C#" MasterPageFile="~/Views/administrador/admin.master" AutoEventWireup="true" CodeFile="~/Controllers/administrador/AgregarProveedor.aspx.cs" Inherits="Views_administrador_AgregarProveedor" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <br />
    <h1 class="text-center"><strong>Agregar Proveedor</strong></h1>
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                            <br /> <br />     
                <div class="form-group">
                     <asp:TextBox ID="TB_nombre" runat="server" class="form-control" placeholder="nombre"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="Registro" ControlToValidate="TB_nombre" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="TB_contacto" runat="server" class="form-control" placeholder="contacto" TextMode="Number" MaxLength="10" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="Registro" ControlToValidate="TB_contacto" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="TB_correo" runat="server" class="form-control" placeholder="correo"  TextMode="Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="Registro" ControlToValidate="TB_correo" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="TB_nid" runat="server" class="form-control" placeholder="nid proveedor" MaxLength="10"></asp:TextBox>     
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="Registro" ControlToValidate="TB_nid" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="TB_Fecha" runat="server" class="form-control" placeholder="tiempo de envio (Horas)" TextMode="Number" MaxLength="3"></asp:TextBox>    
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="Registro" ControlToValidate="TB_nid" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <br />
                     <asp:RangeValidator ID="RangeValidator1" runat="server" ValidationGroup="Registro"  ControlToValidate="TB_Fecha" ErrorMessage="Rango de hora invalido recuerde entre 1-200 Hrs" MaximumValue="200" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                            <br />
                            
                           
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="BTN_registrar" runat="server" Text="Registrar" class="btn btn-primary" ValidationGroup="Registro" OnClick="BTN_registrar_Click"/>
                </div>                        
             </div>                                   
       </div>       
</asp:Content>

