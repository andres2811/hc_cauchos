<%@ Page Title="" Language="C#" MasterPageFile="~/Views/administrador/admin.master" AutoEventWireup="true" CodeFile="~/Controllers/administrador/HistorialVentas.aspx.cs" Inherits="Views_administrador_HistorialVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 382px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <br />
    <h1 class="text-center"><strong>Historial De Ventas</strong></h1>
      <br />
      <table class="nav-justified">
          <tr>
              <td><asp:TextBox ID="TB_Dia" placeholder="Dia" runat="server" TextMode="Number"></asp:TextBox></td>
              <td >
                  <asp:TextBox ID="TB_Mes" placeholder="Mes" runat="server" TextMode="Number"></asp:TextBox>
              </td>
              <td>
                  <asp:TextBox ID="TB_Ano" placeholder="Año" runat="server" TextMode="Number"></asp:TextBox>
              </td>
              <td>
                  <asp:Button ID="Btn_Buscar" CssClass="btn btn-primary" runat="server" Text="Button" OnClick="Btn_Buscar_Click" />
              </td>
              <td>
                  <asp:Button ID="Btn_Todos" CssClass="btn btn-primary" runat="server" Text="Button" />
              </td>
          </tr>
      </table>
    <br />
    <asp:GridView ID="GV_Historial" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ODS_Historial" ForeColor="#333333" GridLines="None" OnDataBound="GV_Historial_DataBound">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="Empleado" HeaderText="Empleado" SortExpression="Empleado" />
            <asp:BoundField DataField="Fecha_pedido" HeaderText="Fecha_pedido" SortExpression="Fecha_pedido" />
            <asp:BoundField DataField="Usuario" HeaderText="Usuario" SortExpression="Usuario" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
            <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
      </asp:GridView>
      <asp:ObjectDataSource ID="ODS_Historial" runat="server" SelectMethod="ConsultarVentas" TypeName="DAOAdmin"></asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ODS_HistorialDia" runat="server" SelectMethod="ConsultarVentasDia" TypeName="DAOAdmin">
          <SelectParameters>
              <asp:ControlParameter ControlID="TB_Dia" Name="Dia" PropertyName="Text" Type="Int32" />
          </SelectParameters>
      </asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ODS_HistorialMes" runat="server" SelectMethod="ConsultarVentasMes" TypeName="DAOAdmin">
          <SelectParameters>
              <asp:ControlParameter ControlID="TB_Mes" Name="mes" PropertyName="Text" Type="Int32" />
          </SelectParameters>
      </asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ODS_HistorialAno" runat="server" SelectMethod="ConsultarVentasAno" TypeName="DAOAdmin">
          <SelectParameters>
              <asp:ControlParameter ControlID="TB_Ano" Name="ano" PropertyName="Text" Type="Int32" />
          </SelectParameters>
      </asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ODS_HistorialAnoMes" runat="server" SelectMethod="ConsultarVentasAnoMes" TypeName="DAOAdmin">
          <SelectParameters>
              <asp:ControlParameter ControlID="TB_Ano" Name="ano" PropertyName="Text" Type="Int32" />
              <asp:ControlParameter ControlID="TB_Mes" Name="mes" PropertyName="Text" Type="Int32" />
          </SelectParameters>
      </asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ODS_HistorialAnoDia" runat="server" SelectMethod="ConsultarVentasAnoDia" TypeName="DAOAdmin">
          <SelectParameters>
              <asp:ControlParameter ControlID="TB_Ano" Name="ano" PropertyName="Text" Type="Int32" />
              <asp:ControlParameter ControlID="TB_Dia" Name="dia" PropertyName="Text" Type="Int32" />
          </SelectParameters>
      </asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ODS_HistorialAnoMesDia" runat="server" SelectMethod="ConsultarVentasAnoMesDia" TypeName="DAOAdmin">
          <SelectParameters>
              <asp:ControlParameter ControlID="TB_Ano" Name="ano" PropertyName="Text" Type="Int32" />
              <asp:ControlParameter ControlID="TB_Mes" Name="mes" PropertyName="Text" Type="Int32" />
              <asp:ControlParameter ControlID="TB_Dia" Name="dia" PropertyName="Text" Type="Int32" />
          </SelectParameters>
      </asp:ObjectDataSource>
      <br />
</asp:Content>

