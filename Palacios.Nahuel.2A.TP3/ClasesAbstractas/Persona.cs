using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace ClasesAbstractas
{
    public abstract class Persona
    {

        #region Enumerados      
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }
        #endregion

        #region Atributos       
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad L/E Apellido con validacion
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            
            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
                
        }

        /// <summary>
        /// Propiedad L/E DNI con validacion
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }

            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }

        }

        /// <summary>
        /// Propiedad L/E Nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }

            set
            {
                this.nacionalidad = value;
            }

        }

        /// <summary>
        /// Propiedad L/E Nombre con validacion
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }

            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }

        }

        /// <summary>
        /// Propiedad L/E StringToDNI con validacion
        /// </summary>
        public string StringToDNI
        {

            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }

        }
        #endregion

        #region Constructores
        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo ToString con todos los datos de la persona
        /// </summary>
        /// <returns>Retorna una cadena con todos los datos</returns>
        public override string ToString()
        {
            return "NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre + "\nNACIONALIDAD: " + this.Nacionalidad;
        }

        /// <summary>
        /// Valida dni por nacionalidad.
        /// </summary>
        /// /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        /// <param name="dato">Numero del DNI a validar.</param>
        /// <returns>Retorna dni validado, caso contrario lanza NacionalidadInvalidaException.</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            return this.ValidarDni(nacionalidad, dato.ToString());
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int retorno = 0;
            int auxDato;

            if (dato.Length > 0 && dato.Length < 9 && int.TryParse(dato, out auxDato))
            {
                auxDato = int.Parse(dato);

                if (nacionalidad == ENacionalidad.Argentino)
                {
                    if (auxDato >= 1 && auxDato <= 89999999)
                    {
                        retorno = auxDato;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException();
                    }
                }
                else
                {
                    if (nacionalidad == ENacionalidad.Extranjero)
                    {
                        if (auxDato >= 90000000 && auxDato <= 99999999)
                        {
                            retorno = auxDato;
                        }
                        else
                        {
                            throw new NacionalidadInvalidaException();
                        }
                    }
                }

            }
            else
            {
                throw new DniInvalidoException();
            }

            return retorno;
        }


        /// <summary>
        /// Valida caracteres de los atributos nombre y apellido
        /// </summary>
        /// /// <param name="dato">Cadena a validar</param>
        /// <returns>Retorna la cadena en caso de que sea valido, caso contrario retorna null</returns>
        private string ValidarNombreApellido(string dato)
        {
            bool flag = true;

            string retorno = null;

            foreach (char item in dato)
            {
                if (!(Char.IsLetter(item)))
                {
                    flag = false;
                    break;
                }
            }
            if (flag == true)
            {
                retorno = dato;
            }
            return retorno;
        }
        #endregion

    }
}
