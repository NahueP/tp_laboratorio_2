using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();

            this.lblResultado.Text = "";

            this.cmbOperador.Items.Add("+"); 
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("/");

            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
        }

        #region Metodos
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.lblResultado.Text = "";
            this.cmbOperador.SelectedIndex = -1;
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);

            return Calculadora.Operar(num1, num2, operador);
        }
        #endregion

        #region Eventos

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

       

        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = (Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text)).ToString();
            btnConvertirABinario.Enabled = true;
            btnConvertirADecimal.Enabled = false;
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero aBinario = new Numero();
            lblResultado.Text = aBinario.DecimalBinario(lblResultado.Text);

            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = true;
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero aDecimal = new Numero();
            lblResultado.Text = aDecimal.BinarioDecimal(lblResultado.Text);

            btnConvertirADecimal.Enabled = false;
            btnConvertirABinario.Enabled = true;
        }

        #endregion
    }
}
