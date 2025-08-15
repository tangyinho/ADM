using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ADM.Server.Service
{
    public class APIService
    {
        private readonly HttpClient _httpClient;

        public APIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetAsync(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);
                var statusObject = response.EnsureSuccessStatusCode();

                if (statusObject.StatusCode.ToString() == "OK")
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return content;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GET request error: {ex.Message}");
                return null;
            }
        }

        public async Task<string> PostAsync<T>(string url, T data)
        {
            try
            {
                var jsonContent = JsonSerializer.Serialize(data);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"POST request error: {e.Message}");
                return null;
            }
        }

        public async Task<string> PutAsync<T>(string url, T data)
        {
            try
            {
                var jsonContent = JsonSerializer.Serialize(data);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PutAsync(url, content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"PUT request error: {e.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteAsync(string url)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync(url);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"DELETE request error: {e.Message}");
                return false;
            }
        }
    }
}
