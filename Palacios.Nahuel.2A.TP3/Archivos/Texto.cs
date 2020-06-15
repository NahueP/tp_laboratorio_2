using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto
    {
        /// <summary>
        /// Guarda la cadena especificada en un archivo de Texto.
        /// </summary>
        /// <param name="archivo">Ruta al archivo.</param>
        /// <param name="datos">Datos a guardarse en el archivo.</param>
        /// <returns>True si el archivo se guardo con exito. Caso contrario se lanza "ArchivosException".</returns>
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;
            try
            {
                using (StreamWriter stream = new StreamWriter(archivo, false))
                {
                    stream.Write(datos);
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }

        /// <summary>
        /// Lee un archivo de Texto y retorna los datos.
        /// </summary>
        /// <param name="archivo">Ruta al archivo.</param>
        /// <param name="datos">Parametro de salida que contiene los datos leidos del archivo.</param>
        /// <returns>True si logro leerse el archivo. Caso contrario lanza "ArchivosException".</returns>
        public bool Leer(string archivo, out string datos)
        {
            datos = "";
            bool retorno = false;
            try
            {
                using (StreamReader stream = new StreamReader(archivo))
                {
                    datos = stream.ReadToEnd();
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }
    }
}
