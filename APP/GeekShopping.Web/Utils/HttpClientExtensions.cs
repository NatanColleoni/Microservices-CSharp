using System.Net.Http.Headers;
using System.Text.Json;

namespace GeekShopping.Web.Utils
{
    public static class HttpClientExtensions
    {
        private static readonly MediaTypeHeaderValue _contentType = new MediaTypeHeaderValue("application/json");
        
        public static async Task<T> ReadContentAsync<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException("Deu ruim" + $"{response.ReasonPhrase}");
            var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonSerializer.Deserialize<T>(responseString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public static async Task<HttpResponseMessage> PostAsync<T> (this HttpClient httpClient, string url, T data)
        {
            var dataString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataString);
            content.Headers.ContentType = _contentType;
            return await httpClient.PostAsync(url, content);
        }

        public static async Task<HttpResponseMessage> PutAsync<T>(this HttpClient httpClient, string url, T data)
        {
            var dataString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataString);
            content.Headers.ContentType = _contentType;
            return await httpClient.PutAsync(url, content);
        }
    }
}
