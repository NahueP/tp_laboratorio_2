using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Atributo
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Costructores

        public Alumno()
        {
        }

        
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muetra los datos del alumno y cuotas
        /// </summary>
        /// <returns>Retorna cadena con datos</returns>
        protected override string MostrarDatos()
        {
            string estado = estadoCuenta.ToString();
            if (this.estadoCuenta == EEstadoCuenta.AlDia)
            {
                estado = "Cuota al dia";
            }
            return (base.MostrarDatos() + "\nESTADO DE CUENTA: " + estado + this.ParticiparEnClase());
        }

        /// <summary>
        /// Muestra la clase que toma el alumno
        /// </summary>
        /// <returns>Retorna cadena con la clase que toma</returns>
        protected override string ParticiparEnClase()
        {
            return ("\nTOMA CLASE DE: " + this.claseQueToma);
        }

        /// <summary>
        /// Hace publicos los datos del alumno
        /// </summary>
        /// <returns>Retorna metodo MostrarDatos</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region sobrecarga de operadores
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor);
        }

      
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return (a.claseQueToma != clase);
        }


        #endregion


        #region Enumerado 
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        #endregion

    }
}
