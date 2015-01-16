using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ChoiceCenium.ViewModels
{
    public class HotelGeoModel
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Lon")]
        public string Lon { get; set; }

        [JsonProperty("Lat")]
        public string Lat { get; set; }
    }
}