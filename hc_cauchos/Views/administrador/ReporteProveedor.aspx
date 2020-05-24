<%@ Page Title="" Language="C#" MasterPageFile="~/Views/administrador/admin.master" AutoEventWireup="true" CodeFile="~/Controllers/administrador/ReporteProveedor.aspx.cs" Inherits="Views_reportes_ReporteProveedor" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <a href="ReporteProveedor.aspx">ReporteProveedor.aspx</a><CR:CrystalReportViewer ID="CRV_Proveedor" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="1202px" ReportSourceID="CRS_Proveedor" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="1104px" PageZoomFactor="125" ToolPanelView="None" />
    <CR:CrystalReportSource ID="CRS_Proveedor" runat="server">
        <Report FileName="~\Reportes\ReportePedidoProveedor.rpt">
        </Report>
    </CR:CrystalReportSource>
</asp:Content>

