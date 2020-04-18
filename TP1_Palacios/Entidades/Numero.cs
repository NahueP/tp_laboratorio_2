using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Atributos
        private double numero;
        #endregion

        #region Propiedades
        public string SetNumero
        {
            set { this.numero = ValidarNumero(value); }
        }
        #endregion

        #region Constructores
        public Numero() : this(0)
        {

        }

        public Numero(double numero) : this(numero.ToString())
        {

        }

        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }
        #endregion

        #region Metodos y Sobrecargas

        private double ValidarNumero(string strNumero)
        {
            double retorno = 0;

            double.TryParse(strNumero, out retorno);

            return retorno;

        }
        

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            return n1.numero / n2.numero;
        }


        public string BinarioDecimal(string binario)
        {
            string retorno = "valor invalido";

            bool valido = true;

            foreach (var c in binario)
            {
                if (c != '0' && c != '1')
                {
                    valido = false;
                }
            }
            if (valido == true)
            {
                retorno = Convert.ToInt32(binario, 2).ToString();
            }
            return retorno;
        }

        
        public string DecimalBinario(double numero)
        {
            return DecimalBinario(numero.ToString());
        }

        
        public string DecimalBinario(string numero)
        {
            string retorno = "valor invalido";

            decimal value;

            uint value2;

            if (Decimal.TryParse(numero, out value))
            {
                if (UInt32.TryParse(numero, out value2))
                { 
                    retorno = Convert.ToString(Convert.ToInt32(numero, 10), 2);
                }
            }

            return retorno;
        }

        #endregion

    }
}
