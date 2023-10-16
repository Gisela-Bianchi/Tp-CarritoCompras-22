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
            
        }

        protected void buttonDetails_Click(object sender, EventArgs args)
        {
            string aux = ((Button)sender).CommandArgument;
            string commandName = ((Button)sender).CommandName;
            if (commandName == "ArticuloId") {
                Response.Redirect("Detalle.aspx?Id=" + aux);
            }
        }

        protected void repRepetidor_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName == "AgregarAlCarrito")
            {
                if (Session["articulo"] == null) {

                    Session["articulo"] = crearTabla();
                }
                Label Nombre=e.Item.FindControl("lblNombre") as Label;
                string NombreArticulo = Nombre.Text;
                string Precio = ((Label)e.Item.FindControl("lblPrecio")).Text;
                agregarFila((DataTable)Session["articulo"],NombreArticulo,Convert.ToDecimal(Precio));
            }
        }
        public DataTable crearTabla()
        {
            DataTable dt = new DataTable();
            DataColumn columna = new DataColumn("Nombre", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            columna = new DataColumn("Precio", System.Type.GetType("System.Decimal"));
            dt.Columns.Add(columna);

            return dt;
        }

        public void agregarFila(DataTable tabla, string nomProd, decimal precio)
        {
            DataRow dr = tabla.NewRow();
            
            dr["Nombre"] = nomProd;
           
            dr["Precio"] = precio;
            tabla.Rows.Add(dr);
        }
    }
}