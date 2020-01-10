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
            AtualizaValores();
        }

        private void pkrUnidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizaValores();
        }

        private void AtualizaValores()
        {
            double valorDiagPol;
            double valorDiagCm;

            if (pkrUnidade.SelectedIndex == 0)
            {
                valorDiagPol = double.TryParse(txtInput.Text, out double valor) ? valor : 0;
                valorDiagCm = valorDiagPol * 2.54;
            }
            else
            {
                valorDiagCm = double.TryParse(txtInput.Text, out double valor) ? valor : 0;
                valorDiagPol = valorDiagCm / 2.54;
            }

            string diagPol = valorDiagPol.ToString("N1");
            string diagCm = valorDiagCm.ToString("N1");

            string altPol = (valorDiagPol * 0.49091).ToString("N1");
            string largPol = (valorDiagPol * 0.87247).ToString("N1");

            string altCm = (valorDiagCm * 0.49091).ToString("N1");
            string largCm = (valorDiagCm * 0.87247).ToString("N1");

            lblDiagonal.Text = $"{diagCm}cm {diagPol}\"";
            lblAltura.Text = $"{altCm}cm {altPol}\"";
            lblLargura.Text = $"{largCm}cm {largPol}\"";
        }
    }
}
