using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;
using Dominio;

namespace Tp_Carrito_De_Compras_Equipo_22
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                dgvArticulo.DataSource = (DataTable)Session["articulo"];
                dgvArticulo.DataBind();
            }
        }

        protected void dgvArticulo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;

            // elimina el artículo.
            DataTable dt = (DataTable)Session["articulo"];
            dt.Rows[rowIndex].Delete();
            Session["articulo"] = dt;

          //Actualiza grilla
            dgvArticulo.DataSource = dt;
            dgvArticulo.DataBind();
          
        }
    }
}