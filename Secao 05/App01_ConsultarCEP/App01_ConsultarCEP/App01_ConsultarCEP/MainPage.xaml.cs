using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servicos.modelo;
using App01_ConsultarCEP.Servicos;
namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;

        }

        private void BuscarCEP(object sender, EventArgs args)
        {


            //TODO - Validações.
            string cep = CEP.Text.Trim();

            if (isValidCEP(cep))
            {
                try
                {
                    Enderecos end = ViaCEPServico.BuscarEnderecosViaCEP(cep);

                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Seu Endereço é: {0},{1},{2}", end.localidade, end.uf, end.logradouro);
                    }

                    else
                    {
                        DisplayAlert("ERRO", "O endereço não foi encontrado para o CEP informado: " + cep, "OK");
                    }
                }
                catch (Exception e)
                {

                    DisplayAlert("Erro Crítico", e.Message, "OK");
                }
            }
            else
            {
                //T
            }
        }


        private bool isValidCEP(string cep)
        {
            bool valido = true;

            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP inválido! O CEP deve contar 8 caracteres.", "OK");

                valido = false;
            }
            int NovoCEP = 0;
            if (!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("ERRO", "CEP inválido! O CEP deve ser composto apenas por números.", "OK");

                valido = false;
            }
            return valido;
        }


    }
}


