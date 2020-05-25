<%@ Page Title="" Language="C#" MasterPageFile="~/Views/empleado/empleado.master" AutoEventWireup="true" CodeFile="~/Controllers/empleado/facturar.aspx.cs" Inherits="Views_empleado_facturar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../archivos_index/barra_factura/estilos_Factura.css" rel="stylesheet" />
    <link href="../../archivos_index/barra_factura/font.css" rel="stylesheet" />
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
    <div class="social-bar1">
        <a href="venta.aspx" class="icon icon-file-text2">
           &nbsp;<asp:Label ID="LB_cantidad" runat="server" Text=""></asp:Label> 
        </a>
    </div>
  
    <br />
    <h1 class="text-center text-primary"><strong>PRODUCTOS <br />
        <small>Agrega tus productos y cantidades</small></strong></h1>
    <asp:ObjectDataSource ID="ODS_catalogo0" runat="server" SelectMethod="ConsultarInventario" TypeName="DAOUser"></asp:ObjectDataSource>
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

                 <asp:Button ID="Btn_Buscar" runat="server" Class="btn btn-primary" Text="Buscar" OnClick="Btn_Buscar_Click" /> 
                 <asp:Button ID="Btn_Todos" runat="server" Class="btn btn-primary" Text="Todos" OnClick="Btn_Todos_Click" /> </>
            </div>
        </div>  
    </div>
    <br />
    <br />
    <div class="text-center center-block" style=" width:50%;">
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
    </div>
    <asp:ObjectDataSource ID="ODS_catalogo" runat="server" SelectMethod="ConsultarInventario" TypeName="DAOUser"></asp:ObjectDataSource>
    <div class="row ">  
        <br />
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ODS_catalogo"  OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound" >
        <ItemTemplate>            
            <div class="col-md-2 col-sm-6 col-xs-8 mb-3" >
                 <div class="card shadow text-block" style=" width:165px; height:510px;" id="productos">  
                         <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Imagen") %>' width="100%" Height="30%" class="card-img-top" ImageAlign="TextTop"  />                         
                            <div class="card-body">
                                <h4 class="card-title text-center" id="titulo">
                                    <strong><asp:Label ID="TituloLabel" runat="server" Text='<%# Eval("Titulo") %>' /></strong>
                                </h4>
                                <strong>Referencia:</strong>
                                <asp:Label ID="ReferenciaLabel" runat="server" Text='<%# Eval("Referencia") %>' class="card-text" />
                                <br />
                                <strong>Precio:</strong>
                                <asp:Label ID="PrecioLabel" runat="server" Text='<%# Eval("Precio") %>' class="card-text" />
                                <br />
                                <strong>Stock:</strong>
                                <asp:Label ID="Ca_actualLabel" runat="server" Text='<%# Eval("Ca_actual") %>' class="card-text"/>
                                <br />
                                <strong>Marca:</strong>
                                <asp:Label ID="NombremarcaLabel" runat="server" Text='<%# Eval("Nombre_marca") %>' class="card-text"/>
                                <br />
                                <strong>Categoria:</strong>
                                <asp:Label ID="Nombre_categoriaLabel" runat="server" Text='<%# Eval("Nombre_categoria") %>' class="card-text"/>  
                                <br />
                                <strong>Cantidad:</strong>
                                <asp:TextBox ID="TB_cantidad" runat="server" TextMode="Number" Class="card-text" Width="25%" CssClass="text-black" MaxLength="4"></asp:TextBox>                         
                                <asp:RequiredFieldValidator ID="RFV_cantidad" runat="server" ErrorMessage="*" ControlToValidate="TB_cantidad" EnableClientScript="True" ValidationGroup='<%# Eval("Id") %>'></asp:RequiredFieldValidator>&nbsp;&nbsp;
                                <asp:RangeValidator ID="RV_cantidad" runat="server" ErrorMessage="valor invalido" ControlToValidate="TB_cantidad" MaximumValue="1000" MinimumValue="1" Type="Integer" ValidationGroup='<%# Eval("Id") %>'></asp:RangeValidator>
                 
                                <asp:ImageButton class="center-block bottom-left" ID="BTNI_carritoAdd" runat="server" ImageUrl="~/ima/newproduct.png" CommandArgument='<%# Eval("Id") %>' ValidationGroup='<%# Eval("Id") %>' />
                                
                            </div>
               </div>    
          </div>                            
        </ItemTemplate>
    </asp:Repeater>
    </div>
    <br />
    <br />
    <br />

</asp:Content>

