using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiConnectionXamarin.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class OutcomeResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public List<string> Data { get; set; }
    }


}
