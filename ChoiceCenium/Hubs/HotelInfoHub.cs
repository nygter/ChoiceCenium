﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using ChoiceCenium.Services;
using ChoiceCenium.SignalR;
using Microsoft.AspNet.SignalR;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace ChoiceCenium.Hubs
{
    public class HotelInfoHub : Hub
    {
        public void Send(HotelSignalR signalRObject)
        {
            try
            {
                var context = GlobalHost.ConnectionManager.GetHubContext<HotelInfoHub>();
                context.Clients.All.addNewMessageToPage(signalRObject);
            }
            catch (Exception e)
            {
                //LogService.Register(e.Message, e.Source, e.ToString());
            }
        }

        public void SendSingle(HotelSignalR signalRObject)
        {
            try
            {
                var context = GlobalHost.ConnectionManager.GetHubContext<HotelInfoHub>();
                context.Clients.All.addNewMessageToPage(signalRObject);
                //this.Clients.Caller.sendUpdateToClient(signalRObject);
            }
            catch (Exception e)
            {
                //LogService.Register(e.Message, e.Source, e.ToString());
            }
        }


        public void SendUpdateToClients()
        {
            var hotelSignalR = BuildHotelInfo();
            Send(hotelSignalR);
        }

        public void InitializeClient()
        {
            var hotelSignalR = BuildHotelInfo();
            SendSingle(hotelSignalR);

        }

        private static HotelSignalR BuildHotelInfo()
        {
            var db = new ChoiceCenium_dbEntities();

            var hotelList = db.Hotelinfoes.ToList();

            var hotelSignalR = new HotelSignalR();

            List<HotelInfoSignalR> hotelListSignalR = hotelList.Select(hotelinfo => new HotelInfoSignalR
            {
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
                UpgradeDate = hotelinfo.UpgradeDate ?? null
            }).ToList();

            hotelSignalR.HotelListSignalR = hotelListSignalR;
            hotelSignalR.KjedeListUpgradeStatusSignalR = StatisticService.PopulateKjedeUpgradeStatusList(hotelListSignalR);
            hotelSignalR.UpgradeStatusPercentage = StatisticService.GetUpgradeStatusPercentage(hotelListSignalR);
            return hotelSignalR;
        }

        
    }

    public class HotelSignalR
    {
        public List<HotelInfoSignalR> HotelListSignalR { get; set; }
        public List<KjedeUpgradeStatusSignalR> KjedeListUpgradeStatusSignalR { get; set; }

        [JsonProperty("upgradestatuspercentage")]
        public double UpgradeStatusPercentage { get; set; }
    }
}