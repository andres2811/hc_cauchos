<%@ Page Title="" Language="C#" MasterPageFile="~/Views/administrador/admin.master" AutoEventWireup="true" CodeFile="~/Controllers/reportes/ReporteInventario.aspx.cs" Inherits="Views_reportes_ReporteInventario" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <CR:CrystalReportViewer ID="CRV_Inventario" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="1202px" ReportSourceID="CRS_Inventario" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="1104px" OnInit="CRV_Inventario_Init" PageZoomFactor="125" ToolPanelView="None" />
<CR:CrystalReportSource ID="CRS_Inventario" runat="server">
    <Report FileName="Z:\hc_cauchos\hc_cauchos\Reportes\ReporteInventario.rpt">
    </Report>
</CR:CrystalReportSource>
</asp:Content>

