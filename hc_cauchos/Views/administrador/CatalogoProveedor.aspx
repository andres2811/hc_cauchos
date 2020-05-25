<%@ Page Title="" Language="C#" MasterPageFile="~/Views/administrador/admin.master" AutoEventWireup="true" CodeFile="~/Controllers/administrador/CatalogoProveedor.aspx.cs" Inherits="Views_administrador_CatalogoProveedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 302px;
        }
        .auto-style3 {
            width: 369px
        }
        .auto-style4 {
            width: 68%
        }
        .auto-style5 {
            width: 470px
        }
        .auto-style6 {
            width: 222px;
        }
        .auto-style8 {
            width: 218px;
        }
        .auto-style10 {
            width: 214px;
        }
        </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       
          <h1 class="text-center text-primary"><strong>Catalogo Proveedor <br /> <small>Seleccione el proveedor</small></strong></h1>
            <div class="row">
                <div class="col-md-4 col-md-offset-4">
                    <div class="form-group">
                        <asp:ObjectDataSource ID="ODS_Proveedor" runat="server" SelectMethod="ColsultarProveedor" TypeName="DAOAdmin"></asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="ODS_BuscarReferencia" runat="server" SelectMethod="ConsultarReferenciaProductoProveedor" TypeName="DAOAdmin">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="DDL_Proveedor" Name="pro" PropertyName="SelectedValue" Type="Int32" />
                                <asp:ControlParameter ControlID="TB_Buscar_Referencia" Name="refe" PropertyName="Text" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <br />
                        <table class="nav-justified">
                            <tr>
                                <td>
                        <asp:DropDownList ID="DDL_Proveedor" runat="server" Class="form-control" DataSourceID="ODS_Proveedor" DataTextField="Nombre_pro" DataValueField="Id" OnSelectedIndexChanged="DDL_Proveedor_SelectedIndexChanged" ValidationGroup="b"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" InitialValue="0" ControlToValidate="DDL_Proveedor" ValidationGroup="b"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                        
                        <asp:Button ID="Button1" class="btn btn-default" runat="server"  OnClick="Button1_Click" Text="Ver" ValidationGroup="b" />
                                </td>
                            </tr>
                        </table>
                      

                    </div>
                </div>
            </div>

    <div class ="col-md-4 col-md-offset-4">
       <table class="nav-justified">
           <tr>
               <td class="auto-style6">
                   <asp:TextBox ID="TB_Buscar_Referencia" Class="form-control" runat="server" Placeholder="Referencia" Width="175px" Visible="false"></asp:TextBox>
                  
               </td>
              
               <td>
                   <asp:Button ID="Btn_Filtrar" runat="server" CssClass="btn btn-default" Text="Buscar" Visible="False" OnClick="Btn_Filtrar_Click" />
               </td>
               <td>
                   <asp:Button ID="Btn_Todos" runat="server" CssClass="btn btn-default" Text="Todos" Visible="false" OnClick="Btn_Todos_Click" />
               </td>
           </tr>
       </table>
       </div>



    <div class="row">
        <div class=" col-lg-12 col-md-offset-0.5">
             <div style="overflow-x:auto; width:100%;">  
                 <table class="table table-responsive">
                          <thead>
                            <tr>
                              <th scope="col"><h3>Referencia</h3></th>
                              <th scope="col"><h3>Nombre</h3></th>
                              <th scope="col"><h3>Precio</h3></th>
                              <th scope="col"><h3>Cantidad</h3></th>
                              <th scope="col"><h3>Agregar</h3></th>
                              <th scope="col"><h3>Precio Total</h3></th>
                            </tr>
                          </thead>
                          <tbody>
                              <asp:Repeater ID="Repeater1" runat="server"  OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound"  >
                                  <ItemTemplate>
                                    <tr>
                                        
                                        <td><asp:Label ID="Lb_Referencia"  class="" runat="server" Text='<%# Eval("Referencia") %>' ></asp:Label></td>
                                        <asp:Label ID="LB_id_producto" runat="server" Text='<%# Eval("Producto_id") %>' Visible="False"></asp:Label>
                                        <td><asp:Label ID="Lb_Nombre"  class="" runat="server" Text='<%# Eval("Nombre_producto") %>' ></asp:Label></td>
                                        <td><asp:Label ID="Lb_Precio" Class="" runat="server"  Text='<%# Eval("Precio") %>' Width="100%" ></asp:Label></td>
                                        <td><asp:TextBox ID="TB_Cantidad" class="form-control" runat="server" placeholder="Cantidad" Width="100px" MaxLength="3"  TextMode="Number"></asp:TextBox> </td>
                                        <td><asp:Button ID="Btn_Agregar" Class="btn btn-success" runat="server" Text="Agregar"  UseSubmitBehavior="False" ValidationGroup="a" /></td>
                                        <td><asp:Label ID="LB_Total_Producto" Class="form-control" runat="server"  Text='Precio' Width="100%" ></asp:Label></td>
                                        <asp:Label ID="Lb_aux" runat="server" Text="" Visible="false"></asp:Label>
                                    </tr> 
                                    <tr>
                                          <td><asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Cantidad no valida" MaximumValue='999' MinimumValue="1" ControlToValidate="TB_Cantidad" ValidationGroup="a" Type="Integer"></asp:RangeValidator></td>
                                    </tr>
                                </ItemTemplate>
                                  <FooterTemplate>

                                  </FooterTemplate>
                            </asp:Repeater>             
                          </tbody>
                        </table>        
                </div>
            </div>
        </div>

    <div class="row">
        <div class="col-md-0.1 col-md-offset-6">
            <br />
            <table class="auto-style4">
                <tr>
                    <td class="auto-style5">Precio Total : </td>
                    <td class="auto-style3"><asp:Label ID="Lb_total" runat="server" Class="form-control-static" Visible="False"></asp:Label>
                    </td>
                    <td>
            <asp:Button ID="Btn_Enviar" class="btn btn-primary" runat="server" Text="Enviar Pedido" OnClick="Btn_Enviar_Click" Visible="False"  />
                    </td>
                    <td> <asp:Button ID="Btn_Cancelar" Class="btn btn-danger" runat="server" Text="Cancelar" OnClick="Btn_Cancelar_Click1" Visible="False" /></td>
                </tr>
            </table>
        </div>
    </div>
    
<asp:ObjectDataSource ID="ODS_productos" runat="server" SelectMethod="ConsultarProductoProveedor" TypeName="DAOAdmin">
    <SelectParameters>
        <asp:ControlParameter ControlID="DDL_Proveedor" Name="pro" PropertyName="SelectedValue" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
</asp:Content>

