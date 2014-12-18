using System;
using System.Linq;
using System.Web.Services;
using ChoiceCenium.Hubs;
using DevExpress.Data.WcfLinq.Helpers;

namespace ChoiceCenium.Services
{
    public class HotelService
    {
        [WebMethod]
        public void CeniumWebJob()
        {
            CheckHotelsAsCompletedByUpgradeDate();


            var hub = new HotelInfoHub();
            hub.SendUpdateToClients();
        }

        private void CheckHotelsAsCompletedByUpgradeDate()
        {
            var db = new ChoiceCenium_dbEntities();
            var yesterday = DateTime.UtcNow.AddDays(-1);

            var hotelList =
                db.Hotelinfoes.Where(
                    d => d.UpgradeDate.HasValue && d.UpgradeDate.Value <= yesterday && d.CeniumUpgradeComplete == false);

            foreach (var hi in hotelList)
            {
                hi.CeniumUpgradeComplete = true;
            }
            db.SaveChanges();
        }
    }
}