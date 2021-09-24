using ApiConnectionXamarin.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiConnectionXamarin.Services
{
    public class MedicalApiService : IMedicalApiService
    {
        IJsonSerializerService serializer = new JsonSerializerService();
        public async Task<OutcomeResponse> GetOutcomesAsync()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://api.endlessmedical.com/v1/dx/GetOutcomes");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var outcomeResponse = serializer.Deserialize<OutcomeResponse>(responseString);
                return outcomeResponse;
            }
            return null;
        }
    }
}
