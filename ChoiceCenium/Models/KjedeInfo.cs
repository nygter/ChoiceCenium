using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChoiceCenium.Services;

namespace ChoiceCenium.Models
{
    public class KjedeInfo
    {
        public static List<KjedeInfoes> GetKjedeInfo()
        {
            var db = new ChoiceCenium_dbEntities();

            try
            {
                return db.KjedeInfoes.ToList();
            }
            catch (Exception e)
            {
                LogService.Register(e.Message, e.Source, e.ToString());
                throw;
            }
        }
    }
}