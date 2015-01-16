using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using ChoiceCenium.Hubs;
using ChoiceCenium.ViewModels;
using DevExpress.Data.WcfLinq.Helpers;

namespace ChoiceCenium.Services
{
    public static class HotelService
    {
        public static void CheckHotelsAsCompletedByUpgradeDate()
        {
            var db = new ChoiceCenium_dbEntities();
            var yesterday = DateTime.UtcNow.AddDays(-1);

            var hotelList =
                db.Hotelinfoes.Where(
                    d => d.UpgradeDate.HasValue && d.UpgradeDate.Value <= yesterday && d.CeniumUpgradeComplete == false);

            foreach (var hi in hotelList)
            {
                hi.CeniumUpgradeComplete = true;
                hi.CurrCeniumVersion = 6;
                if (hi.UpgradeDate == null)
                {
                    hi.UpgradeDate = DateTime.UtcNow;
                }
            }
            db.SaveChanges();
        }

        public static IList<HotelGeoModel> GetBasicHotelInfo()
        {
            var db = new ChoiceCenium_dbEntities();

            var hotelCoreList = db.Hotelinfoes.ToList();

            List<HotelGeoModel> hotelList = hotelCoreList.Select(hotelinfo => new HotelGeoModel()
            {
                Name = hotelinfo.HotelName,
                Lat = hotelinfo.Lat,
                Lon = hotelinfo.Lon,
            }).ToList();

            return hotelList;
        }

        public static IList<HotelsModel> GetDefaultHotelInfo()
        {
            var db = new ChoiceCenium_dbEntities();

            var hotelCoreList = db.Hotelinfoes.ToList();

            List<HotelsModel> hotelList = hotelCoreList.Select(hotelinfo => new HotelsModel()
            {
                Name = hotelinfo.HotelName,
                Lat = hotelinfo.Lat,
                Lon = hotelinfo.Lon,
                Address = hotelinfo.Address,
                CurrCeniumVersion = hotelinfo.CurrCeniumVersion,
                HotelId = hotelinfo.HotelId,
                KjedeId = hotelinfo.KjedeId,
                KjedeNavn = KjedeService.GetKjedeNavn(hotelinfo.KjedeId)
            }).ToList();

            return hotelList;
        }
    }
}