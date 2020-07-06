using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardarString
    {

        #region Metodo Extension
        /// <summary>
        /// Guarda archivo de texto en el escritorio
        /// </summary>
        /// <param name="texto">Texto a guardar</param>
        /// <param name="archivo">Nombre del archivo</param>
        /// <returns>True si se pudo guardar, false en caso contraio</returns> 

        public static bool Guardar(this string texto, string archivo)
        {
            bool retorno = true;
            string direccion = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + archivo;

            try
            {
                if(File.Exists(direccion))
                {
                    using (StreamWriter sw = new StreamWriter(direccion, true))
                    {
                        sw.WriteLine(texto);
                    }
                }
                else
                {
                    using (StreamWriter sw = new StreamWriter(direccion, false))
                    {
                        sw.WriteLine(texto);
                    }
                }
            }
            catch(Exception e)
            {
                retorno = false;

            }
            


            return retorno;
        }
        #endregion
    }
}
