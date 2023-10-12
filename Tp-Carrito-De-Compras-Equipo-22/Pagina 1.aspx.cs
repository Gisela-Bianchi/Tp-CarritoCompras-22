using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Tp_Carrito_De_Compras_Equipo_22
{
    public partial class Pagina_1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
     
            ArticuloNegocio negocio = new ArticuloNegocio();
            dgvArticulos.DataSource = negocio.listarConSP();
            dgvArticulos.DataBind();

        }
    }
}