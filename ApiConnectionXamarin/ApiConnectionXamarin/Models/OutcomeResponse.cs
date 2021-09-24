using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ApiConnectionXamarin.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class OutcomeResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("data")]
        public List<string> Data { get; set; }
    }


}
