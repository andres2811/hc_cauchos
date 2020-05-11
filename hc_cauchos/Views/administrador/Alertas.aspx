<%@ Page Title="" Language="C#" MasterPageFile="~/Views/administrador/admin.master" AutoEventWireup="true" CodeFile="~/Controllers/administrador/Alertas.aspx.cs" Inherits="Views_administrador_Alertas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  
     
 <style type="text/css">
          card-body {
            flex: 1 1 auto;
            padding: 1.25rem;
    }
     
     .auto-style1 {
         position: absolute;
         top: 95px;
         left: 575px;
         z-index: 1;
     }
     
     </style>
  

    
  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../../bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <br />
         <h1 class="text-center"><strong>Notificaciones</strong></h1>
        <br />
     <div class="col-lg-1 col-md-offset-0.10" >
   
     <div class=" container" >
                 <div class="row" >   
                     
    <asp:Repeater ID="RepeaterAlerta" runat="server" DataSourceID="ODS_Alertas" OnItemDataBound="RepeaterAlerta_ItemDataBound" OnItemCommand="RepeaterAlerta_ItemCommand"  >
          
        <ItemTemplate>
            
           
                          <div class="card mb-4 py-9 border-bottom-danger">
                            <br />
                              <div class="card-body">
                                  
                               <h1 aria-multiline="true" > Producto en catidad critica 
                                <%# Eval("Ca_actual") %> </h1>
                                
                                   </> <asp:Label ID="Label1" runat="server" Text='<%# Eval("Titulo") %>' />
                                  referencia :<asp:Label ID="LB_Referencia" runat="server" Text='<%# Eval("Referencia") %>' ForeColor="Red" ></asp:Label>
                                <asp:Button ID="BT_Alerta" runat="server" Text="Abastecer" CssClass="btn btn-primary" />
                                  <asp:Label ID="LB_id" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                                
                              </div>
                              <br />
                            </div>

                  
           
                 
            
                    
                   
        </ItemTemplate>
            
    </asp:Repeater>
       </div>
          </div>
       </div>         
 
    
    <asp:ObjectDataSource ID="ODS_Alertas" runat="server" SelectMethod="ConsultarAlertas" TypeName="DAOAdmin"></asp:ObjectDataSource>
    
        <br />
            
    </asp:Content>

