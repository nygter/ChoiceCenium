using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelImport;

namespace Choice.Cenium.HotelImportJob
{
    //public class EqualityComparer : IEqualityComparer<HotelImport>
    //{
    //    public bool Equals(HotelImport x, HotelImport y)
    //    {
    //        return x.LoepeNr == y.LoepeNr;
    //    }

    //    public int GetHashCode(HotelImport obj)
    //    {
    //        return obj.LoepeNr.GetHashCode();
    //    }
    //}

    public class HotelImport : ReadFile<HotelImport>
    {
        public static List<HotelImport> ReadHotel(Stream hotelStream)
        {
            return ReadStream(hotelStream, GetHotelLine);
        }

        private static void GetHotelLine(string[] a, HotelImport newHotelLine)
        {
            newHotelLine.HotelName = a[0];
            newHotelLine.Address = a[2] + "," + a[3] + "," + a[4] + "," + a[5];
            newHotelLine.Kjede = a[1];

            var tempGotCenium = a[7];
            bool notUpgradingCenium;

            if (tempGotCenium.ToLower() != "yes" || tempGotCenium.ToLower() != "y")
            {
                notUpgradingCenium = true;
            }
            else
            {
                notUpgradingCenium = false;
            }

            newHotelLine.NotUpgrading = notUpgradingCenium;

            newHotelLine.UpgradeDate = DateTime.MinValue;

            //newHotelLine.Lon = int.Parse(a[2]);
            //newHotelLine.Lat = int.Parse(a[2]);
            //newHotelLine.CurrCeniumVersion = int.Parse(a[7]);
        }

        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string Address { get; set; }
        public string Lon { get; set; }
        public string Lat { get; set; }
        public int CurrCeniumVersion { get; set; }
        public System.DateTime UpgradeDate { get; set; }
        public bool CeniumUpgradeComplete { get; set; }
        public bool NotUpgrading { get; set; }
        public int KjedeId { get; set; }

        public string Kjede { get; set; }
    }
}
