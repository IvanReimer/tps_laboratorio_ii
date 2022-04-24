using System;
using System.Windows.Forms;
using Entidades;
namespace MiCalculadora2
{
    public partial class FormCalculadora : Form
    {
        Operando n1;
        public FormCalculadora()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Cuando se carga el form de la calculadora, este evento limpia los textBox,
        /// el combobox y el label del resultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.btnLimpiar_Click(sender, e);
        }
        /// <summary>
        /// Método para limpiar la calculadora. Limpia el los textBox donde se alojan los números,
        /// el label donde se aloja el resultado y inicializa el combobox donde estan los operandos
        /// en vacío.
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.SelectedIndex = 0;
            this.lblResultado.Text = "";
        }
        /// <summary>
        /// Evento donde se utiliza el método limpiar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
        /// <summary>
        /// Método donde se realiza una operación entre dos números pasados por string y 
        /// un operador pasado también como string.
        /// </summary>
        /// <param name="numero1">Primer operando a operar</param>
        /// <param name="numero2">Segundo operando a operar</param>
        /// <param name="operador">Operador que realiza la operación</param>
        /// <returns>Un Double con la operación hecha. En caso que no se pueda, devuelve 0.</returns>
        private static Double Operar(String numero1 , String numero2 , String operador)
        {
            Operando n1 = new Operando(numero1);
            Operando n2 = new Operando(numero2);
            return Calculadora.Operar(n1, n2, Char.Parse(operador));

            return Calculadora.Operar(new Operando(numero1), new Operando(numero2), char.Parse(operador)); ;
        }
        /// <summary>
        /// Evento donde se pregunta al usuario si esta seguro de salir.
        /// En caso que quiera, se cierra el formulario, casi que no, sigue donde esta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        /// <summary>
        /// Dicho evento, convierte a binario el valor ubicado en el label donde se aloja el resultado.
        /// En caso que no pueda, devuelve "Valor invalido". En caso que pueda, lo convierte a binario,
        /// lo muestra en el label resultado y además lo muestra en el listBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando operando = new Operando();
            String resultado = operando.DecimalBinario(this.lblResultado.Text);
            this.lstOperaciones.Items.Add($"{this.lblResultado.Text} -> {resultado}");
            this.lblResultado.Text = resultado;
        }
        /// <summary>
        /// Dicho evento, convierte a decimal el valor ubicado en el label donde se aloja el resultado.
        /// En caso que no pueda, devuelve "Valor invalido". En caso que pueda, lo convierte a decimal,
        /// lo muestra en el label resultado y además lo muestra en el listBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando operando = new Operando();
            String resultado = operando.BinarioDecimal(this.lblResultado.Text);
            this.lstOperaciones.Items.Add($"{this.lblResultado.Text} -> {resultado}");
            this.lblResultado.Text = resultado;
        }
        /// <summary>
        /// Evento que realiza la operación entre los dos operandos alojados en los textBox
        /// y el operador elegido en el comboBox. En caso de que no se elija nada, lo operadores
        /// son 0 y el operador es un +.
        /// Además, este evento muestra en el list box la operación realizada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            String operadorSalida = "+", primerOperador = "0", segundoOperador= "0";
            if (this.cmbOperador.Text != " ")
            {
                operadorSalida = this.cmbOperador.Text;
            }
            if (this.txtNumero1.Text != String.Empty)
            {
                primerOperador = this.txtNumero1.Text;
            }
            if (this.txtNumero2.Text != String.Empty)
            {
                segundoOperador = this.txtNumero2.Text;
            }
            this.lblResultado.Text = FormCalculadora.Operar(this.txtNumero1.Text,this.txtNumero2.Text,this.cmbOperador.Text).ToString();
            this.lstOperaciones.Items.Add($"{primerOperador} {operadorSalida} {segundoOperador} = {this.lblResultado.Text}");
        }
    }
}
