using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ChoiceCenium.ViewModels
{
    public class HotelsModel
    {
        [JsonProperty("hotelid")]
        public int HotelId { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("lon")]
        public string Lon { get; set; }

        [JsonProperty("lat")]
        public string Lat { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("currceniumversion")]
        public int? CurrCeniumVersion { get; set; }

        [JsonProperty("kjedeid")]
        public int KjedeId { get; set; }

        [JsonProperty("kjedenavn")]
        public string KjedeNavn { get; set; }
    }
}