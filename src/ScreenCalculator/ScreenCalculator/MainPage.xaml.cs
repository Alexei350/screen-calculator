using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScreenCalculator
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            double cm = double.TryParse(txtPol.Text, out double valor) ? valor * 2.54 : 0;

            double escala = Math.Sqrt(Math.Pow(cm, 2) / (Math.Pow(16, 2) + Math.Pow(9, 2)));

            double altura = escala * 9;
            double largura = escala * 16;

            lblAltura.Text = "Altura: " + altura.ToString("N1") + "cm";
            lblLargura.Text = "Largura: " + largura.ToString("N1") + "cm";
        }
    }
}
