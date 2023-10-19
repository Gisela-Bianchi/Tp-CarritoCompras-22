<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="Tp_Carrito_De_Compras_Equipo_22.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="dgvArticulo" CssClass="table table-bordered" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
        </Columns>
    </asp:GridView>
    <a href="Default.aspx">volver</a>
</asp:Content>
