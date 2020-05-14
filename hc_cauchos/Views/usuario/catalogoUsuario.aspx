﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/usuario/usuario.master" AutoEventWireup="true" CodeFile="~/Controllers/usuario/catalogoUsuario.aspx.cs" Inherits="Views_usuario_catalogoUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../archivos_index/barra_carrito/font.css" rel="stylesheet" />
    <link href="../../archivos_index/barra_carrito/estilos_Carrito.css" rel="stylesheet" />
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
                
        .auto-style2 {
            width: 283px;
        }
                
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="social-bar1">
        <a href="Carrito.aspx" class="icon icon-cart">
           &nbsp;<asp:Label ID="LB_cantidad" runat="server" Text=""></asp:Label> 
        </a>
    </div>
    <asp:ObjectDataSource ID="ODS_catalogo" runat="server" SelectMethod="ConsultarInventario" TypeName="DAOUser"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODS_catalogoCategoria" runat="server" SelectMethod="ConsultarInventarioCategoria" TypeName="DAOUser">
        <SelectParameters>
            <asp:ControlParameter ControlID="DD_Categoria" Name="categ" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODS_catalogoMarca" runat="server" SelectMethod="ConsultarInventariMarca" TypeName="DAOUser">
        <SelectParameters>
            <asp:ControlParameter ControlID="DD_Marca" Name="marca" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODS_catalogoCombinado" runat="server" SelectMethod="ConsultarInventariCombinado" TypeName="DAOUser">
        <SelectParameters>
            <asp:ControlParameter ControlID="DD_Marca" Name="marca" PropertyName="SelectedValue" Type="Int32" />
            <asp:ControlParameter ControlID="DD_Categoria" Name="categ" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODS_catalogoPrecio" runat="server" SelectMethod="ConsultarInventarioPrecio" TypeName="DAOUser" >
        <SelectParameters>
            <asp:ControlParameter ControlID="DDL_Precio" Name="valores" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODS_catalogoPrecioCategoria" runat="server" SelectMethod="ConsultarInventarioPrecioCategoria" TypeName="DAOUser">
        <SelectParameters>
            <asp:ControlParameter ControlID="DDL_Precio" Name="valores" PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="DD_Categoria" Name="categ" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODS_catalogoPrecioMarca" runat="server" SelectMethod="ConsultarInventarioPrecioMarca" TypeName="DAOUser">
        <SelectParameters>
            <asp:ControlParameter ControlID="DDL_Precio" Name="valores" PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="DD_Marca" Name="marca" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODS_catalogoPrecioCombinado" runat="server" SelectMethod="ConsultarInventarioPrecioCombinado" TypeName="DAOUser">
        <SelectParameters>
            <asp:ControlParameter ControlID="DDL_Precio" Name="valores" PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="DD_Marca" Name="marca" PropertyName="SelectedValue" Type="Int32" />
            <asp:ControlParameter ControlID="DD_Categoria" Name="categor" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <h1 class="text-center text-primary"><strong>Catalogo</strong><br />
        <small><strong>nuestros productos</strong></small></h1>
    <asp:ObjectDataSource ID="ODS_Categoria" runat="server" SelectMethod="ColsultarCategoria2" TypeName="DAOAdmin"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODS_Marca" runat="server" SelectMethod="ColsultarMarca" TypeName="DAOAdmin"></asp:ObjectDataSource>
    <table class="nav-justified">
        <tr>
            <td> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td >
                <asp:DropDownList ID="DD_Categoria" runat="server" class="form-control" DataSourceID="ODS_Categoria" DataTextField="Categoria" DataValueField="Id" Width="234px" >
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="DD_Marca" runat="server" Class="form-control" DataSourceID="ODS_Marca" DataTextField="Marca" DataValueField="Id" Width="234px" >
                </asp:DropDownList>
            </td>

            <td>
                <asp:DropDownList ID="DDL_Precio" runat="server" Class="form-control" Width="234px">
                <asp:ListItem Value="0 , 0">Ordenar Precio</asp:ListItem>
                <asp:ListItem Value="0 , 10000">Menores a 10000</asp:ListItem>
                <asp:ListItem Value="10000 , 50000">10000 - 50000</asp:ListItem>
                <asp:ListItem Value="50000 , 100000">50000 - 100000</asp:ListItem>
                <asp:ListItem Value="100000 , 200000">100000 - 200000</asp:ListItem>
                <asp:ListItem Value="200000 , 500000">200000 - 500000</asp:ListItem>
                <asp:ListItem Value="500000 , 6000000">Mayores a 500000</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td> <asp:Button ID="Btn_Buscar" runat="server" Class="btn btn-dropbox" Text="Buscar" OnClick="Btn_Buscar_Click" /> </td>
            <td> <asp:Button ID="Btn_Todos" runat="server" Class="btn btn-dropbox" Text="Todos" OnClick="Btn_Todos_Click" /> </td>
        </tr>
    </table>
    <br />
    <div class="row ">      
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ODS_catalogo" OnItemCommand="Repeater1_ItemCommand">
        <ItemTemplate>            
            <div class="col-md-2 col-sm-6 col-xs-8 mb-3" >
                 <div class="card shadow" style=" width:270px; height:630px;" id="productos">  
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
                                <asp:TextBox ID="TB_cantidad" runat="server" TextMode="number" Class="card-text" Width="25%" CssClass="text-black" MaxLength="4"></asp:TextBox>                         
                                <asp:RequiredFieldValidator ID="RFV_cantidad" runat="server" ErrorMessage="*" ControlToValidate="TB_cantidad" EnableClientScript="True" ValidationGroup='<%# Eval("Id") %>'></asp:RequiredFieldValidator>&nbsp;&nbsp;
                                <asp:RangeValidator ID="RV_cantidad" runat="server" ErrorMessage="valor invalido" ControlToValidate="TB_cantidad" MaximumValue="1000" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                                <br />
                                <asp:ImageButton ID="BTNI_carritoAdd" runat="server" ImageUrl="~/ima/carro.png" ImageAlign="AbsBottom" CommandArgument='<%# Eval("Id") %>' ValidationGroup='<%# Eval("Id") %>' />
                                
                            </div>
               </div>    
          </div>                            
        </ItemTemplate>
    </asp:Repeater>
    </div>
</asp:Content>

