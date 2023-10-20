<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tp_Carrito_De_Compras_Equipo_22.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            background-image: url('ruta_de_la_imagen_de_ofertas.jpg');
            background-size: cover;
            background-repeat: no-repeat;
        }
    </style>

    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function mostrarPopup() {
            var popup = document.getElementById('popup');
            popup.style.display = 'block';
            setTimeout(function () {
                popup.style.display = 'none';
            }, 3000); // Muestra el mensaje emergente durante 3 segundos
        }
    </script>
    <style>
        .popup {
            background-color: #FFF;
            border: 1px solid #333;
            padding: 10px;
            display: none;
            position: absolute;
            top: 10%;
            left: 91%;
            transform: translate(-50%, -50%);
            z-index: 999;
            width: max-content;
        }
    </style>
    <asp:ScriptManager ID="scriptManager" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>

            <nav class="navbar bg-body-tertiary mb-5">
                <div class="container-fluid">
                    <div class="d-flex" role="Search">
                        <asp:TextBox CssClass="form-control me-2" ID="TextBoxBuscar" runat="server"></asp:TextBox>
                        <asp:Button ID="ButtonAceptar" CssClass="btn btn-outline-success" runat="server" Text="Aceptar" OnClick="ButtonAceptar_Click1" />
                        </>
                    </div>
                </div>
            </nav>


            <div class="row row-cols-1 row-cols-md-3 g-4">

                <asp:Repeater runat="server" ID="repRepetidor" OnItemCommand="repRepetidor_ItemCommand">

                    <ItemTemplate>

                        <div class="col">
                            <div class="card">
                                <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="...">
                                <div class="card-body">
                                    <asp:Label ID="lblNombre" runat="server" Text='<%#Eval("Nombre")%>' CssClass="card-title"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblPrecio" runat="server" Text='<%#Eval("Precio")%>' CssClass="card-text"></asp:Label>
                                    <br />

                                    <asp:Button Text="Ver detalles" ID="buttonDetails" CssClass="btn btn-primary" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="buttonDetails_Click" />

                                    <asp:Button Text="Agregar al carrito" CssClass="btn btn-primary" runat="server" ID="btnAgregar" CommandName="AgregarAlCarrito" OnClick="buttonCarrito_Click" CommandArgument='<%#Eval("Id")%>' />
                                </div>
                            </div>
                        </div>

                    </ItemTemplate>

                </asp:Repeater>

            </div>
            <div id="popup" class="popup" style="display: none;">
                <p>Producto agregado al carrito con éxito</p>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

