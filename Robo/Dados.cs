using AndreAirlineApi2.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Robo
{
    public class Dados
    {
        private readonly HttpClient client;

        public Dados()
        {
            client = new HttpClient();
        }

        public async Task InserirAeronove(Aeronave aeronave)
        {
            var requestContent = new StringContent(JsonConvert.SerializeObject(aeronave), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:44360/api/aeronaves", requestContent);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
                Console.WriteLine($"Aeronave: {aeronave.Id} inserida com sucesso.");

            Console.WriteLine($"Erro ao inserir Aeronave: { response.Content.ReadAsStringAsync() }");
        }

        public async Task InserirAeroporto(Aeroporto aeroporto)
        {
            var requestContent = new StringContent(JsonConvert.SerializeObject(aeroporto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:44360/api/aeroportos", requestContent);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
                Console.WriteLine($"Aeroporto: {aeroporto.Sigla} inserido com sucesso.");

            Console.WriteLine($"Erro ao inserir Aeroporto: { response.Content.ReadAsStringAsync() }");

        }
        public async Task InserirEndereco(Endereco endereco)
        {
            var requestContent = new StringContent(JsonConvert.SerializeObject(endereco), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:44360/api/enderecos", requestContent);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
                Console.WriteLine($"Endereço: {endereco.Id} inserido com sucesso.");

            Console.WriteLine($"Erro ao inserir Endereço: { response.Content.ReadAsStringAsync() }");

        }

        public async Task InserirPassageiro(Passageiro passageiro)
        {
            var requestContent = new StringContent(JsonConvert.SerializeObject(passageiro), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:44360/api/passageiros", requestContent);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
                Console.WriteLine($"Passageiro: {passageiro.Cpf} inserido com sucesso.");

            Console.WriteLine($"Erro ao inserir Passageiro: { response.Content.ReadAsStringAsync() }");

        }

        public async Task InserirVoo(Voo voo)
        {
            var requestContent = new StringContent(JsonConvert.SerializeObject(voo), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:44360/api/voos", requestContent);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
                Console.WriteLine($"Voo: {voo.Id} inserido com sucesso.");

            Console.WriteLine($"Erro ao inserir Voo: { response.Content.ReadAsStringAsync() }");

        }

        public async Task InserirClasse(Classe classe)
        {
            var requestContent = new StringContent(JsonConvert.SerializeObject(classe), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:44360/api/classes", requestContent);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
                Console.WriteLine($"Classe: {classe.Id} inserida com sucesso.");

            Console.WriteLine($"Erro ao inserir Classe: { response.Content.ReadAsStringAsync() }");
        }

        public async Task InserirPrecoBase(PrecoBase precoBase)
        {
            var requestContent = new StringContent(JsonConvert.SerializeObject(precoBase), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:44360/api/precosbase", requestContent);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
                Console.WriteLine($"Preço Base: {precoBase.Id} inserido com sucesso.");

            Console.WriteLine($"Erro ao inserir Preço Base: { response.Content.ReadAsStringAsync() }");
        }
        
        public async Task InserirPassagem(Passagem passagem)
        {
            var requestContent = new StringContent(JsonConvert.SerializeObject(passagem), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:44360/api/passagens", requestContent);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
                Console.WriteLine($"Passagem: {passagem.Id} inserida com sucesso.");

            Console.WriteLine($"Erro ao inserir Passagem: { response.Content.ReadAsStringAsync() }");
        }
    }
}
