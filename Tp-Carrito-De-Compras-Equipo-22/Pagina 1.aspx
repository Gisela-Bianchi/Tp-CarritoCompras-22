<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Pagina 1.aspx.cs" Inherits="Tp_Carrito_De_Compras_Equipo_22.Pagina_1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>LISTA DE ARTICULOS</h2>
    <asp:GridView ID="dgvArticulos" runat="server" CssClass="table" AutoGenerateColumns="false">
        <Columns>
             <asp:BoundField HeaderText="Id" DataField="Id" />
             <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
             <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
             <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
             <asp:BoundField HeaderText="IdMarca" DataField="Marca.Id" />
             <asp:BoundField HeaderText="Categoria" DataField="Categoria.Id" />
             <asp:BoundField HeaderText="Precio" DataField="Precio" />
             <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
            <asp:BoundField HeaderText="ImagenUrl" DataField="ImagenUrl" />
        </Columns>


    </asp:GridView>

</asp:Content>
