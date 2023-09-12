using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public enum Operacion
    {
        NoDefinida = 0,
        Suma = 1,
        resta = 2,
        Multiplicacion = 3,
        Divicion = 4,
        Modulo = 5
    }
    public partial class Form1 : Form
    {
        double valor1 = 0;
        double valor2 = 0;
        Operacion operacion= Operacion.NoDefinida;
        bool numeroLeido = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void leerResultado(string numero)
        {
            numeroLeido = true;
            if (txtCajaResultado.Text == "0" && txtCajaResultado != null)
            {
                txtCajaResultado.Text = numero;
            }
            else
            {
                txtCajaResultado.Text += numero;
            }
        }

        private double EjecutarOperacion()
        {
            double resultado = 0;
            switch (operacion)
            {
                case Operacion.Suma:
                    resultado = valor1 + valor2;
                    break;
                case Operacion.resta:
                    resultado = valor1 - valor2;
                    break;
                case Operacion.Multiplicacion:
                    resultado = valor1 * valor2;
                    break;
                case Operacion.Divicion:
                    if (valor2 == 0)
                    {
                        MessageBox.Show("No se puede dividir entre cero");
                        resultado = 0;
                    }
                    else
                    {
                        resultado = valor1 / valor2;
                    }
                    break;
            }
            return resultado;
        }

        private void btnCero_Click(object sender, EventArgs e)
        {
            numeroLeido = true;
            if(txtCajaResultado.Text == "0")
            {
                return;
            }
            else
            {
                txtCajaResultado.Text += "0";
            }
        }

        private void btnUno_Click(object sender, EventArgs e)
        {
            leerResultado("1");
        }

        private void btnDos_Click(object sender, EventArgs e)
        {
            leerResultado("2");
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            leerResultado("3");
        }

        private void btnCuatro_Click(object sender, EventArgs e)
        {
            leerResultado("4");
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            leerResultado("5");
        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            leerResultado("6");
        }

        private void btnSiete_Click(object sender, EventArgs e)
        {
            leerResultado("7");
        }

        private void btnOcho_Click(object sender, EventArgs e)
        {
            leerResultado("8");
        }

        private void btnNueve_Click(object sender, EventArgs e)
        {
            leerResultado("9");
        }
        private void obtenerValor(string operadores)
        {
            valor1 = Convert.ToDouble(txtCajaResultado.Text);
            lblHistorial.Text = txtCajaResultado.Text + operadores;
            txtCajaResultado.Text = "0";
        }

        private void btnSuma_Click(object sender, EventArgs e)
        {
            operacion = Operacion.Suma;
            obtenerValor("+");
        }

        private void btnResultado_Click(object sender, EventArgs e)
        {
            if(valor2 == 0 && numeroLeido)
            {
                valor2 = Convert.ToDouble(txtCajaResultado.Text);
                lblHistorial.Text += valor2 + "=";
                double resultado = EjecutarOperacion();
                valor1 = 0;
                valor2 = 0;
                numeroLeido = false;
                txtCajaResultado.Text = Convert.ToString(resultado);
            }
        }

        private void btnResta_Click(object sender, EventArgs e)
        {
            operacion = Operacion.resta;
            obtenerValor("-");
        }

        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            operacion = Operacion.Multiplicacion;
            obtenerValor("x");
        }

        private void btnDivicion_Click(object sender, EventArgs e)
        {
            operacion = Operacion.Divicion;
            obtenerValor("÷");
        }

        private void btnPorcentaje_Click(object sender, EventArgs e)
        {
            valor2 = Convert.ToDouble(txtCajaResultado.Text);
            double resultado = Porcentaje(valor2);
            txtCajaResultado.Text = resultado.ToString();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtCajaResultado.Text = "0";
            lblHistorial.Text = "";
        }

        private void btnBorrarUnDigito_Click(object sender, EventArgs e)
        {
            if (txtCajaResultado.Text.Length > 1)
            {
                string txtResult = txtCajaResultado.Text;
                txtResult = txtResult.Substring(0, txtResult.Length - 1);
                if(txtResult.Length == 1 && txtResult.Contains("-"))
                {
                    txtCajaResultado.Text = "0";
                }
                else
                {
                    txtCajaResultado.Text = txtResult;
                }
            }
            else
            {
                txtCajaResultado.Text = "0";
            }
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            if (txtCajaResultado.Text.Contains("."))
            {
                return;
            }
            txtCajaResultado.Text += ".";
        }

        private double Porcentaje(double porcentaje)
        {
            double resultado = 0;
            switch (operacion)
            {
                case Operacion.Suma:
                    resultado = valor1 + (valor1 * porcentaje / 100);
                    break;
                case Operacion.resta:
                    resultado = valor1 - (valor1 * porcentaje / 100);
                    break;
            }
            return resultado;
        }
    }
}
