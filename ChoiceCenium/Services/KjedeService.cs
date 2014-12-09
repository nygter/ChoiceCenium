using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChoiceCenium.Services
{
    public static class KjedeService
    {
        public static string GetKjedeNavn(int kjedeId)
        {
            var db = new ChoiceCenium_dbEntities();
            return db.KjedeInfoes.Single(k => k.KjedeId == kjedeId).KjedeNavn;

        }

        public static IList<KjedeInfoes> GetKjeder()
        {
            var db = new ChoiceCenium_dbEntities();
            return db.KjedeInfoes.ToList();

        }

    }
}