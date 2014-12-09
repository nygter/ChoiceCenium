using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ChoiceCenium.SignalR
{
    public class HotelInfoSignalR
    {
        [JsonProperty("hotelid")]
        public int HotelId { get; set; }

        [JsonProperty("hotelname")]
        public string HotelName { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("lon")]
        public string Lon { get; set; }

        [JsonProperty("lat")]
        public string Lat { get; set; }

        [JsonProperty("currceniumversion")]
        public int CurrCeniumVersion { get; set; }

        [JsonProperty("upgradedate")]
        public DateTime? UpgradeDate { get; set; }

        [JsonProperty("ceniumupgradecomplete")]
        public bool CeniumUpgradeComplete { get; set; }

        [JsonProperty("notupgrading")]
        public bool NotUpgrading { get; set; }

        [JsonProperty("kjedeid")]
        public int KjedeId { get; set; }

        [JsonProperty("kjedenavn")]
        public string KjedeNavn { get; set; }
    }

    public class KjedeUpgradeStatusSignalR
    {
        [JsonProperty("kjedeid")]
        public int KjedeId { get; set; }

        [JsonProperty("kjedenavn")]
        public string KjedeNavn { get; set; }

        [JsonProperty("totalhotels")]
        public int TotalHotels { get; set; }

        [JsonProperty("upgradedhotels")]
        public int UpgradedHotels { get; set; }
    }

}