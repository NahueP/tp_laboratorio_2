using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region Propiedades
        // <summary>
        /// Lectura y escritura lista de alumnos de la universidad/>.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        // <summary>
        /// Lectura y escritura lista de profesores de la universidad/>.
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        // <summary>
        /// Lectura y escritura lista de jornadas de la universidad/>.
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        /// <summary>
        /// Lectura y escritura para definir en jornadas con validacion
        /// </summary>
        /// <param name="i">Indice</param>
        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i < this.Jornadas.Count)
                {
                    return this.Jornadas[i];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (i >= 0 && i < this.Jornadas.Count)
                {
                    this.Jornadas[i] = value;
                }
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Serializa Universidad a un archivo Xml
        /// </summary>
        /// <param name="uni">Universidad</param>
        /// <returns>True si se realiza con exito, false caso contrario</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar((AppDomain.CurrentDomain.BaseDirectory + @"/Universidad.xml"), uni);
        }


        /// <summary>
        /// Muestra los datos de la universidad
        /// </summary>
        /// <param name="uni">Universidad</param>
        /// <returns>String de datos de la Universidad.</returns>
        private static string MostrarDatos(Universidad uni)
        {
            string retorno = "JORNADA: ";
            foreach (Jornada j in uni.Jornadas)
            {
                retorno += j.ToString() + "<-------------------------------------------------->\n";
            }
            return retorno;
        }

        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Comprueba si el alumno pasado no esta inscripto en la universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>True si el alumno no esta, false caso contrario</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Comprueba si el profesor pasado no esta inscripto en la universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">profesor</param>
        /// <returns>True si profesor no esta, false caso contrario</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor retorno = null;
            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor != clase)
                {
                    retorno = profesor;
                    break;
                }
            }
            return retorno;
        }

        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornada;
            Profesor profesor = (g == clase);
            jornada = new Jornada(clase, profesor);
            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == clase)
                {
                    jornada += alumno;
                }
            }
            g.Jornadas.Add(jornada);
            return g;
        }

        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return u;
        }

        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.Instructores.Add(i);
            }
            return u;
        }

        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno alumno in g.Alumnos)
            {
                if (a == alumno)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;
            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor == i)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor retorno = null;
            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor == clase)
                {
                    retorno = profesor;
                    break;
                }
            }

            if (retorno is null)
            {
                throw new SinProfesorException();
            }
            return retorno;
        }
        #endregion

       

        #region Contructores
        /// <summary>
        /// Constructor de universidad, incializa listas
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Instructores = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }
        #endregion

        

        #region Enumerados 
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion
    }
}
