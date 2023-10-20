<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Tp_Carrito_De_Compras_Equipo_22.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<style>

        .oculto{
            display: none;
        }
    </style>--%>
    <asp:GridView ID="dgvArticulo" DataKeyNames="Id" OnRowDeleting="dgvArticulo_RowDeleting" CssClass="table table-dark table-bordered"  runat="server" AutoGenerateColumns="false">
        <Columns>
            <%--<asp:BoundField HeaderText="Id" DataField="Id" HeaderStyle-cssClass="oculto" ItemStyle-CssClass="oculto" />--%>
            <asp:BoundField  HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:CommandField ShowDeleteButton="true" SelectText="Eliminar articulo" HeaderText="Accion" />
        </Columns>
    </asp:GridView>
    <a href="Default.aspx">volver</a>
</asp:Content>

