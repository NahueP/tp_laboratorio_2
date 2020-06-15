using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos
        private int legajo;
        #endregion

        #region Polimorfismo
        /// <summary>
        /// Verifica si esta instancia y un objeto especificado son iguales.
        /// </summary>
        /// <param name="obj">Instancia a verificar.</param>
        /// <returns>Retorna True si son del mismo tipo, mismo DNI y Legajo, caso contrario False.</returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Universitario)
            {
                if (this == (Universitario)obj)
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        #endregion

        #region Constructores
        public Universitario()
        {
        }


        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Firma de método abstracto.
        /// </summary>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Muestra los datos de la case 
        /// </summary>
        /// <returns>Retorna una cadena con todos los datos de la clase.</returns>
        protected virtual string MostrarDatos()
        {
            return (base.ToString() + "\nLEGAJO NUMERO: " + this.legajo);
        }
        #endregion

        #region Sobrecarga de operadores
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {


            return pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI;
            

           
        }

        
        public static bool operator !=(Universitario u1, Universitario u2)
        {
            return !(u1 == u2);
        }
        #endregion
    }
}
