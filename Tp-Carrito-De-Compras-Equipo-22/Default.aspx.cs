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

        protected void buttonClick (object sender, EventArgs args)
        {
            string valor = ((Button)sender).CommandArgument;
            
        }
        /*protected void buttonClick(object sender, EventArgs e)
        {
            string aux = ((Button)sender).CommandArgument;
            Response.Redirect("Detalle.aspx?ArticuloId=" + aux);
        }*/
    }
}