<%@ Page Title="" Language="C#" MasterPageFile="~/Views/administrador/admin.master" AutoEventWireup="true" CodeFile="~/Controllers/administrador/index_admin.aspx.cs" Inherits="Views_administrador_index_admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   <style type="text/css">
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Bienvenido <br /><small>configuracion</small></h1>
<asp:ObjectDataSource ID="ODS_obtenerUsuario" runat="server" SelectMethod="ObtenerUsuario" TypeName="DAOAdmin"></asp:ObjectDataSource>
</asp:Content>

