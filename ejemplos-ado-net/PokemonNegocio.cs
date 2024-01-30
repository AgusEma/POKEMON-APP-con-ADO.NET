using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Incluyo libreria que me permite manipular objetos para establecer la conexion
//a base de datos:
using System.Data.SqlClient;

namespace ejemplos_ado_net
{
    //Clase para crear los metodos de acceso a datos para los Pokemons
    internal class PokemonNegocio
    {
        //Metodo para LEER registros de la base de datos:
        public List<Pokemon> listar()
        {
            List<Pokemon> lista = new List<Pokemon>();
            //Para conectarme:
            SqlConnection conexion = new SqlConnection();
            //Para realizar acciones:
            SqlCommand comando = new SqlCommand();
            //Donde voy a albergar los datos:
            SqlDataReader lector; //No se debe crear una instancia de lector.
            try
            {
                //Configuracion de la cadena de conexion:
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true";
                //Indico o inyecto la secuencia SQL que quiero ejecutar:
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Numero, Nombre, Descripcion, UrlImagen From POKEMONS";
                //Le digo que ejecute ese comando en esta conexion:
                comando.Connection = conexion;

                //Abro la conexion:
                conexion.Open();
                //Realizo la lectura,..ExecuteReader() devuelve un SqlDataReader, lo guardo en lector:
                lector = comando.ExecuteReader(); //Obtengo TODOS los datos en mi variable lector.

                //Con un while voy a transformar la tabla del lector en la coleccion de objetos Pokemon:
                while(lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Numero = lector.GetInt32(0);
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.UrlImagen = (string)lector["UrlImagen"];

                    lista.Add(aux);
                }

                conexion.Close();
                return lista;   
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
