<%@ Page Title="" Language="C#" MasterPageFile="~/Views/principal.master" AutoEventWireup="true" CodeFile="~/Controllers/catalogo.aspx.cs" Inherits="Views_catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        #productos:hover{
            background:black;
            color:white;
            border-color:red;
            text-shadow:0px 0px 2px red;
        }
        #titu{
            text-shadow:0px 0px 1px black;
        }

        #Image1:hover{
            width:60%;

        }
     
        .auto-style1 {
            width: 203px;
        }
     
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ObjectDataSource ID="ODS_catalogo" runat="server" SelectMethod="ConsultarInventario" TypeName="DAOUser"></asp:ObjectDataSource>
    <br />
    <h1 id="titu" class="text-center text-danger"><strong>Catalogo</strong><br /><small>nuestros productos</small></h1>
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
    <asp:ObjectDataSource ID="ODS_Categoria" runat="server" SelectMethod="ColsultarCategoria2" TypeName="DAOAdmin"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODS_Marca" runat="server" SelectMethod="ColsultarMarca" TypeName="DAOAdmin"></asp:ObjectDataSource>
    <br />

    <div class="col-sm-12">
        <div class="form-inline justify-content-center">
            <div class="form-group">
                <asp:DropDownList ID="DD_Categoria" runat="server" class="form-control" DataSourceID="ODS_Categoria" DataTextField="Categoria" DataValueField="Id" Width="234px" >
                </asp:DropDownList>
          
                <asp:DropDownList ID="DD_Marca" runat="server" Class="form-control" DataSourceID="ODS_Marca" DataTextField="Marca" DataValueField="Id" Width="234px" >
                </asp:DropDownList>
      
                <asp:DropDownList ID="DDL_Precio" runat="server" Class="form-control" Width="234px">
                <asp:ListItem Value="0 , 0">Ordenar Precio</asp:ListItem>
                <asp:ListItem Value="0 , 10000">Menores a 10000</asp:ListItem>
                <asp:ListItem Value="10000 , 50000">10000 - 50000</asp:ListItem>
                <asp:ListItem Value="50000 , 100000">50000 - 100000</asp:ListItem>
                <asp:ListItem Value="100000 , 200000">100000 - 200000</asp:ListItem>
                <asp:ListItem Value="200000 , 500000">200000 - 500000</asp:ListItem>
                <asp:ListItem Value="500000 , 6000000">Mayores a 500000</asp:ListItem>
                </asp:DropDownList>
          
                <asp:Button ID="Btn_Buscar" runat="server" Class="btn btn-outline-danger" Text="Buscar" OnClick="Btn_Buscar_Click" BorderColor="Gray" />
                <asp:Button ID="Btn_Todos" runat="server" Class="btn btn-outline-danger" Text="Todos" OnClick="Btn_Todos_Click" BorderColor="Gray" /> 
            </div>
        </div>
    </div>

    <br />
    <br />
    <div class="row ">      
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ODS_catalogo">
        <ItemTemplate>            
            <div class="col-md-2 col-sm-6 col-xs-8 mb-3" >
                 <div class="card shadow border-0" style=" width:100%; height:450px;" id="productos">  
                         <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Imagen") %>' width="100%" Height="50%" class="card-img-top"  />                         
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

