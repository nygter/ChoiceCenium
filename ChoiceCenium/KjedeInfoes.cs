//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChoiceCenium
{
    using System;
    using System.Collections.Generic;
    
    public partial class KjedeInfoes
    {
        public KjedeInfoes()
        {
            this.Hotelinfoes = new HashSet<Hotelinfoes>();
        }
    
        public int KjedeId { get; set; }
        public string KjedeNavn { get; set; }
    
        public virtual ICollection<Hotelinfoes> Hotelinfoes { get; set; }
    }
}
