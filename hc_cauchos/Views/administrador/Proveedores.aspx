<%@ Page Title="" Language="C#" MasterPageFile="~/Views/administrador/admin.master" AutoEventWireup="true" CodeFile="~/Controllers/administrador/Proveedores.aspx.cs" Inherits="Views_administrador_Proveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
   
    <style type="text/css">
        .auto-style1 {
            display: block;
            line-height: 1.42857143;
            color: #555;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
            box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
            -webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            font-size: 14px;
            border: 1px solid #ccc;
            padding: 6px 12px;
            background-color: #fff;
            background-image: none;
            margin-left: 0;
        }
    </style>
   
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <script type="text/javascript" >
        function multiplicar()
        {
           document.getElementById('<%= TB_Total.ClientID %>').value = 
               (document.getElementById('<%= TB_Cantidad.ClientID %>').value)
               *(document.getElementById('<%= TB_resultado.ClientID %>').value);
        }
    </script>
        <br />
         <h1 class="text-center"><strong>Pedido Proveedor</strong></h1>
        <br />

    <div class="row">
    
        <div class="col-md-8 col-md-offset-4"> 
   
            <br />
            &nbsp;&nbsp; &nbsp;<asp:DropDownList ID="DDL_Proveedor" runat="server" CssClass="auto-style1" DataSourceID="ODS_Proveedor" DataTextField="Nombre_pro" DataValueField="Id" Height="48px" Width="257px">
            </asp:DropDownList>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" InitialValue= "0" ControlToValidate="DDL_Proveedor" ErrorMessage="*" style="position: relative"></asp:RequiredFieldValidator>

            <asp:ObjectDataSource ID="ODS_Proveedor" runat="server" SelectMethod="ColsultarProveedor" TypeName="DAOAdmin"></asp:ObjectDataSource>
            <br />

        <br />
   
    Referencia&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;     <asp:TextBox ID="TB_Refencia" Class="form-control" Width="197px" placeholder="Referencia" runat="server" Height="27px" ></asp:TextBox>
        <br />
        <br />
            
            Cantidad&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <asp:TextBox ID="TB_Cantidad"   runat="server" class="form-control-static" Width="197px" Height="27px" TextMode="Number" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TB_Cantidad" ErrorMessage="*"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TB_Cantidad" ErrorMessage="Valor Invalido" MaximumValue="1000000" MinimumValue="1" Type="Integer"></asp:RangeValidator>
           <br />
            
           
            <br />
   Precio Unitario&nbsp; <asp:TextBox ID="TB_resultado" runat="server" class="form-control" Width="197px"></asp:TextBox>
            <br />
             <br />
            Precio Total :&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TB_Total" runat="server" Class="form-control" Width="197px"></asp:TextBox>
            <br />
            
            <br />
        <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Enviar Pedido" CssClass="btn btn-primary"/>
            </div>
    </div>
    
</asp:Content>

