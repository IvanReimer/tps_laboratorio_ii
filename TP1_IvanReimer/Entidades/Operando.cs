using System;
using System.Text;


namespace Entidades
{
    public class Operando
    {
        private double numero;

        #region Constructores
        /// <summary>
        /// Constructor por defecto, inicializa el atributo número en 0
        /// </summary>
        public Operando() : this(0)
        {
            
        }
        /// <summary>
        /// Constructor en el que se le asigna un numero a su único atributo
        /// </summary>
        /// <param name="numero">Numero al que se le asigna su valor al único atributo</param>
        public Operando(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// Dicho constructor, intenta parsear el String pasado por parámetro a 
        /// un número. Si el parámetro no es un número, se le asigna un 0
        /// </summary>
        /// <param name="strNumero">Número a validar y asignar a único atributo.</param>
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de sólo escritura. Valida que el valor sea un número y se lo asigna al 
        /// atributo, caso contrario le asigna un 0.
        /// </summary>
        public String Numero
        {
            set
            {
                this.numero = this.ValidarOperando(value);
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Valida que un String pasado por parámetro sea binario.
        /// Es decir, que tenga solo 1 y 0.
        /// </summary>
        /// <param name="binario">El string a validar</param>
        /// <returns>True en caso que sea binario, False caso contrario</returns>
        private Boolean EsBinario(String binario)
        {
            Boolean noEsBinario = false;
            foreach (char numero in binario)
            {
                if (numero != '0' && numero != '1')
                {
                    noEsBinario = true;
                    break;
                }
            }
            return !noEsBinario;
        }
        /// <summary>
        /// Convierte un numero binario pasado por parámetro a decimal.
        /// Este método valida además, que el parametro sea binario.
        /// </summary>
        /// <param name="numeroEntero">String pasado por parámetro a validar.</param>
        /// <returns>El valor pasado por parametro, convertido a binario, Valor invalido caso contrario</returns>
        public String BinarioDecimal(String numeroEntero)
        {
            String retorno = "Valor inválido";
            if (this.EsBinario(numeroEntero))
            {
                int valorAOperar = int.Parse(numeroEntero);
                int numeroDecimal = 0;
                int contador = 0;
                while (valorAOperar >= 1)
                {
                    numeroDecimal += (valorAOperar % 10) * (int)Math.Pow(2, contador);
                    valorAOperar /= 10;
                    contador++;
                }
                retorno = numeroDecimal.ToString();
            }
            return retorno;
        }
        /// <summary>
        /// Convierte un String decimal a binario.
        /// Este método valida, además, que el número sea binario 
        /// </summary>
        /// <param name="numero">Cadena de caracteres a convertir a binario</param>
        /// <returns>Binario en caso que se pueda convertir, "Valor inválido" caso contrario.</returns>
        public String DecimalBinario(String numero)
        {
            Double auxNum = 0;
            String retorno = "Valor Inválido";
            if (Double.TryParse(numero, out auxNum))
            {
                retorno = this.DecimalBinario(auxNum);
            }
            return retorno;
        }
        /// <summary>
        /// Convierte un Double decimal a binario.
        /// </summary>
        /// <param name="numero">Numero a convertir a binario</param>
        /// <returns>El valor pasado por parametro convertido a binario</returns>
        public String DecimalBinario(Double numero)
        {
            int numeroEntero = (int)Math.Abs(numero);
            StringBuilder sb = new StringBuilder();
            while (numeroEntero != 0)
            {
                sb.Append(numeroEntero % 2);
                numeroEntero /= 2;
            }
            char[] arrayChars = sb.ToString().ToCharArray();
            Array.Reverse(arrayChars);
            return new String(arrayChars);
        }
        /// <summary>
        /// Valida que un numero pasado por parametro en formato string sea un decimal.
        /// </summary>
        /// <param name="strNumero">Numéro a validar en formato string</param>
        /// <returns>El numero en caso que se pueda convertir, 0 caso contrario.</returns>
        private Double ValidarOperando(string strNumero)
        {
            double numeroRetorno = 0;
            Double.TryParse(strNumero, out numeroRetorno);
            return numeroRetorno;
        }
        #endregion

        #region Sobrecarga de operadores aritméticos
        /// <summary>
        /// Sobrecarga de operador +. Realiza una suma entre los atributos de cada operando.
        /// </summary>
        /// <param name="n1">Primer operando a sumar</param>
        /// <param name="n2">Segundo operando a sumar</param>
        /// <returns>El resultado de la suma</returns>
        public static Double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// Sobrecarga de operador -. Realiza una resta entre los atributos de cada operando.
        /// </summary>
        /// <param name="n1">Primer operando a restar</param>
        /// <param name="n2">Segundo operando a restar</param>
        /// <returns>El resultado de la resta</returns>
        public static Double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Sobrecarga de operador *. Realiza una multiplicación entre los atributos de cada operando.
        /// </summary>
        /// <param name="n1">Primer operando a multiplicar</param>
        /// <param name="n2">Segundo operando a multiplicar</param>
        /// <returns>El resultado de la multiplicación</returns>
        public static Double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// Sobrecarga de operador /. Realiza una suma entre los atributos de cada operando.
        /// </summary>
        /// <param name="n1">Dividendo</param>
        /// <param name="n2">Divisor</param>
        /// <returns>El resultado de la división. Caso contrario (Divisor igual a 0), retorna el menor valor de un decimal.</returns>
        public static Double operator /(Operando n1, Operando n2)
        {
            Double retorno = Double.MinValue;
            if (n2.numero != 0)
            {
                retorno = n1.numero / n2.numero;
            }
            return retorno;
        }
        #endregion

    }
}
