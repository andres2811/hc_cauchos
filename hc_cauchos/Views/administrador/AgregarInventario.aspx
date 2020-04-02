<%@ Page Title="" Language="C#" MasterPageFile="~/Views/administrador/admin.master" AutoEventWireup="true" CodeFile="~/Controllers/administrador/AgregarInventario.aspx.cs" Inherits="Views_administrador_AgregarInventario" %>

<script runat="server">



   
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
         <div class="row">
               <div class="col-md-4 col-md-offset-4">
                   Archivo:
                   <asp:FileUpload id="FU_Archivo" runat="server" CssClass  ="form-control" ></asp:FileUpload>
                   <br />
                    Referencia del item
                   <asp:TextBox ID="TB_referencia" runat="server" CssClass="form-control" ></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TB_referencia" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                   <br />
                   Titulo del item:
                   <asp:TextBox ID="TB_Titulo" runat="server" CssClass="form-control" ></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TB_Titulo" ErrorMessage="*"></asp:RequiredFieldValidator>
                   <br />
                   Precio
                    <asp:TextBox ID="TB_Precio" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="TB_Precio" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                   <br />
                   Cantidad
                    <asp:TextBox ID="TB_Cantidad" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="TB_Cantidad" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                   <br />
                   Cantidad Minima
                   <asp:TextBox ID="TB_Minima" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="TB_Cantidad" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                   <br />
                  
                   Marca&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Referencia<br />
                   <asp:DropDownList ID="DDL_Marca" runat="server" DataSourceID="ODS_Marca" DataTextField="Marca" DataValueField="Id"  Width="106px"></asp:DropDownList>
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   <asp:DropDownList ID="DDL_Categoria" runat="server" DataSourceID="ODS_Categoria" DataTextField="Categoria" DataValueField="Id" Width="106px"></asp:DropDownList>
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   <asp:ObjectDataSource ID="ODS_Marca" runat="server" SelectMethod="ColsultarMarca" TypeName="DAOAdmin"></asp:ObjectDataSource>
                   <br />
                   <asp:ObjectDataSource ID="ODS_Categoria" runat="server" SelectMethod="ColsultarCategoria" TypeName="DAOAdmin"></asp:ObjectDataSource>
                   <br />
                   <asp:Button ID ="BTN_subir" runat="server" Text="Subir" cssClass =" btn btn-success " OnClick="BTN_subir_Click"  />
                  
                   <br />
            
            
                 
                   </div> 
              </div>

    


</asp:Content>

