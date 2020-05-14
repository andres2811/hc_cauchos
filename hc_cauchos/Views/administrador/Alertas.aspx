<%@ Page Title="" Language="C#" MasterPageFile="~/Views/administrador/admin.master" AutoEventWireup="true" CodeFile="~/Controllers/administrador/Alertas.aspx.cs" Inherits="Views_administrador_Alertas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">




  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
 
    
  <div class="card">
  <div class="card-header">
        Featured
  </div>
  <div class="card-body">
    <h5 class="card-title">Special title treatment</h5>
    <p class="card-text">With supporting text below as a natural lead-in to additional content.</p>
    <a href="#" class="btn btn-primary">Go somewhere</a>
  </div>
</div>
    <asp:Repeater ID="RepeaterAlerta" runat="server" DataSourceID="ODS_Alertas" OnItemDataBound="RepeaterAlerta_ItemDataBound" OnItemCommand="RepeaterAlerta_ItemCommand"  >
                <ItemTemplate>
            
                    <div class="card" >
                        <h5 class="card-header">Producto en baja cantidad</h5>
                        <div class="card-body">
                            <h5 class="card-title">Nombre <%# Eval("Titulo") %> Referencia : <%# Eval("Referencia") %>  </h1></h5>
                            <p class="card-text">El producto se encuentra en una catidad Critica <%# Eval("Ca_actual") %> </p>
                             <asp:Button ID="BT_Alerta" runat="server" Text="Abastecer" CssClass="btn btn-primary" />
                    </div>
                    </div>

                   
              </ItemTemplate>
            
       </asp:Repeater>
    </asp:Content>

