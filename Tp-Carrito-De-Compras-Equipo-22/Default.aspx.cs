using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;


namespace Tp_Carrito_De_Compras_Equipo_22
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulo = negocio.listar();

            if (!IsPostBack)
            {
                repRepetidor.DataSource = ListaArticulo;
                repRepetidor.DataBind();
            }
        }

        protected void buttonCarrito_Click(object sender, EventArgs args)
        {
            string commandName = ((Button)sender).CommandName;
            string valor = ((Button)sender).CommandArgument;
            if (commandName == "AgregarAlCarrito")
            {
                Response.Redirect("Carrito.aspx?Id=" + valor);
            }

        }

        protected void buttonDetails_Click(object sender, EventArgs args)
        {
            string aux = ((Button)sender).CommandArgument;
            string commandName = ((Button)sender).CommandName;
            if (commandName == "ArticuloId") {
                Response.Redirect("Detalle.aspx?Id=" + aux);
            }
        }
    

    }
}