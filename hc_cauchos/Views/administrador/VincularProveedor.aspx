<%@ Page Title="" Language="C#" MasterPageFile="~/Views/administrador/admin.master" AutoEventWireup="true" CodeFile="~/Controllers/administrador/VincularProveedor.aspx.cs" Inherits="Views_administrador_VincularProveedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script type="text/javascript">
    function disable() {

     document.getElementById("DDL_producto").disable = true;
    
      }
</script>
    
     <br />
    <h1 class="text-center text-primary"><strong>Agregar Proveedor</strong></h1>
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                            <br /> <br />     
                <div class="form-group">
                    <asp:DropDownList ID="DDL_proveedores" runat="server" class="form-control" DataSourceID="ODS_proveedor" DataTextField="Nombre_pro" DataValueField="Id" OnSelectedIndexChanged="DDL_proveedores_SelectedIndexChanged"></asp:DropDownList>
                    <asp:ObjectDataSource ID="ODS_proveedor" runat="server" SelectMethod="ColsultarProveedor" TypeName="DAOAdmin"></asp:ObjectDataSource>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" InitialValue= "0"  ControlToValidate="DDL_proveedores" ValidationGroup="a" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <br />
                    Referencia
                    <asp:DropDownList ID="DDL_producto" runat="server" Class="form-control" DataSourceID="ODS_producto" DataTextField="Referencia" DataValueField="Id"></asp:DropDownList>        
                    <asp:ObjectDataSource ID="ODS_producto" runat="server" SelectMethod="ConsultarInventario" TypeName="DAOAdmin"></asp:ObjectDataSource>
                    <br />
                    <asp:TextBox ID="TB_precio" runat="server" class="form-control" placeholder="precio" MaxLength="5" ValidationGroup="a"></asp:TextBox>     
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TB_precio" ErrorMessage="*" ValidationGroup="a" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                    
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Cantidad fuera del rango recuerde entre 100-999999" ControlToValidate="TB_precio" MaximumValue="999999" MinimumValue="100" Type="Double" ValidationGroup="a" ForeColor="Red"></asp:RangeValidator>
                    <br />
                    <asp:Button ID="BTN_vincular" runat="server" Text="Vincular" class="btn btn-primary center-block" ValidationGroup="a" OnClick="BTN_vincular_Click" />
                </div>                        
             </div>                                   
       </div>       
</asp:Content>

