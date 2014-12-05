using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChoiceCenium.Model
{
    public class KjedeInfo
    {
        [Key]
        public int KjedeId { get; set; }
        public string KjedeNavn { get; set; }
        public virtual ICollection<Hotelinfo> HotelInfoList { get; set; }
    }
}
