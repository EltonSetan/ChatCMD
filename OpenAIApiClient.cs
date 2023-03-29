using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ChatCMD
{
    public class OpenAIApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public OpenAIApiClient(string apiKey)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.BaseAddress = new Uri("https://api.openai.com/v1/");
        }


        public async Task<T> PostAsync<T>(string uri, object data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Request to OpenAI API failed with status code: {response.StatusCode}");
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            T result = JsonConvert.DeserializeObject<T>(responseContent);
            return result;
        }
    }
}
