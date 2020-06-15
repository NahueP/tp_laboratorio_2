using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {
        /// <summary>
        /// Guarda los datos
        /// </summary>
        /// <param name="archivo">Ruta</param>
        /// <param name="datos">Datos a guardar </param>
        /// <returns>True si el archivo se guardo, false caso contrario</returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Lee el archivo con los datos
        /// </summary>
        /// <param name="archivo">Ruta</param>
        /// <param name="datos">Datos leidos</param>
        /// <returns>True si el archivo pudo leerse, false caso contrario</returns>
        bool Leer(string archivo, out T datos);
    }
}
