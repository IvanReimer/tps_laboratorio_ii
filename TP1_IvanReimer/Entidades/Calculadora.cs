using System;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Dicho método valida que un operador pasado por parámetro
        /// sea +,-,* o /
        /// </summary>
        /// <param name="operador">El operador a validar</param>
        /// <returns>El operador validado, caso contrario, devuelve +</returns>
        private static char ValidarOperador(char operador)
        {
            char operadorRetorno;
            switch (operador)
            {
                case '-':
                    operadorRetorno= '-';
                    break;
                case '*':
                    operadorRetorno = '*';
                    break;
                case '/':
                    operadorRetorno = '/';
                    break;
                default:
                    operadorRetorno = '+';
                    break;
            }
            return operadorRetorno;
        }
        /// <summary>
        /// Valida que el operador pasado por parámetro se corresponda con +, -, /, *.
        /// Además, realiza la operación de los operandos pasados por parámetro.
        /// </summary>
        /// <param name="num1">Primer operando</param>
        /// <param name="num2">Segundo operando</param>
        /// <param name="operador">Operador en formato char a validar y luego operar</param>
        /// <returns>La operación entre los dos operandos pasados por parámetro</returns>
        public static double Operar(Operando num1 , Operando num2 , char operador )
        {
            double retorno = 0;
            switch (Calculadora.ValidarOperador(operador))
            {
                case '-':
                    retorno = num1 - num2;
                    break;
                case '*':
                    retorno = num1 * num2;
                    break;
                case '/':
                    retorno = num1 / num2;
                    break;
                default:
                    retorno = num1 + num2;
                    break;
            }
            return retorno;
        }


    }
}
