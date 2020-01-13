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

            pkrMedida.SelectedIndex = 0;
            pkrUnidade.SelectedIndex = 0;
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            AtualizaValores();
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizaValores();
        }

        private void AtualizaValores()
        {
            double input = double.TryParse(txtInput.Text, out double valor) ? valor : 0;

            double valorDiagPol = 0, valorDiagCm = 0, valorAltPol = 0, valorAltCm = 0, valorLargPol = 0, valorLargCm = 0;

            if (pkrUnidade.SelectedIndex == 1)
            {
                input /= 2.54;
            }

            switch (pkrMedida.SelectedIndex)
            {
                case 0:
                    valorDiagPol = input;

                    break;
                case 1:
                    valorAltPol = input;
                    valorDiagPol = input * 2.0395;

                    break;
                case 2:
                    valorLargPol = input;
                    valorDiagPol = input * 1.152;

                    break;
            }

            if (valorAltPol == 0)
                valorAltPol = valorDiagPol * 0.49091;
            if (valorLargPol == 0)
                valorLargPol = valorDiagPol * 0.87247;

            valorDiagCm = valorDiagPol * 2.54;
            valorAltCm = valorAltPol * 2.54;
            valorLargCm = valorLargPol * 2.54;

            string diagCm = valorDiagCm.ToString("N1");
            string diagPol = valorDiagPol.ToString("N1");

            string altCm = valorAltCm.ToString("N1");
            string altPol = valorAltPol.ToString("N1");

            string largPol = valorLargPol.ToString("N1");
            string largCm = valorLargCm.ToString("N1");

            lblDiagonal.Text = $"{diagCm}cm - {diagPol}\"";
            lblAltura.Text = $"{altCm}cm - {altPol}\"";
            lblLargura.Text = $"{largCm}cm - {largPol}\"";
        }
    }
}
