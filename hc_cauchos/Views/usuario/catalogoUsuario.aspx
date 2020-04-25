<%@ Page Title="" Language="C#" MasterPageFile="~/Views/usuario/usuario.master" AutoEventWireup="true" CodeFile="~/Controllers/usuario/catalogoUsuario.aspx.cs" Inherits="Views_usuario_catalogoUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        #productos{
            border-color:black;
        }
        #productos:hover{
            background:#0b94fa;
            color:white;
            border-color:#0b94fa;
        }
        #productos h4:hover{
            color:black;
            font-size:30px;
        }
        #Image1:hover{
            width:60%;

        }
        
     
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ObjectDataSource ID="ODS_catalogo" runat="server" SelectMethod="ConsultarInventario" TypeName="DAOAdmin"></asp:ObjectDataSource>
    <br />
    <h1 class="text-center text-primary"><strong>Catalogo</strong><br />
        <small><strong>nuestros productos</strong></small></h1>
    <br />
    <br />
    <div class="row ">      
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ODS_catalogo" OnItemCommand="Repeater1_ItemCommand">
        <ItemTemplate>            
            <div class="col-md-2 col-sm-6 col-xs-8 mb-3" >
                 <div class="card shadow" style=" width:270px; height:600px;" id="productos">  
                         <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Imagen") %>' width="100%" Height="50%" class="card-img-top" ImageAlign="TextTop"  />                         
                            <div class="card-body text-capitalize text-center">
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
                                Cantidad:
                                <asp:TextBox ID="TB_cantidad" runat="server" TextMode="Number" Class="card-text" Width="25%" CssClass="text-black"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFV_cantidad" runat="server" ErrorMessage="*" ControlToValidate="TB_cantidad" EnableClientScript="True" ValidationGroup='<%# Eval("Id") %>'></asp:RequiredFieldValidator>
                                <br />
                                <asp:ImageButton ID="BTNI_carritoAdd" runat="server" ImageUrl="~/ima/carro.png" ImageAlign="AbsBottom" CommandArgument='<%# Eval("Id") %>' ValidationGroup='<%# Eval("Id") %>' />
                                
                            </div>
               </div>    
          </div>                            
        </ItemTemplate>
    </asp:Repeater>
    </div>
</asp:Content>

