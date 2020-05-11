<%@ Page Title="" Language="C#" MasterPageFile="~/Views/administrador/admin.master" AutoEventWireup="true" CodeFile="~/Controllers/administrador/AgregarInventario.aspx.cs" Inherits="Views_administrador_AgregarInventario" %>

<script runat="server">



   
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <h1 class="text-center"><strong>Agregar Producto</strong></h1>
         <div class="row">
               <div class="col-md-4 col-md-offset-4">
                   <div class="form-group">
                       <br /> <br />
                       Imagen:
                       <asp:FileUpload id="FU_Archivo" runat="server" CssClass  ="form-control" ></asp:FileUpload>
                       <br />
                       <asp:TextBox ID="TB_referencia" runat="server" CssClass="form-control" placeholder="Referencia Item" MaxLength="25" ></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TB_referencia" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                       <asp:TextBox ID="TB_Titulo" runat="server" CssClass="form-control" placeholder="Titulo Item" MaxLength ="25" ></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TB_Titulo" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="TB_Precio" runat="server" CssClass="form-control" TextMode="Number" placeholder="Precio " MaxLength="6"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="TB_Precio" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                       <asp:TextBox ID="TB_Minima" runat="server" CssClass="form-control" TextMode="Number" placeholder="Cantidad Minima" MaxLength="5"></asp:TextBox>
                       <br />

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                       <asp:DropDownList ID="DDL_Marca" runat="server" DataSourceID="ODS_Marca" DataTextField="Marca" DataValueField="Id"  Width="130px"></asp:DropDownList>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" InitialValue= "0"  ControlToValidate="DDL_Marca">*</asp:RequiredFieldValidator>
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       <asp:DropDownList ID="DDL_Categoria" runat="server"  DataSourceID="ODS_Categoria" DataTextField="Categoria" DataValueField="Id" Width="129px"></asp:DropDownList>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" InitialValue= "0" ControlToValidate="DDL_Categoria" ErrorMessage="*"></asp:RequiredFieldValidator>
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       
                    

                       <asp:ObjectDataSource ID="ODS_Marca" runat="server" SelectMethod="ColsultarMarca" TypeName="DAOAdmin"></asp:ObjectDataSource>
                       <br />
                       <br />
                       <br />
                       <asp:ObjectDataSource ID="ODS_Categoria" runat="server" SelectMethod="ColsultarCategoria" TypeName="DAOAdmin"></asp:ObjectDataSource>
                       <asp:Button ID ="BTN_subir" runat="server" Text="Almacenar" cssClass =" btn btn-primary" OnClick="BTN_subir_Click"  />                  
                       <br />
                   </div>   
               </div> 
         </div>
</asp:Content>

