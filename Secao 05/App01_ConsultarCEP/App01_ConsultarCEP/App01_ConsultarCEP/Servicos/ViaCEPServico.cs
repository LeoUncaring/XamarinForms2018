using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_ConsultarCEP.Servicos.modelo;
using Newtonsoft.Json;

namespace App01_ConsultarCEP.Servicos
{
    public class ViaCEPServico
    {
        private static string EnderecosURL = "http://viacep.com.br/ws/{0}/json/";

        public static Enderecos BuscarEnderecosViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecosURL, cep);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            Enderecos end = JsonConvert.DeserializeObject<Enderecos>(Conteudo);

            if (end.cep == null) return null;

            return end;
        }
    }
}
