using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IMostrar<T>
    {
        /// <summary>
        /// Muestra los datos de las clases que implementan esta interfaz (correo y paquete)
        /// </summary>
        /// <param name="elemento">El elemento a mostrar</param>
        /// <returns>Sring con los datos</returns>
        string MostrarDatos(IMostrar<T> elemento);

    }
}
