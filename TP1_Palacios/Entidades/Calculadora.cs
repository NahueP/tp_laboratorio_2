using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        #region Metodos
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = 0;

            switch (ValidarOperador(operador))
            {
                case "+":
                    retorno = (num1 + num2);
                    break;

                case "-":
                    retorno = (num1 - num2);
                    break;

                case "/":
                    retorno = (num1 / num2);

                    if (double.IsInfinity(retorno))
                    {
                        retorno = double.MinValue;
                    }
                    break;

                case "*":
                    retorno = (num1 * num2);
                    break;

                default:
                    break;
            }

            return retorno;

        }
        

        private static string ValidarOperador(string operador)
        {
            string retorno = "+";

            if(operador == "+" || operador == "-" || operador == "*" || operador == "/")
            {
                retorno = operador;
            }

            return retorno;

        }

        #endregion
    }
}
