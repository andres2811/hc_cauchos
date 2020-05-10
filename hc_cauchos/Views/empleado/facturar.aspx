<%@ Page Title="" Language="C#" MasterPageFile="~/Views/empleado/empleado.master" AutoEventWireup="true" CodeFile="~/Controllers/empleado/facturar.aspx.cs" Inherits="Views_empleado_facturar" %>

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
    <h1 class="text-center"><strong>FACTURACION</strong></h1>
    <asp:TextBox ID="TB_NomCliente" runat="server" CssClass="form-control-static" placeholder="Cedula Cliente A Buscar"></asp:TextBox>
    <asp:Button ID="BTN_BuscarClien" runat="server" Text="Buscar" class="btn btn-primary" OnClick="BTN_BuscarClien_Click"/>
    <asp:Button ID="BTN_buscarTodos" runat="server" Text="Todos" CssClass="btn btn-primary" OnClick="BTN_buscarTodos_Click"/>
    <asp:Button ID="BTN_RegistrarCliente" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClick="BTN_RegistrarCliente_Click"/>
    <br />
    <br />
        <asp:GridView ID="GV_Clientes" class="table table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="User_id" DataSourceID="ODS_Clientes" Width="100%" AllowPaging="True" PageSize="5" ForeColor="White" BackColor="#464646">
           <Columns>
                <asp:BoundField DataField="User_id" HeaderText="Identificador" SortExpression="User_id" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
                <asp:BoundField DataField="Identificacion" HeaderText="Identificacion" SortExpression="Identificacion" />
            </Columns>

            <HeaderStyle BackColor="Black" />

        </asp:GridView>
        <asp:ObjectDataSource ID="ODS_Clientes" runat="server" SelectMethod="ObtenerClientes" TypeName="DAOEmpleado"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ODS_ClientesCedu" runat="server" SelectMethod="ObtenerClientesCedula" TypeName="DAOEmpleado">
        <SelectParameters>
            <asp:ControlParameter ControlID="TB_NomCliente" Name="cedula" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <h1 class="text-center"><strong>PRODUCTOS</strong></h1>
    <br />
    <br />
    <asp:ObjectDataSource ID="ODS_catalogo" runat="server" SelectMethod="ConsultarInventario" TypeName="DAOUser"></asp:ObjectDataSource>
    <div class="row ">      
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ODS_catalogo" >
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
                                <asp:TextBox ID="TB_cantidad" runat="server" TextMode="Number" Class="card-text" Width="25%" CssClass="text-black" MaxLength="4"></asp:TextBox>                         
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

