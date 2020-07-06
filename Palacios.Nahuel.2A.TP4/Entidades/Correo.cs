using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributos
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        #endregion

        #region Propiedades
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }
        #endregion

        #region Constructores
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Finaliza todos los hilos activos
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread t in this.mockPaquetes)
            {
                t.Abort();              
            }
        }

        /// <summary>
        /// Muestra todos los paquetes de un correo
        /// </summary>
        /// <param name="elemento"> Elemento</param>
        /// <returns> String con datos de los paquetes </returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Paquete p in ((Correo)elementos).paquetes)
            {
                sb.AppendLine(string.Format("{0} para {1} ({2}) \n", p.TrackingID, p.DireccionEntrega, p.Estado.ToString()));
            }

            return sb.ToString();
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        ///Controla si el paquete ya esta en la lista. En el caso de que esté, se lanza la excepción TrackingIdRepetidoException.
        ///Si no esta repetido, agrega el paquete a la lista de paquetes.
        ///Crea un hilo para el metodo MockCicloDeVida del paquete y agrega dicho hilo a mockPaquetes. Luego se ejecuta el hilo
        /// </summary>
        /// <param name="c">Correo</param>
        /// <param name="p">Paquete</param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {

            foreach (Paquete pack in c.paquetes)
            {
                if (pack == p)
                {
                    throw new TrackingIdRepetidoException("El Tracking ID: " + pack.TrackingID + " ya se encuentra en la lista.");
                }
            }

            c.paquetes.Add(p);

            Thread thread = new Thread(p.MockCicloDeVida);

            c.mockPaquetes.Add(thread);
            thread.Start();

            return c;
        }
        #endregion 

    }
}
