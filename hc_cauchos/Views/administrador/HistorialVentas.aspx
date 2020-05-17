<%@ Page Title="" Language="C#" MasterPageFile="~/Views/administrador/admin.master" AutoEventWireup="true" CodeFile="~/Controllers/administrador/HistorialVentas.aspx.cs" Inherits="Views_administrador_HistorialVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style5 {
            height: 56px;
        }
        .auto-style6 {
            width: 260px;
            height: 56px;
        }
        .auto-style8 {
            width: 109px;
        }
        .auto-style10 {
            display: block;
/*height:34px;*/padding: 6px 12px;
/*font-size:14px*/;line-height: 1.42857143;
            color: #555;
            background-color: #fff;
            background-image: none;
            border: 1px solid #ccc;
            border-radius: 7px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
        }
        .auto-style14 {
            width: 260px;
        }
        .auto-style15 {
            width: 131px;
        }
        .auto-style16 {
            width: 361px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <br />
      <br />
    <h1 class="text-center"><strong>Historial De Ventas</strong></h1>
      <br />
      
      <table class="nav-justified">
          <tr>
              <td class="auto-style8">&nbsp;</td>
              <td class="auto-style14"><asp:TextBox ID="TB_Dia" placeholder="Dia (DD)" CssClass="form-control" runat="server" TextMode="Number" Width="150px"></asp:TextBox>
                  </td>
              <td class="auto-style14">
                  <asp:TextBox ID="TB_Mes" placeholder="Mes (MM)" CssClass="form-control" runat="server" TextMode="Number" Width="150px"></asp:TextBox>
              </td>
              <td>
                  
                  <asp:TextBox ID="TB_Ano" placeholder="Año (YYYY)" CssClass="form-control" runat="server" TextMode="Number" Width="150px" ></asp:TextBox>
                  
                   </td>
              <td>&nbsp;</td>
          </tr>
          <tr>
              <td class="auto-style5"></td>
              <td class="auto-style6">
                  <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Dia invalido,Rango entre 1-31" MinimumValue="1" MaximumValue="31" ControlToValidate="TB_Dia" Type="Integer"></asp:RangeValidator>
                  </td>
              <td class="auto-style6">
                  <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Mes invalido,Rango entre 1-12" MinimumValue="1" MaximumValue="12" ControlToValidate="TB_Mes" Type="Integer"></asp:RangeValidator>
              </td>
              <td class="auto-style5">
                   
                  <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="Año invalido,Rango entre 2000-2100" MinimumValue="2000" MaximumValue="2100" ControlToValidate="TB_Ano" Type="Integer"></asp:RangeValidator>
                                 
              <td class="auto-style5"></td>
          </tr>
          <tr>
              <td class="auto-style8">&nbsp;</td>
              <td class="auto-style14">
                  <asp:RadioButtonList ID="RBL" runat="server" CssClass="auto-style10" AutoPostBack="True" OnSelectedIndexChanged="RBL_SelectedIndexChanged" Width="227px">
                       <asp:ListItem Value="0">Activar Empleado</asp:ListItem>
                        <asp:ListItem Value="1">Desactivar Empleado</asp:ListItem>
                   </asp:RadioButtonList>
                  </td>
              <td class="auto-style14">
                  <asp:DropDownList ID="DDL_Empleado" CssClass="auto-style10" runat="server" DataSourceID="ODS_Empleado" DataTextField="Nombre" DataValueField="User_id"  Enabled="False" Width="128px" Visible="False" OnSelectedIndexChanged="DDL_Empleado_SelectedIndexChanged">
                      <asp:ListItem Value="0"></asp:ListItem>
                     
                   </asp:DropDownList>
                  <asp:TextBox ID="TB_Aux" runat="server" TextMode="Number" Visible="False"></asp:TextBox>
                  <br />
              </td>
              <td>
                   <asp:ObjectDataSource ID="ODS_Empleado" runat="server" SelectMethod="ConsultarEmpleado" TypeName="DAOAdmin"></asp:ObjectDataSource>
                    </td>
              <td>&nbsp;</td>
          </tr>
      </table>
                <br />
               
                  <table class="nav-justified">
                      <tr>
                          <td class="auto-style16">&nbsp;</td>
                          <td class="auto-style15">
   
                  <asp:Button ID="Btn_Buscar" CssClass="btn btn-primary" runat="server" Text="Buscar" OnClick="Btn_Buscar_Click" />
                          </td>
                          <td>
                  <asp:Button ID="Btn_Todos" CssClass="btn btn-primary" runat="server" Text="Todos" OnClick="Btn_Todos_Click" style="margin-left: 0" />
                          </td>
                          <td>&nbsp;</td>
                      </tr>
      </table>
      <br />
    <br />

    <div class="row">
        <div class="col-md-10 col-md-offset-1">
    <asp:GridView ID="GV_Historial" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ODS_Historial" ForeColor="#333333" GridLines="None" Width="788px" OnRowDataBound="GV_Historial_RowDataBound" ShowFooter="True" AllowPaging="True">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="Empleado" HeaderText="Empleado" SortExpression="Empleado" />
            <asp:BoundField DataField="Fecha_pedido" HeaderText="Fecha " SortExpression="Fecha_pedido" />
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

        </div>
            </div>
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
      <asp:ObjectDataSource ID="ODS_HistorialMesDia" runat="server" SelectMethod="ConsultarVentasMesDia" TypeName="DAOAdmin">
          <SelectParameters>
              <asp:ControlParameter ControlID="TB_Mes" Name="mes" PropertyName="Text" Type="Int32" />
              <asp:ControlParameter ControlID="TB_Dia" Name="dia" PropertyName="Text" Type="Int32" />
          </SelectParameters>
      </asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ODS_HistorialEmpleado" runat="server" SelectMethod="ConsultarVentasAnoMesDiaEmpleado" TypeName="DAOAdmin">
          <SelectParameters>
              <asp:ControlParameter ControlID="TB_Ano" Name="ano" PropertyName="Text" Type="Int32" />
              <asp:ControlParameter ControlID="TB_Mes" Name="mes" PropertyName="Text" Type="Int32" />
              <asp:ControlParameter ControlID="TB_Dia" Name="dia" PropertyName="Text" Type="Int32" />
              <asp:ControlParameter ControlID="DDL_Empleado" Name="emp" PropertyName="SelectedValue" Type="Int32" />
          </SelectParameters>
      </asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ODS_HistorialAnoMesDia0" runat="server" SelectMethod="ConsultarVentasAnoMesDia" TypeName="DAOAdmin">
          <SelectParameters>
              <asp:ControlParameter ControlID="TB_Ano" Name="ano" PropertyName="Text" Type="Int32" />
              <asp:ControlParameter ControlID="TB_Mes" Name="mes" PropertyName="Text" Type="Int32" />
              <asp:ControlParameter ControlID="TB_Dia" Name="dia" PropertyName="Text" Type="Int32" />
          </SelectParameters>
      </asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ODS_HistorialAnoMes" runat="server" SelectMethod="ConsultarVentasAnoMes" TypeName="DAOUser">
          <SelectParameters>
              <asp:ControlParameter ControlID="TB_Ano" Name="ano" PropertyName="Text" Type="Int32" />
              <asp:ControlParameter ControlID="TB_Mes" Name="mes" PropertyName="Text" Type="Int32" />
          </SelectParameters>
      </asp:ObjectDataSource>
      <br />
</asp:Content>

