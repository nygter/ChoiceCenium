//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelImport
{
    using System;
    using System.Collections.Generic;
    
    public partial class Hotelinfoes
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string Address { get; set; }
        public string Lon { get; set; }
        public string Lat { get; set; }
        public int CurrCeniumVersion { get; set; }
        public Nullable<System.DateTime> UpgradeDate { get; set; }
        public bool CeniumUpgradeComplete { get; set; }
        public bool NotUpgrading { get; set; }
        public int KjedeId { get; set; }
    
        public virtual KjedeInfoes KjedeInfoes { get; set; }
    }
}
