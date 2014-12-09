using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChoiceCenium.SignalR;

namespace ChoiceCenium.Services
{
    public static class StatisticService
    {
        public static List<KjedeUpgradeStatusSignalR> PopulateKjedeUpgradeStatusList(List<HotelInfoSignalR> hotelListSignalR)
        {
            var kjedeInfoList = KjedeService.GetKjeder();
            
            return (from h in hotelListSignalR
                group h by h.KjedeId
                into grp
                join k in kjedeInfoList on grp.Key equals k.KjedeId
                select new KjedeUpgradeStatusSignalR
                {
                    KjedeId = grp.Key,
                    KjedeNavn = k.KjedeNavn,
                    TotalHotels = grp.Count(),
                    UpgradedHotels = grp.Count(ht => ht.CeniumUpgradeComplete)

                }).ToList();

            // Comfort Hotels 6 / 12
            // Choice Hotels 1 / 8
            // Clarion Hotels 6 / 33
        }

        public static double GetUpgradeStatusPercentage(List<HotelInfoSignalR> hotelListSignalR)
        {
            int TotalNrOfHotelsToBeUpgraded = hotelListSignalR.Count(hl => !hl.NotUpgrading);
            int TotalNrOfUpgradedHotels = hotelListSignalR.Count(hl => hl.CeniumUpgradeComplete);

            return TotalNrOfUpgradedHotels/TotalNrOfHotelsToBeUpgraded*100;

        }
    }
}