<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tp_Carrito_De_Compras_Equipo_22.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>gTro</h1>
  

   <div class="row row-cols-1 row-cols-md-3 g-4">
  <asp:Repeater  runat="server" id ="repRepetidor">
        <ItemTemplate>
              <div class="col">
            <div class="card">
              <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="...">
              <div class="card-body">
                <h5 class="card-title"><%#Eval("Nombre")%></h5>
                <p class="card-text"><%#Eval("Precio")%></p>
                  <a href="Detalle.aspx?id=<%#Eval("Id") %>">Ver Detalle</a>
                 <asp:button text="Agregar al carrito" cssclass="btn btn-primary" runat="server" Id="btnAgregar" CommandName="ArticuloId" OnClick="buttonClick" CommandArgument='<%#Eval("Id")%>'/> 
              </div>
            </div>
          </div>

</ItemTemplate>
</asp:Repeater>

 </div>

</asp:Content>
