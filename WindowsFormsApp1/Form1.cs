using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionBancariaAppNS
{
    public partial class GestionBancariaApp : Form
    {
        private double saldo;
        //Sustituyo las constantes para identificar mejor los errores
        public const string ERR_CANTIDAD_NO_VALIDA = "Cantidad no valida";
        public const string ERR_SALDO_INSUFICIENTE = "Saldo insuficiente";

        public GestionBancariaApp(double saldo = 0)
        {
            InitializeComponent();
            if (saldo > 0)
                this.saldo = saldo;
            else
                this.saldo = 0;
            txtSaldo.Text = ObtenerSaldo().ToString();
            txtCantidad.Text = "0";
        }

        public double ObtenerSaldo() { return saldo; }

        public int RealizarReintegro(double cantidad) 
        {
            if (cantidad <= 0)
                //return ERR_CANTIDAD_NO_VALIDA;
                throw new ArgumentException(ERR_CANTIDAD_NO_VALIDA);
            if (saldo < cantidad)//Sustituyo la forma de generar las excepciones
                //return ERR_SALDO_INSUFICIENTE;
                throw new ArgumentOutOfRangeException(ERR_SALDO_INSUFICIENTE);
            saldo -= cantidad;  //RCM2324
            return 0;
        }

        public int RealizarIngreso(double cantidad) {
            if (cantidad <= 0)//Sustituyo la forma de generar las excepciones
                //return ERR_CANTIDAD_NO_VALIDA;
                throw new ArgumentOutOfRangeException(ERR_CANTIDAD_NO_VALIDA);
            saldo += cantidad; //RCM2324
            return 0;
        }

        private void btOperar_Click(object sender, EventArgs e)
        {
            double cantidad = Convert.ToDouble(txtCantidad.Text); // Cogemos la cantidad del TextBox y la pasamos a número
            if (rbReintegro.Checked)
            {
                try
                {
                    RealizarReintegro(cantidad);
                    MessageBox.Show("Transacción realizada.");
                }
                catch (Exception error) //RCM2324
                {
                    if (error.Message.Contains(ERR_SALDO_INSUFICIENTE))
                        MessageBox.Show("No se ha podido realizar la operación (¿Saldo Insuficiente?)");
                    else
                    {
                        if (error.Message.Contains(ERR_CANTIDAD_NO_VALIDA))
                            MessageBox.Show("Cantidad no valida, solo se admiten cantidades positivas");
                    }

                    
                }    
     
            }
            else 
            {
                try
                {
                    RealizarIngreso(cantidad);
                    MessageBox.Show("Transacción realizada.");
                }
                catch(Exception error) //RCM2324
                {
                    if (error.Message.Contains(ERR_CANTIDAD_NO_VALIDA))
                        MessageBox.Show("Cantidad no válida, sólo se admiten cantidades positivas.");
                }     
            }
           txtSaldo.Text = ObtenerSaldo().ToString();
        }
    }
}
                                                                        