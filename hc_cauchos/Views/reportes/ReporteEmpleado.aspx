﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/administrador/admin.master" AutoEventWireup="true" CodeFile="~/Controllers/reportes/ReporteEmpleado.aspx.cs" Inherits="Views_reportes_ReporteEmpleado" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <CR:CrystalReportViewer ID="CRV_Empleado" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="1202px" ReportSourceID="CRS_Empleado" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="1104px" />
    <CR:CrystalReportSource ID="CRS_Empleado" runat="server">
        <report filename="Z:\hc_cauchos\hc_cauchos\Reportes\ReporteVentasEmpleado.rpt">
        </report>
    </CR:CrystalReportSource>
</asp:Content>

