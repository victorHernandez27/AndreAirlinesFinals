using AndreAirlineApi2.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Robo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InserirAeronave();
            //InserirEndereco();
            //InserirAeroporto();
            //InserirVoo();
            //InserirPassageiro();
            //InserirClasse();
            //InserirPrecoBase();
            //InserirPassagem();
        }

        public static void InserirAeronave()
        {
            var streamReader = new StreamReader("aeronave.json");
            string jsonString = streamReader.ReadToEnd();
            var aeronaves = JsonConvert.DeserializeObject<List<Aeronave>>(jsonString);

            var dados = new Dados();

            aeronaves.ForEach(async aeronave =>
            {
                await dados.InserirAeronove(aeronave);
            });
        }

        public static void InserirAeroporto()
        {
            var streamReader = new StreamReader("aeroporto.json");
            string jsonString = streamReader.ReadToEnd();
            var aeroportos = JsonConvert.DeserializeObject<List<Aeroporto>>(jsonString);

            var dados = new Dados();

            aeroportos.ForEach(async aeroporto =>
            {
                await dados.InserirAeroporto(aeroporto);
            });
        }
            
        public static void InserirEndereco()
        {
            var streamReader = new StreamReader("endereco.json");
            string jsonString = streamReader.ReadToEnd();
            var enderecos = JsonConvert.DeserializeObject<List<Endereco>>(jsonString);

            var dados = new Dados();

            enderecos.ForEach(async endereco =>
            {
                await dados.InserirEndereco(endereco);
            });
        }

        public static void InserirPassageiro()
        {
            var streamReader = new StreamReader("passageiro.json");
            string jsonString = streamReader.ReadToEnd();
            var passageiros = JsonConvert.DeserializeObject<List<Passageiro>>(jsonString);

            var dados = new Dados();

            passageiros.ForEach(async passageiro =>
            {
                await dados.InserirPassageiro(passageiro);
            });
        }

        public static void InserirVoo()
        {
            var streamReader = new StreamReader("voo.json");
            string jsonString = streamReader.ReadToEnd();
            var voos = JsonConvert.DeserializeObject<List<Voo>>(jsonString);

            var dados = new Dados();

            voos.ForEach(async voo =>
            {
                await dados.InserirVoo(voo);
            });
        }

        public static void InserirClasse()
        {
            var streamReader = new StreamReader("classe.json");
            string jsonString = streamReader.ReadToEnd();
            var classes = JsonConvert.DeserializeObject<List<Classe>>(jsonString);

            var dados = new Dados();

            classes.ForEach(async classe =>
            {
                await dados.InserirClasse(classe);
            });
        }
        public static void InserirPrecoBase()
        {
            var streamReader = new StreamReader("precobase.json");
            string jsonString = streamReader.ReadToEnd();
            var precosBase = JsonConvert.DeserializeObject<List<PrecoBase>>(jsonString);

            var dados = new Dados();

            precosBase.ForEach(async precoBase =>
            {
                await dados.InserirPrecoBase(precoBase);
            });
        }

        public static void InserirPassagem()
        {
            var streamReader = new StreamReader("passagem.json");
            string jsonString = streamReader.ReadToEnd();
            var passagens = JsonConvert.DeserializeObject<List<Passagem>>(jsonString);

            var dados = new Dados();

            passagens.ForEach(async passagem =>
            {
                await dados.InserirPassagem(passagem);
            });
        }
    }
}
