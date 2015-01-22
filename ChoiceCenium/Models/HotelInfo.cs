using System;
using System.Collections.Generic;
using System.Linq;
using ChoiceCenium.Hubs;
using ChoiceCenium.Services;

namespace ChoiceCenium.Models
{
    public class HotelInfo
    {
        public static List<Hotelinfoes> GetHotelInfo()
        {
            var db = new ChoiceCenium_dbEntities();

            try
            {
                return db.Hotelinfoes.ToList();
            }
            catch (Exception e)
            {
                //LogService.Register(e.Message, e.Source, e.ToString());
                throw;
            }
        }

        



        public static void InsertHotelInfo(Hotelinfoes h)
        {
            var db = new ChoiceCenium_dbEntities();

            try
            {
                db.Hotelinfoes.Add(h);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                //LogService.Register(e.Message, e.Source, e.ToString());
            }
            
            var hub = new HotelInfoHub();
            hub.SendUpdateToClients();
        }

        public static void UpdateHotelInfo(Hotelinfoes h)
        {
            var db = new ChoiceCenium_dbEntities();
            
            var hotelinfo = db.Hotelinfoes.FirstOrDefault(hi => hi.HotelId == h.HotelId);
            if (hotelinfo == null) return;

            try
            {
                hotelinfo.KjedeId = h.KjedeId;
                hotelinfo.HotelName = h.HotelName;
                hotelinfo.Address = h.Address;
                hotelinfo.CeniumUpgradeComplete = h.CeniumUpgradeComplete;
                hotelinfo.CurrCeniumVersion = h.CurrCeniumVersion;
                hotelinfo.NotUpgrading = h.NotUpgrading;
                hotelinfo.UpgradeDate = h.UpgradeDate;
                hotelinfo.PropertyCode = h.PropertyCode;

                db.SaveChanges();
            }
            catch (Exception e)
            {
                //LogService.Register(e.Message, e.Source, e.ToString());
            }

            var hub = new HotelInfoHub();
            hub.SendUpdateToClients();

        }

        public static void DeleteHotelInfo(Hotelinfoes h)
        {
            var db = new ChoiceCenium_dbEntities();

            try
            {
                Hotelinfoes hi = HotelService.GetHotelInfo(db, h.HotelId);
                db.Hotelinfoes.Remove(hi);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                var ugle = e.Message;
            }
            
            var hub = new HotelInfoHub();
            hub.SendUpdateToClients();
        }
    }
}