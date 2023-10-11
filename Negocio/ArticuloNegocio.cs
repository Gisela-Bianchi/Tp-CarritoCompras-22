using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using Negocio;
namespace Negocio
{
    public class ArticuloNegocio
    {
        //esta funcion la creo para buscar el Id de imagen y relacionarlo con articulo
        public string BuscarUrl(int Id)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.SetearConsulta($"select ImagenUrl from IMAGENES where IdArticulo ={Id}");
                datos.EjecutarLectura();

                string Url = "";
                while (datos.Lector.Read())
                {
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        Url = (string)datos.Lector["ImagenUrl"];

                }

                return Url;
            }
            catch (Exception ex)

            {
                throw ex;
            }

            finally
            {
                datos.CerrarConexion();
            }
        }
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();


            try
            {

                datos.SetearConsulta("select A.Id,Codigo,Nombre,A.Descripcion,IdMarca,IdCategoria,Precio,C.Descripcion Tipo, M.Descripcion Marca, ImagenUrl from ((ARTICULOS A join MARCAS M on A.IdMarca=M.Id)join CATEGORIAS C on C.Id=A.IdCategoria) join IMAGENES I on I.IdArticulo=A.Id ");
                datos.EjecutarLectura();


                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    if (!(datos.Lector["Id"] is DBNull))
                        aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    aux.Tipo = new Categoria();
                    if (!(datos.Lector["Id"] is DBNull))
                        aux.Tipo.Id = (int)datos.Lector["Id"];
                    aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];

                    aux.Marca = new Marca();
                    if (!(datos.Lector["Id"] is DBNull))
                        aux.Marca.Id = (int)datos.Lector["Id"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                   // aux.Imagen=new Imagen();
                   // aux.Imagen.Id = (int)datos.Lector["Id"];
                   // aux.Imagen.IdArticulo = (int)datos.Lector["Id Articulos"];
                    aux.ImagenUrl = BuscarUrl(aux.Id);
                    lista.Add(aux);

                }

                return lista;
            }
            catch (Exception ex)

            {
                throw ex;
            }

            finally
            {
                datos.CerrarConexion();

            }
        }
        public List<Articulo> listarUnico(string Nombre)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();


            try
            {

                datos.SetearConsulta("select A.Id,Codigo,Nombre,A.Descripcion,IdMarca,IdCategoria,Precio,C.Descripcion Tipo," +
                " M.Descripcion Marca, ImagenUrl from ((ARTICULOS A join MARCAS M on A.IdMarca=M.Id)join CATEGORIAS C on C.Id=A.IdCategoria) " +
                $"join IMAGENES I on I.IdArticulo=A.Id where A.Nombre LIKE '{Nombre}%'");
                datos.EjecutarLectura();



                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Tipo = new Categoria();//instancia
                    aux.Tipo.Id = (int)datos.Lector["Id"];
                    aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];


                    aux.ImagenUrl = BuscarUrl(aux.Id);
                    lista.Add(aux);
                }


                return lista;
            }
            catch (Exception ex)

            {
                throw ex;
            }

            finally
            {
                datos.CerrarConexion();

            }


        }


        public void AgregarArticulo(Articulo articulo)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion,Precio, IdMarca, IdCategoria) values('" + articulo.Codigo + "', '" + articulo.Nombre + "', '" + articulo.Descripcion + "','" + articulo.Precio + "',@IdMarca,@IdCategoria)");
                datos.setearParametro("@IdMarca", articulo.Marca.Id);
                datos.setearParametro("@IdCategoria", articulo.Tipo.Id);

                datos.EjecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                datos.CerrarConexion();
            }
        }
        public void ModificarArticulo(Articulo articulo)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
               
                datos.SetearConsulta("update ARTICULOS set Codigo=@codigo, Nombre=@nombre, Descripcion=@descripcion,Precio=@precio, IdMarca=@idmarca , IdCategoria=@idcategoria where Id=@id");
      
                datos.setearParametro("@codigo", articulo.Codigo);
                datos.setearParametro("@nombre", articulo.Nombre);
                datos.setearParametro("@descripcion", articulo.Descripcion);
                datos.setearParametro("@precio", articulo.Precio);             
                datos.setearParametro("@IdMarca", articulo.Marca.Id);
                datos.setearParametro("@IdCategoria", articulo.Tipo.Id);
                datos.setearParametro("@id", articulo.Id);
            
                datos.EjecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                datos.CerrarConexion();
            }
        }

        public void EliminarArticulo( int id)
        {

            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.SetearConsulta("delete from ARTICULOS where id = @id");
                datos.setearParametro("@id", id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex ;
            }
        }

    }
}

     
    

