<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="Default.aspx.cs" Inherits="WASiigo.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link rel="stylesheet"
        href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
        integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T"
        crossorigin="anonymous">
    <script
        src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"
        integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1"
        crossorigin="anonymous"></script>
    <script
        src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script
        src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"
        integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM"
        crossorigin="anonymous"></script>
    <title>Test Services Siigo</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Desarrolladores Aplicación</h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:GridView ID="GridView2"
                CssClass="table table-striped table-bordered table-hover"
                runat="server"
                DataKeyNames="Id"
                AutoGenerateColumns="False"
                ShowFooter="False"
                CellPadding="4"
                ForeColor="#333333"
                GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Primer Nombre">
                        <ItemTemplate>
                            <asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("FirstName") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Apellidos">
                        <ItemTemplate>
                            <asp:Label ID="lblLastName" runat="server" Text='<%#Eval("LastName") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Activo">
                        <ItemTemplate>
                            <asp:Label ID="lblActive" runat="server" Text='<%#Eval("IsActive") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#ffffff" ForeColor="Blue" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>

        <div class="container">
            <h2>Productos</h2>
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
                Crear Producto
            </button>
            <asp:GridView ID="GridView1"
                CssClass="table table-striped table-bordered table-hover"
                runat="server"
                DataKeyNames="Id"
                AutoGenerateColumns="False"
                ShowFooter="False"
                OnRowDeleting="GridView1_RowDeleting"
                CellPadding="4"
                ForeColor="#333333"
                GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" Text="Eliminar" CssClass="btn btn-danger" CommandName="Delete" ToolTip="Delete" OnClientClick="return confirm('¿Estas seguro de eliminar este producto?');" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Identificación">
                        <ItemTemplate>
                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Codigo">
                        <ItemTemplate>
                            <asp:Label ID="lblCode" runat="server" Text='<%#Eval("Code") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Descripción">
                        <ItemTemplate>
                            <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Costo">
                        <ItemTemplate>
                            <asp:Label ID="lblCost" runat="server" Text='<%#Eval("Cost") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#ffffff" ForeColor="Blue" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <!-- Modal -->
            <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Crear Producto</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <label for="text-codigo">Codigo</label>
                                    <input type="text" runat="server" class="form-control" id="txtCode" placeholder="Codigo del producto" />
                                </div>
                                <div class="form-group col-md-6">
                                    <label for="text-descripcion">Descripción</label>
                                    <input type="text" runat="server" class="form-control" id="txtDescription" placeholder="Descripcion del producto" />
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <label for="text-referencia">Referencia</label>
                                    <input type="text" runat="server" class="form-control" id="txtReference" placeholder="Referencia del producto" />
                                </div>
                                <div class="form-group col-md-6">
                                    <label for="text-tipo-producto">Tipo producto</label>
                                    <select class="form-control" runat="server" id="txtTypeProduct">
                                        <option value="" selected="selected">Seleccione</option>
                                        <option value="ProductType_Consumer">ProductType_Consumer</option>
                                        <option value="ProductType_Product">ProductType_Product</option>
                                        <option value="ProductType_Service">ProductType_Service</option>
                                    </select>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <label for="text-unidad-medida">Unidad Medida</label>
                                    <select class="form-control" runat="server" id="txtMedyUnit">
                                        <option value="" selected="selected">Seleccione</option>
                                        <option value="Unidades">Unidad</option>
                                        <option value="Kg">Kg</option>
                                        <option value="Litros">Litros</option>
                                    </select>
                                </div>
                                <div class="form-group col-md-6">
                                    <label for="text-codigo-producto">Codigo Barras</label>
                                    <input type="text" runat="server" class="form-control" id="txtBarCode" placeholder="Codigo Barras" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="text-comentarios">Comentarios</label>
                                <input type="text" runat="server" class="form-control" id="txtComentary" placeholder="Comentario producto" />
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <label for="text-costo-producto">Costo</label>
                                    <input type="number" runat="server" class="form-control" id="txtCost" />
                                </div>
                                <div class="form-group col-md-6">
                                    <label for="text-estado-producto">Estado</label>
                                    <select class="form-control" runat="server" id="txtStatus">
                                        <option value="" selected="selected">Seleccione</option>
                                        <option value="0">No Habilitado</option>
                                        <option value="1">Habilitado</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                            <asp:Button ID="btnCreate" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnCreate_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <!-- Modal -->



            <!-- Modal Out Put -->
            <div class="modal fade" id="modal-out-put" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="titulo-mensaje-salida"></h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div id="mensaje-salida"></div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-primary" data-dismiss="modal">Aceptar</button>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Modal Out Put -->
        </div>
    </form>
</body>
</html>
