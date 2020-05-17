<%@ Page Title="" Language="C#" MasterPageFile="~/Views/administrador/admin.master" AutoEventWireup="true" CodeFile="~/Controllers/administrador/Alertas.aspx.cs" Inherits="Views_administrador_Alertas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">




  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
 
    

&nbsp;<asp:ObjectDataSource ID="ODS_Alertas" runat="server" SelectMethod="ConsultarAlertas" TypeName="DAOAdmin"></asp:ObjectDataSource>

   <link href="../../bootstrap/css/Alertas.css" rel="stylesheet" type="text/css" />
    
    <div class="row" >
        <div class="col-md-8 col-md-offset-2 ">
        <asp:Repeater ID="RepeaterAlerta" runat="server" DataSourceID="ODS_Alertas" OnItemDataBound="RepeaterAlerta_ItemDataBound" OnItemCommand="RepeaterAlerta_ItemCommand"  >
          
                <ItemTemplate>
            <div class="card mb-4 py-3 border-left-danger">
             <div class="card">
                <div class="card-header" >
               CANTIDAD CRITICA 
            </div>
            <div class="card-body">
            <h5 class="card-title"><%# Eval("Titulo") %></h5>
            <p class="card-text">El producto con referencia <%# Eval("Referencia") %> se encunetra menor a su cantidad minima <%# Eval("Ca_minima") %> </p>
            <p class="card-text">Cantidad Actual:<%# Eval("Ca_actual") %></p>
              <asp:Button ID="BT_Alerta" runat="server" Text="Abastecer" CssClass="btn btn-primary" />
                         
             </div>
            </div>
                </div>
                     <br />
                    <br />
                  
                            
                            
                    </ItemTemplate>
            
                </asp:Repeater>
        </div>
    </div>
    </asp:Content>

