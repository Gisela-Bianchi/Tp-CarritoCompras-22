using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp_Carrito_De_Compras_Equipo_22
{
    public partial class Detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                ArticuloNegocio articulo = new ArticuloNegocio();
                dgvArticulo.DataSource = articulo.listar();
                dgvArticulo.DataBind();

            }
        }
    }
}