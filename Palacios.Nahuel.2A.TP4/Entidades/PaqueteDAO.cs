using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Atributos
        private static SqlCommand comando;
        private static SqlConnection conexion;
        #endregion

        #region Constructores
        static PaqueteDAO()
        {
            comando = new SqlCommand();
            conexion = new SqlConnection(Properties.Settings.Default.conexion);        
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Guarda paquete en la base de datos
        /// </summary>
        /// <param name="p">Objeto a insertar</param>
        /// <returns>True si se pudo insertar, en caso contrario false</returns>

        public static bool Insertar(Paquete p)
        {
            bool retorno = false;
            comando.CommandText = string.Format("INSERT INTO Paquetes values ('{0}','{1}','{2}')", p.DireccionEntrega, p.TrackingID, "Nahuel Palacios");
            comando.CommandType = CommandType.Text;
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                retorno = true;
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                conexion.Close();
            }

            return retorno;
        }
        #endregion 
    }
}
