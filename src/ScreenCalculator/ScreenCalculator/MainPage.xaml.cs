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

            pkrUnidade.SelectedIndex = 0;
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            double valorDiagPol = double.TryParse(txtPol.Text, out double valor) ? valor : 0;
            double ValorDiagCm  = valorDiagPol * 2.54;

            string diagPol = valorDiagPol.ToString("N1");
            string diagCm  = ValorDiagCm.ToString("N1");

            string altPol  = (valorDiagPol * 0.49091).ToString("N1");
            string largPol = (valorDiagPol * 0.87247).ToString("N1");

            string altCm  = (ValorDiagCm * 0.49091).ToString("N1");
            string largCm = (ValorDiagCm * 0.87247).ToString("N1");
            
            lblDiagonal.Text = $"{diagCm}cm {diagPol}\"";
            lblAltura.Text   = $"{altCm}cm {altPol}\"";
            lblLargura.Text  = $"{largCm}cm {largPol}\"";
        }
    }
}
