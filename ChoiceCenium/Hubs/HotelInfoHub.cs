using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using ChoiceCenium.Services;
using ChoiceCenium.SignalR;
using Microsoft.AspNet.SignalR;
using System.Web.Script.Serialization;

namespace ChoiceCenium.Hubs
{
    public class HotelInfoHub : Hub
    {
        public void Send(List<HotelInfoSignalR> hotelInfo)
        {
            try
            {
                
                //var jsonSerialiser = new JavaScriptSerializer();
                //var json = jsonSerialiser.Serialize(hotelInfo);

                var context = GlobalHost.ConnectionManager.GetHubContext<HotelInfoHub>();
                //context.Clients.Client(dic[name]).broadcastMessage(message);
                //hotelBooking = ChoiceHotelBooking.HotelBooking(hotelBooking);
                context.Clients.All.addNewMessageToPage(hotelInfo);
            }
            catch (Exception e)
            {
                LogService.Register(e.Message, e.Source, e.ToString());
            }
        }

        public void SendUpdateToClients()
        {
            var db = new ChoiceCenium_dbEntities();

            var hotelList = db.Hotelinfoes.ToList();
            
            var hotelListSignalR = hotelList.Select(hotelinfo => new HotelInfoSignalR{
                HotelId = hotelinfo.HotelId, 
                HotelName = hotelinfo.HotelName, 
                Address = hotelinfo.Address, 
                CeniumUpgradeComplete = hotelinfo.CeniumUpgradeComplete, 
                CurrCeniumVersion = hotelinfo.CurrCeniumVersion, 
                KjedeId = hotelinfo.KjedeId, 
                KjedeNavn = KjedeService.GetKjedeNavn(hotelinfo.KjedeId), 
                Lat = hotelinfo.Lat, 
                Lon = hotelinfo.Lon, 
                NotUpgrading = hotelinfo.NotUpgrading, 
                UpgradeDate = null
            }).ToList();

            Send(hotelListSignalR);

        }
    }
}