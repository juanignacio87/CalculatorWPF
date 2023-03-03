using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculadoraWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double numero1 = 0, numero2 = 0;
        char operador;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void agregarNumero(object sender, RoutedEventArgs e)
        {
            var boton = ((Button)sender);

            if (txtDisplay.Text == "0")
                txtDisplay.Text = "";

            txtDisplay.Text += boton.Content;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            numero1 = 0;
            numero2 = 0;
            operador = '\0';
            txtDisplay.Text = "0";
        }

        private void btnIgual_Click(object sender, RoutedEventArgs e)
        {
            numero2 = Convert.ToDouble(txtDisplay.Text);

            if (operador == '+')
            {
                txtDisplay.Text = (numero1 + numero2).ToString();
                numero1 = Convert.ToDouble(txtDisplay.Text);
            } 
            else if (operador == '-')
            {
                txtDisplay.Text = (numero1 - numero2).ToString();
                numero1 = Convert.ToDouble(txtDisplay.Text);
            }
            else if (operador == '/')
            {
                txtDisplay.Text = (numero1 / numero2).ToString();
                numero1 = Convert.ToDouble(txtDisplay.Text);
            }
            else if (operador == '*')
            {
                if (txtDisplay.Text != "0")
                {
                    txtDisplay.Text = (numero1 * numero2).ToString();
                    numero1 = Convert.ToDouble(txtDisplay.Text);
                }
                else { MessageBox.Show("No se puede dividir por cero"); }
            }
        }

        private void btnQuitar_Click(object sender, RoutedEventArgs e)
        {
            if (txtDisplay.Text.Length > 1)
            {
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
            }
            else
            {
                txtDisplay.Text = "0";
            }
        }

        private void btnDot_Click(object sender, RoutedEventArgs e)
        {
            if (txtDisplay.Text.Contains("."))
            {
                txtDisplay.Text += ".";
            }
        }

        private void clickOperador(object sender, RoutedEventArgs e)
        {
            var boton = ((Button)sender);

            numero1 = Convert.ToDouble(txtDisplay.Text);
            operador = Convert.ToChar(boton.Content);

            txtDisplay.Text = "0";


        }
    }
}
