using System;
using System.ComponentModel.DataAnnotations;

namespace ChoiceCenium.Model
{
    public class Hotelinfo
    {
        [Key]
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string Address { get; set; }
        public string Lon { get; set; }
        public string Lat { get; set; }
        public int CurrCeniumVersion { get; set; }
        public DateTime UpgradeDate { get; set; }
        public bool CeniumUpgradeComplete { get; set; }
        public bool NotUpgrading { get; set; }

        
        public int KjedeId { get; set; }
        public virtual KjedeInfo KjedeInfo { get; set; }
    }
}
