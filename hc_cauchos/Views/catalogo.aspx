<%@ Page Title="" Language="C#" MasterPageFile="~/Views/principal.master" AutoEventWireup="true" CodeFile="~/Controllers/catalogo.aspx.cs" Inherits="Views_catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        #productos:hover{
            background:black;
            color:white;
            border-color:red;
        }
        #productos h4:hover{
            color:red;
            font-size:30px;
        }
        #Image1:hover{
            width:60%;

        }
     
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <table class="w-100">
        <tr>
            <td>
                <asp:DataList ID="DL_catalogo" runat="server" DataSourceID="ODS_catalogo" RepeatColumns="4" Width="839px" >
                    <ItemTemplate>


                        <asp:Image ID="Image1" runat="server" />
                        Id:
                        <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                        <br />
                        Imagen:
                        <asp:Label ID="ImagenLabel" runat="server" Text='<%# Eval("Imagen") %>' />
                        <br />
                        Titulo:
                        <asp:Label ID="TituloLabel" runat="server" Text='<%# Eval("Titulo") %>' />
                        <br />
                        Referencia:
                        <asp:Label ID="ReferenciaLabel" runat="server" Text='<%# Eval("Referencia") %>' />
                        <br />
                        Precio:
                        <asp:Label ID="PrecioLabel" runat="server" Text='<%# Eval("Precio") %>' />
                        <br />
                        Ca_actual:
                        <asp:Label ID="Ca_actualLabel" runat="server" Text='<%# Eval("Ca_actual") %>' />
                        <br />
                        Ca_minima:
                        <asp:Label ID="Ca_minimaLabel" runat="server" Text='<%# Eval("Ca_minima") %>' />
                        <br />
                        Id_marca:
                        <asp:Label ID="Id_marcaLabel" runat="server" Text='<%# Eval("Id_marca") %>' />
<br />
                        Id_categoria:
                        <asp:Label ID="Id_categoriaLabel" runat="server" Text='<%# Eval("Id_categoria") %>' />
                        <br />
                        Id_estado:
                        <asp:Label ID="Id_estadoLabel" runat="server" Text='<%# Eval("Id_estado") %>' />
                        <br />
                        Nombre_marca:
                        <asp:Label ID="Nombre_marcaLabel" runat="server" Text='<%# Eval("Nombre_marca") %>' />
                        <br />
                        Nombre_categoria:
                        <asp:Label ID="Nombre_categoriaLabel" runat="server" Text='<%# Eval("Nombre_categoria") %>' />
                        <br />
                        Estado:
                        <asp:Label ID="EstadoLabel" runat="server" Text='<%# Eval("Estado") %>' />
                        <br />
                        <br />
                    </ItemTemplate>
                </asp:DataList>
                <asp:ObjectDataSource ID="ODS_catalogo" runat="server" SelectMethod="ConsultarInventario" TypeName="DAOAdmin"></asp:ObjectDataSource>
            </td>
        </tr>
    </table>


    <asp:ObjectDataSource ID="ODS_catalogo" runat="server" SelectMethod="ConsultarInventario" TypeName="DAOAdmin"></asp:ObjectDataSource>
    <br />
    <h1 class="text-center text-danger"><strong>Catalogo</strong><br /><small>nuestros productos</small></h1>
    <br />
    <br />
    <div class="row ">      
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ODS_catalogo">
        <ItemTemplate>            
            <div class="col-md-2 col-sm-6 col-xs-8 mb-3" >
                 <div class="card shadow" style=" width:300px; height:480px;" id="productos">  
                         <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Imagen") %>' width="100%" Height="60%" class="card-img-top"  />                         
                            <div class="card-body text-capitalize">
                                <h4 class="card-title text-center" id="titulo">
                                    <strong><asp:Label ID="TituloLabel" runat="server" Text='<%# Eval("Titulo") %>' /></strong>
                                </h4>
                                Referencia:
                                <asp:Label ID="ReferenciaLabel" runat="server" Text='<%# Eval("Referencia") %>' class="card-text" />
                                <br />
                                Precio:
                                <asp:Label ID="PrecioLabel" runat="server" Text='<%# Eval("Precio") %>' class="card-text" />
                                <br />
                                Stock:
                                <asp:Label ID="Ca_actualLabel" runat="server" Text='<%# Eval("Ca_actual") %>' class="card-text"/>
                                <br />
                                Marca:
                                <asp:Label ID="NombremarcaLabel" runat="server" Text='<%# Eval("Nombre_marca") %>' class="card-text"/>
                                <br />
                                Categoria:
                                <asp:Label ID="Nombre_categoriaLabel" runat="server" Text='<%# Eval("Nombre_categoria") %>' class="card-text"/>
                                <br />                              
                            </div>
               </div>    
          </div>                            
        </ItemTemplate>
    </asp:Repeater>
    </div>
    

</asp:Content>

