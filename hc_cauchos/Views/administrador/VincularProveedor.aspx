﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/administrador/admin.master" AutoEventWireup="true" CodeFile="~/Controllers/administrador/VincularProveedor.aspx.cs" Inherits="Views_administrador_VincularProveedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script type="text/javascript">
    function disable() {

     document.getElementById("DDL_producto").disable = true;
    
      }
</script>
    
     <br />
    <h1 class="text-center"><strong>Agregar Proveedor</strong></h1>
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                            <br /> <br />     
                <div class="form-group">
                    <asp:DropDownList ID="DDL_proveedores" runat="server" class="form-control" DataSourceID="ODS_proveedor" DataTextField="Nombre_pro" DataValueField="Id" OnSelectedIndexChanged="DDL_proveedores_SelectedIndexChanged"></asp:DropDownList>
                    <asp:ObjectDataSource ID="ODS_proveedor" runat="server" SelectMethod="ColsultarProveedor" TypeName="DAOAdmin"></asp:ObjectDataSource>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" InitialValue= "0"  ControlToValidate="DDL_proveedores" ValidationGroup="a">*</asp:RequiredFieldValidator>
                    <br />
                    Referencia
                    <asp:DropDownList ID="DDL_producto" runat="server" Class="form-control" DataSourceID="ODS_producto" DataTextField="Referencia" DataValueField="Id"></asp:DropDownList>        
                    <asp:ObjectDataSource ID="ODS_producto" runat="server" SelectMethod="ConsultarInventario" TypeName="DAOAdmin"></asp:ObjectDataSource>
                    <br />
                    <br />
                    <asp:TextBox ID="TB_precio" runat="server" class="form-control" placeholder="precio" MaxLength="5"></asp:TextBox>     
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TB_precio" ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Cantidad fuera del rango recuerde entre 1-99999" ControlToValidate="TB_precio" MaximumValue="999999" MinimumValue="1" Type="Integer" ValidationGroup="a"></asp:RangeValidator>
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                    <asp:Button ID="BTN_vincular" runat="server" Text="Vincular" class="btn btn-primary" ValidationGroup="a" OnClick="BTN_vincular_Click" />
                </div>                        
             </div>                                   
       </div>       
</asp:Content>
