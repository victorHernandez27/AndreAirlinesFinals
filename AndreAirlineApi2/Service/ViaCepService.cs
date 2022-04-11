using AndreAirlineApi2.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace AndreAirlineApi2.Service
{
    public class ViaCepService
    {
        static readonly HttpClient client = new HttpClient();
        public static async Task<Endereco> ViaCepJsonAsync(string cep)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://viacep.com.br/ws/" + cep + "/json/");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var end = JsonConvert.DeserializeObject<Endereco>(responseBody);
                return end;
            }
            catch (HttpRequestException e)
            {
                throw;
            }


        }
    }
}
