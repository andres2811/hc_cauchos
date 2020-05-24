<%@ Page Title="" Language="C#" MasterPageFile="~/Views/empleado/empleado.master" AutoEventWireup="true" CodeFile="~/Controllers/empleado/FacturaVentanilla.aspx.cs" Inherits="Views_empleado_FacturaVentanilla" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <CR:CrystalReportViewer ID="CRV_FacturaVentanilla" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="1202px" ReportSourceID="CRS_FacturaVentanilla" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="1104px" PageZoomFactor="125" ToolPanelView="None" />
    <CR:CrystalReportSource ID="CRS_FacturaVentanilla" runat="server">
        <Report FileName="~\Reportes\ReporteFacturaVentanilla.rpt">
        </Report>
    </CR:CrystalReportSource>
</asp:Content>

