﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/administrador/admin.master" AutoEventWireup="true" CodeFile="~/Controllers/administrador/AgregarInventario.aspx.cs" Inherits="Views_administrador_AgregarInventario" %>

<script runat="server">



   
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <h1 class="text-center text-primary"><strong>Agregar Producto</strong></h1>
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

                  <div class="col-sm-12">
                     <div class="form-inline justify-content-center">
                        <div class="form-group">
                            <asp:DropDownList ID="DDL_Marca" runat="server" class="form-control" DataSourceID="ODS_Marca" DataTextField="Marca" DataValueField="Id"  Width="130px"></asp:DropDownList>
                             <asp:DropDownList ID="DDL_Categoria" runat="server" class="form-control"  DataSourceID="ODS_Categoria" DataTextField="Categoria" DataValueField="Id" Width="129px"></asp:DropDownList>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" InitialValue= "0" ControlToValidate="DDL_Categoria" ErrorMessage="*"></asp:RequiredFieldValidator>
                        
                        </div>
                    </div>
                  </div>  

                  <div class="col-sm-12">
                     <div class="form-inline justify-content-center">
                        <div class="form-group">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" InitialValue= "0"  ControlToValidate="DDL_Marca">*</asp:RequiredFieldValidator>
                         </div>
                    </div>
                  </div>  
                       
                        

                  <asp:ObjectDataSource ID="ODS_Marca" runat="server" SelectMethod="ColsultarMarca" TypeName="DAOAdmin"></asp:ObjectDataSource>
                       <br />
                       <asp:ObjectDataSource ID="ODS_Categoria" runat="server" SelectMethod="ColsultarCategoria" TypeName="DAOAdmin"></asp:ObjectDataSource>
                       <asp:Button ID ="BTN_subir" runat="server" Text="Almacenar" class=" btn btn-primary center-block" OnClick="BTN_subir_Click"  />
                       <asp:Panel runat="server" ID="PanelMensaje" Visible="false" CssClass="alert alert-danger shadow" role="alert">
	                        <strong>
	                        <asp:Label ID="LblMensaje" runat="server" />
	                        </strong>
	                        <asp:LinkButton Text="<span aria-hidden='true'>&times;</span>" runat="server" CssClass="close" ID="B_cerrar_mensaje1" OnClick="B_cerrar_mensaje1_Click" />
                        </asp:Panel>

                        <asp:Panel runat="server" ID="PanelMensaje1" Visible="false" CssClass="alert alert-warning shadow" role="alert">
	                        <strong>
	                        <asp:Label ID="LblMensaje1" runat="server" />
	                        </strong>
	                        <asp:LinkButton Text="<span aria-hidden='true'>&times;</span>" runat="server" CssClass="close" ID="LinkButton1" OnClick="LinkButton1_Click" />
                        </asp:Panel>

                        <asp:Panel runat="server" ID="PanelMensaje2" Visible="false" CssClass="alert alert-success shadow" role="alert">
	                        <strong>
	                        <asp:Label ID="LblMensaje2" runat="server" />
	                        </strong>
	                        <asp:LinkButton Text="<span aria-hidden='true'>&times;</span>" runat="server" CssClass="close" ID="LinkButton2" OnClick="LinkButton2_Click" />
                        </asp:Panel>
                       <br />
                   </div>   
               </div> 
         </div>
</asp:Content>

