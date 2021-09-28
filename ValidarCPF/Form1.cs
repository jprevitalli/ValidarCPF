using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValidarCPF
{
    public partial class validadorCPF : Form
    {
        public validadorCPF()
        {
            InitializeComponent();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            string cpfdigitado = maskedTxtCPF.Text.Replace(".", "").Replace("-", "").Replace(" ", "");

            if (string.IsNullOrWhiteSpace(cpfdigitado))
            {
                
                // digitar mbox e apertar tab 2x
                
                MessageBox.Show("Digite o CPF!", "Atenção");
                maskedTxtCPF.Focus();
                maskedTxtCPF.SelectAll();
                return;

            }
            if (cpfdigitado.Length != 11)
            {
                lblResul.Text = "Infome um CPF com 11 números";
                lblResul.ForeColor = Color.Red;
                return;
            }

            // Separar os números em grupos

            string cpf = cpfdigitado.Substring(0, 9);

            int soma = 0;

            int valorRef = 10;

            for (int i = 0; i <= 8; i++)
            {
                soma += Convert.ToInt32(cpf[i].ToString()) * valorRef--;
            }

            // Calcular o primeiro dígito verificador

            int div1 = (int) soma % 11;

            if(div1 < 2)
            {
                div1 = 0;
            }
            else
            {
                div1 = 11 - div1;
            }
        
            if( !cpfdigitado.Substring(9, 1).Equals(div1.ToString()))
            {
                MessageBox.Show("Informe um CPF válido!", "Atenção!");
                lblResul.Text = "Informe um CPF Válido";
                lblResul.ForeColor = Color.Red;
                return;
            }

            // Calcular o segundo dígito verificador

            soma = 0;
            valorRef = 11;

            cpf = cpf + div1;

            for (int i = 0; i <= 9; i++)
            {
                soma += Convert.ToInt32(cpf[i].ToString()) * valorRef--;
            }

            int div2 = (int)(soma % 11);

            if (div2 < 2)
            {
                div2 = 0;
            }
            else
            {
                div2 = 11 - div2;
            }


            if(!cpfdigitado.Substring(10,1).Equals(div2.ToString()))
            {
                MessageBox.Show("Informe um CPF válido!", "Atenção!");
                lblResul.ForeColor = Color.Red;
                return;
            }

            MessageBox.Show("CPF digitado é válido!", "Sucesso!");
            lblResul.Text = "O CPF digitado é válido!";
            lblResul.ForeColor = Color.Green;

        }

        private void btnValidar_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnValidar.Enabled.ToString();
        }
    }
}
