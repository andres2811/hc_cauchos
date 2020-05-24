<%@ Page Title="" Language="C#" MasterPageFile="~/Views/administrador/admin.master" AutoEventWireup="true" CodeFile="~/Controllers/administrador/ReporteMesAMes.aspx.cs" Inherits="Views_reportes_ReporteMesAMes" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <a href="ReporteMesAMes.aspx">ReporteMesAMes.aspx</a><CR:CrystalReportViewer ID="CRV_Mes" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="1202px" ReportSourceID="CRS_Mes" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="1104px" PageZoomFactor="125" ToolPanelView="None" />
    <CR:CrystalReportSource ID="CRS_Mes" runat="server">
        <Report FileName="~\Reportes\ReporteMesAMes.rpt">
        </Report>
    </CR:CrystalReportSource>
    <br />
    <br />
   
</asp:Content>

